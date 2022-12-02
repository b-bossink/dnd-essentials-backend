using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models;
using Repository;

namespace Service.Authentication
{
	public class AuthenticationService : IAuthenticationService
	{
        private readonly UserRepo _repo;
        private readonly JwtHandler _jwt;
        public AuthenticationService(UserRepo repo, JwtHandler jwt)
        {
            _repo = repo;
            _jwt = jwt;
        }

        public async Task<int> Register(User user)
        {
            return await _repo.Create(user);
        }

        public async Task<int> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<int> Update(User user)
        {
            return await _repo.Update(user);
        }

        public async Task<AuthenticationResponse> Login(string usernameOrEmail, string password)
        {
            var user = await _repo.Read(usernameOrEmail, password);
            if (user != null) {
                var signingCredentials = _jwt.GetSigningCredentials();
                var claims = _jwt.GetClaims(user);
                var options = _jwt.GenerateTokenOptions(signingCredentials, claims);
                var token = new JwtSecurityTokenHandler().WriteToken(options);
                return new AuthenticationResponse(true, token, user);
            }
            return new AuthenticationResponse(false, null, null);
        }

        public async Task<bool> Exists(string usernameOrEmail, string password)
        {
            return await _repo.Exists(usernameOrEmail, password);
        }

        public async Task<bool> UserIsToken(string token, int userId)
        {
            var user = await _repo.Read(userId);
            return user != null && user.Username.Equals(_jwt.Validate(token));
        }

        public async Task<User> GetUser(string token)
        {
            var name = _jwt.Validate(token);
            if (name != null)
                return await _repo.Read(name);
            return null;
        }
    }
}


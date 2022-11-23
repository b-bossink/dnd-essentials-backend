using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Service.Notifications
{
	public class NotificationHub : Hub
	{
        private readonly int userId;
        public static readonly Dictionary<int, List<string>> connectionsPerUser = new Dictionary<int, List<string>>();

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            int disconnectedUser = 0;
            foreach (var userConnection in connectionsPerUser)
            {
                if (userConnection.Value.Contains(Context.ConnectionId))
                {
                    disconnectedUser = userConnection.Key;
                    break;
                }
            }
            connectionsPerUser.Remove(disconnectedUser);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task Identify(int userId) => await AssignConnectionToUser(userId);

        private async Task AssignConnectionToUser(int userId)
        {
            if (connectionsPerUser.ContainsKey(userId))
            {
                connectionsPerUser[userId].Add(Context.ConnectionId);
                return;
            }
            connectionsPerUser.Add(userId, new List<string>() { Context.ConnectionId });
        }
    }
}


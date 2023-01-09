using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Models;
using System.Collections.Generic;
using System.Linq;
using Service;
using Models.ViewModel;
using Service.Mapper;
using Repository;
using Microsoft.AspNetCore.SignalR;
using Service.Notifications;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ICRUDService<Campaign> _service;

        public CampaignController(IConfiguration config, IHubContext<NotificationHub> hub)
        {
            _service = new CampaignService
                (new Repository.CampaignRepo(config.GetConnectionString("localhostMSSQL")), hub);
        }

        // GET: api/campaign
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _service.GetAll();
            if (res != null)
            {
                return Ok(res.Select(c => ViewModelMapper.Map<GETCampaignViewModel>(c)));
            }
            return StatusCode(422, "Couldn't GET Character.");
        }

        // GET api/campaign/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _service.Get(id);
            if (res != null)
            {
                return Ok(ViewModelMapper.Map<GETCampaignViewModel>(res));
            }
            return NotFound();
        }

        // POST api/campaign
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CampaignViewModel model)
        {
            int res = await _service.Create(ViewModelMapper.Map<Campaign>(model));
            if (res < 1)
            {
                return StatusCode(422, "Something went wrong trying to POST character.");
            }
            return Ok();
        }

        // POST api/campaign/{id}?add-character={characterId}
        [HttpPost]
        [Route("{id}/add-character/{characterId}")]
        public async Task<IActionResult> AddCharacter(int id, int characterId)
        {
            var res = await ((CampaignService)_service).AddCharacter(id, characterId);
            if (res > 0)
                return Ok();
            else return StatusCode(422);
        }

        // PUT api/campaign
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] CampaignViewModel model, int id)
        {
            var campaign = ViewModelMapper.Map<Campaign>(model);
            campaign.ID = id;
            int res = await _service.Update(campaign);
            if (res < 1)
            {
                return StatusCode(422, "Something went wrong trying to UPDATE character.");
            }
            return Ok();
        }

        // DELETE api/campaign
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int res = await _service.Delete(id);
            if (res < 1)
            {
                return StatusCode(422, "Something went wrong trying to DELETE character.");
            }
            return Ok();
        }

    }
}


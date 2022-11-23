using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Models;
using Repository;
using Service.Notifications;

namespace Service
{
	public class CampaignService : CRUDService<Campaign>
	{
        private readonly NotificationService _notificationService;

        public CampaignService(ICRUDRepo<Campaign> repo, IHubContext<NotificationHub> hubContext = null) : base(repo)
        {
            _notificationService = new NotificationService(hubContext);
            if (_repo is CampaignRepo)
            {
                ((CampaignRepo)_repo).AddCharacterEvent += async (s, args) =>
                {
                    if (_notificationService == null || !args.success)
                    {
                        return;
                    }

                    await _notificationService.Notify(args.character.User.ID, Notification
                        .CharacterAddedToCampaign(args.campaign.User.Username, args.character.Name, args.campaign.Name));
                };
            }
        }

        public async Task<int> AddCharacter(int campaignId, int userId)
        {
            if (_repo is CampaignRepo campaignRepo)
            {
                return await campaignRepo.AddCharacter(campaignId, userId);
            }
            return 0;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace Service.Notifications
{
	public class NotificationService
	{
		private readonly IHubContext<NotificationHub> _ctx;

		public NotificationService(IHubContext<NotificationHub> hubContext)
		{
			_ctx = hubContext;
		}

		public async Task Notify(int userId, Notification notification)
		{
			var assiociatedConnections = NotificationHub.connectionsPerUser.FirstOrDefault(kvp => kvp.Key == userId).Value;
			if (assiociatedConnections != null)
            {
				await _ctx.Clients.Clients(assiociatedConnections).SendAsync("notify", notification);
            }
		}
	}
}


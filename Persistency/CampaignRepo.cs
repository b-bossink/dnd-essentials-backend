using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Repository;
using Repository.Connection;
using Repository.Event;

namespace Repository
{
	public class CampaignRepo : ICRUDRepo<Campaign>
    {
        public event EventHandler<AddCharacterToCampaignArgs> AddCharacterEvent;
        private readonly string _connection;
        public CampaignRepo(string connectionString)
        {
            _connection = connectionString;
        }

        public async Task<int> Create(Campaign campaign)
        {
            try
            {
                using (DatabaseContext ctx = new DatabaseContext(_connection))
                {
                    campaign.Characters = await RepoHelper.PopulateProperties<Character>(campaign.Characters, ctx.Characters);
                    ctx.Campaigns.Add(campaign);
                    return await ctx.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                using (DatabaseContext ctx = new DatabaseContext(_connection))
                {
                    Campaign c = await ctx.Campaigns.SingleOrDefaultAsync(c => c.ID == id);
                    if (c != null)
                    {
                        ctx.Campaigns.Remove(c);
                        return await ctx.SaveChangesAsync();
                    }
                }
                return 0;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        public async Task<Campaign> Read(int id)
        {
            try
            {
                using (DatabaseContext ctx = new DatabaseContext(_connection))
                {
                    return await ctx.Campaigns.Include(c => c.Characters).SingleOrDefaultAsync(c => c.ID == id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<IEnumerable<Campaign>> ReadAll()
        {
            try
            {
                using (DatabaseContext ctx = new DatabaseContext(_connection))
                {
                    return await ctx.Campaigns.Include(c => c.Characters).ToListAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Campaign[0];
            }
        }

        public async Task<int> Update(Campaign campaign)
        {
            try
            {
                using (DatabaseContext ctx = new DatabaseContext(_connection))
                {
                    var c = await ctx.Campaigns.SingleOrDefaultAsync(c => c.ID == campaign.ID);
                    if (c != null)
                    {
                        ctx.Entry(c).CurrentValues.SetValues(campaign);
                        return await ctx.SaveChangesAsync();
                    }
                    return 0;
                }
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        public async Task<int> AddCharacter(int campaignId, int characterId)
        {
            using (DatabaseContext ctx = new DatabaseContext(_connection))
            {
                var character = await ctx.Characters.SingleOrDefaultAsync(c => c.ID == characterId);
                var campaign = await ctx.Campaigns.SingleOrDefaultAsync(c => c.ID == campaignId);

                if (character == null || campaign == null)
                {
                    AddCharacterEvent.Invoke(this, new AddCharacterToCampaignArgs(character, campaign, false));
                    return 0;
                }

                if (campaign.Characters.Contains(character))
                {
                    AddCharacterEvent.Invoke(this, new AddCharacterToCampaignArgs(character, campaign, false));
                    return 0;
                }

                campaign.Characters.Add(character);
                int res = await ctx.SaveChangesAsync();
                if (res > 0)
                {
                    AddCharacterEvent.Invoke(this, new AddCharacterToCampaignArgs(character, campaign, true));
                }
                AddCharacterEvent.Invoke(this, new AddCharacterToCampaignArgs(character, campaign, false));
                return res;
            }
        }
    }
}


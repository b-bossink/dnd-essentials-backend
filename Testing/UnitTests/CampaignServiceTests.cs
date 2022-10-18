using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Service;

namespace Testing.UnitTests
{
    [TestClass]
    public class CampaignServiceTests
    {
        private static readonly List<Campaign> campaignTestData = new List<Campaign>() {
            new Campaign
            {
                ID = 3,
                Name = "My Awesome Campaign",
            },

            new Campaign
            {
                ID = 4,
                Name = "Some Test Campaign"
            },

            new Campaign
            {
                ID = 5,
                Name = "A campaign"
            }
        };

        [TestMethod]
        public void CreateCampaign()
        {
            // Assign
            var stub = new STUB<Campaign>(campaignTestData);
            CampaignService service = new CampaignService(stub);
            int changed;
            int expected = 1;
            Campaign c = new Campaign
            {
                ID = 1,
                Name = "A New Campaign"
            };

            // Act
            changed = service.Create(c).Result;

            // Assert
            Assert.AreEqual(expected, changed, "Unexpected amount of entries got changed.");
            var updatedData = stub.GetData();
            Assert.AreEqual(c, updatedData[updatedData.Count() - 1], "Newest campaign added to STUB does not equal character defined beforehand.");
        }

        [TestMethod]
        public void UpdateCampaign()
        {
            // Assign
            var stub = new STUB<Campaign>(campaignTestData);
            CampaignService service = new CampaignService(stub);
            int changed;
            int id = 4;
            int expected = 1;
            Campaign c = new Campaign
            {
                ID = id,
                Name = "Edited Campaign"
            };

            // Act
            changed = service.Update(c).Result;

            // Assert
            Assert.AreEqual(expected, changed);
            Assert.AreEqual(c, stub.GetData().SingleOrDefault(e => e.ID == id), "Campaign with given ID does not equal what has been defined before updating, or it doesn't exist.");
        }

        [TestMethod]
        public void ReadCampaign()
        {
            // Assign
            var stub = new STUB<Campaign>(campaignTestData);
            var service = new CampaignService(stub);
            int id = 5;
            Campaign expected = campaignTestData.SingleOrDefault(e => e.ID == id);
            Campaign result;

            // Act
            result = service.Get(id).Result;

            // Assert
            Assert.IsNotNull(expected, $"Campaign with id {id} doesn't exist in test data. Make sure it does before testing this method.");
            Assert.AreEqual(expected, result, "Expected campaign does not equal retrieved campaign.");
        }

        [TestMethod]
        public void ReadAllCampaigns()
        {
            // Assign
            var stub = new STUB<Campaign>(campaignTestData);
            var service = new CampaignService(stub);
            List<Campaign> expected = campaignTestData;
            IEnumerable<Campaign> result;

            // Act
            result = service.GetAll().Result;

            // Assert
            CollectionAssert.AreEqual(expected, result.ToList(), "Test data does not match retrieved data.");
        }

    }
}


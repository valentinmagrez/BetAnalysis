using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using UnibetService.UnibetApi.DTO;

namespace UnibetService.Tests.UnibetApi.DTO
{
    [TestFixture]
    public class BetDtoTest
    {
        [Test]
        public void ParseJson_ReturnCorrectDto()
        {
            var file = Path.Combine(TestContext.CurrentContext.WorkDirectory,"UnibetApi\\DTO", "betsHistory.json");
            var json = File.ReadAllText(file);
            var result = JsonConvert.DeserializeObject<BetsHistoryDto>(json);
        }
    }
}

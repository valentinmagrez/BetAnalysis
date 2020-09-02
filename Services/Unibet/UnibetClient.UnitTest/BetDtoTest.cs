using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using UnibetClient.DTO;

namespace UnibetClient.UnitTest
{
    [TestFixture]
    public class BetDtoTest
    {
        [Test]
        public void ParseJson_ReturnCorrectDto()
        {
            var file = Path.Combine(TestContext.CurrentContext.WorkDirectory, "betsHistory.json");
            var json = File.ReadAllText(file);
            var result = JsonConvert.DeserializeObject<BetsHistoryDto>(json);
        }
    }
}

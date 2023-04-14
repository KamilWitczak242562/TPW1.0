using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Logika;

namespace Testy
{
    [TestClass]
    public class LogicApiTest
    {
        [TestMethod]
        public void GeneralLogicApiTest()
        {
            AbstractLogicApi api = AbstractLogicApi.CreateApi();
            api.Enable(500, 250, 5, 25);
            Assert.AreEqual(5, api.GetBalls().Count);
            Assert.AreEqual(25, api.GetBalls()[0].Radius);
        }

    }
}
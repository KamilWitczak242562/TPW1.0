using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logika;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace Testy
{
    [TestClass()]
    public class ModelApiTest
    {
        [TestMethod()]
        public void GeneralModelApiTest()
        {
            AbstractLogicApi logicApi = AbstractLogicApi.CreateApi();
            AbstractModelApi modelApi = AbstractModelApi.CreateApi(logicApi);
            modelApi.Enable(10);
            ObservableCollection<BallUI> collection = modelApi.GetAllBalls();
            Assert.IsNotNull(collection);
            Assert.AreEqual(10, collection.Count);
            foreach (BallUI c in collection)
            {
                Assert.AreEqual(40, c.Radius);
            }
        }
    }
}

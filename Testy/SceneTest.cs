using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dane;

namespace Testy
{
    [TestClass]
    public class SceneTest
    {
        Scene scene = new Scene(500, 250, 5, 25);
        [TestMethod]
        public void GetterTest()
        {
            Assert.AreEqual(500, scene.Width);
            Assert.AreEqual(250, scene.Height);

            Assert.AreEqual(5, scene.Balls.Count);
            Assert.AreEqual(25, scene.Balls[0].Radius);

            Assert.IsFalse(scene.Enabled);
        }

        [TestMethod]
        public void SetterTest()
        {
            scene.Enabled = true;

            Assert.IsTrue(scene.Enabled);
        }
    }
}

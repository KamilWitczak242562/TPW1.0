using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dane;

namespace Testy
{
    [TestClass]
    public class BallTest
    {
        Ball ball = new Ball(5, 10, 15);

        [TestMethod]
        public void GetterTest()
        {
            Assert.AreEqual(5, ball.X);
            Assert.AreEqual(10, ball.Y);
            Assert.AreEqual(15, ball.Radius);
        }

        [TestMethod]
        public void SetterTest()
        {
            ball.X = 10;
            ball.Y = 15;
            ball.Radius = 20;

            Assert.AreEqual(10, ball.X);
            Assert.AreEqual(15, ball.Y);
            Assert.AreEqual(20, ball.Radius);
        }
    }
}
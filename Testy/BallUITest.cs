using System;
using Dane;
using Logika;
using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testy
{
    [TestClass()]
    public class BallUITest
    {
    [TestMethod]
    public void CircleTests()
        {
            Ball o = new Ball(3, 4, 5);
            BallLogic ball = new BallLogic(o);
            BallUI ballUI = new BallUI(ball);
            Assert.AreEqual(ball.X, ballUI.X);
            Assert.AreEqual(ball.Y, ballUI.Y);  
            Assert.AreEqual(ball.Radius, ballUI.Radius);
        }
    }
}

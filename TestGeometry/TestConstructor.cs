using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Planemetry;
using System.Collections.Generic;
using System.Drawing;

namespace TestGeometry
{   [TestClass]
    public class TestConstructor
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNull()
        {
            double? r = null;
            var obj = new Circle(r);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorWithNegativeNumber()
        {
            var obj = new Circle(-8);
        }
        [TestMethod]
        public void ConstructorNormal()
        {
            var obj = new Circle(8);
            double expected = 8;

            double actual = obj.GetRadius();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ConstructorCircleOnPoint()
        {
            Circle c = new Circle(4, 4);
            double expected = 5.6568542495;

            double actual = c.GetRadius();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ConstructorCircleOn2Points()
        {
            Circle c = new Circle(4, 4, 8, 2);
            double expected = 4.472135955;

            double actual = c.GetRadius();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTriangleIncorrectCountPoints()
        {
            List<PointF> p = new List<PointF>
            {
                new PointF(-3, 1),
                new PointF(4, 5)
            };
            var t = new Triangle(p);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Planemetry;
using System.Collections.Generic;
using System.Drawing;

namespace TestGeometry
{   [TestClass]
    public class RectangleTriangle
    {
        [TestMethod]
        public void RectangleTriangleOnBorders()
        {
            Triangle t = new Triangle(5, 4, 3);
            bool expected = true;

            bool actual = t.IsRightAngle();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RectangleTriangleOnPoint()
        {
            List<PointF> p = new List<PointF> { new PointF(-3,1),
                                              new PointF(4,5),
                                              new PointF(6,1.5f)};
            Triangle t = new Triangle(p);
            bool expected = true;

            bool actual = t.IsRightAngle();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotRectangleTriangle()
        {
            Triangle t = new Triangle(5, 5, 6);
            bool expected = false;

            bool actual = t.IsRightAngle();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotRectangleTriangleOnPoint()
        {
            List<PointF> p = new List<PointF> { new Point(-5, 2),
                                              new Point(2,5),
                                              new Point(9,0) };
            Triangle t = new Triangle(p);
            bool expected = false;

            bool actual = t.IsRightAngle();

            Assert.AreEqual(expected, actual);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Planemetry;
using System.Collections.Generic;
using System.Drawing;

namespace TestGeometry
{
    [TestClass]
    public class AreaTest
    {
        [TestMethod]
        public void AreaCircleZero()
        {
            Circle c = new Circle(0);
            double expected = 0;

            double actual=c.Area();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AreaCircleZeroInCenterCoord()
        {
            Circle c = new Circle(0, 0);
            double expected = 0;

            double actual= c.Area();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AreaCircleInCenterCoord()
        {
            Circle c = new Circle(4, 3);
            double expected = 78.5398163397;

            double actual = c.Area();

            Assert.AreEqual(expected, actual,"Expected area: "+expected+", actual: "+actual);
        }
        [TestMethod]
        public void AreaCircleNotCenterCoord()
        {
            Circle c = new Circle(0,5,2,5);
            double expected = 12.5663706144;

            double actual = c.Area();

            Assert.AreEqual(expected, actual, 0.000001);
        }
        [TestMethod]
        public void AreaOfIsoscelesTriancleFoundLessHip()
        {
            Triangle t = new Triangle(9, 9, 1);
            double expected = 4.4930501889;

            double actual = t.Area();

            Assert.AreEqual(expected, actual, 0.000001);
        }
        [TestMethod]
        public void AreaOfIsoscelesTriancleFoundSurpassesHip()
        {
            Triangle t = new Triangle(5,5,6);
            double expected = 12;

            double actual = t.Area();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AreaTriangleAtPoints()
        {
            List<PointF> p = new List<PointF> { new Point(-5, 2),
                                              new Point(2,5),
                                              new Point(9,0) };
            Triangle t = new Triangle(p);
            double expected = 28;

            double actual = t.Area();

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void AreaRectangleTriangleAtPoints()
        {
            List<PointF> p = new List<PointF> { new Point(0, 2),
                                              new Point(0,4),
                                              new PointF(6,3.5f) };
            Triangle t = new Triangle(p);
            double expected = 6;

            double actual = t.Area();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AreaOfRectangleTriangle()
        {
            Triangle t = new Triangle(5, 4, 3);
            double expected = 6;

            double actual = t.Area();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AreaZeroTriangle()
        {
            Triangle t = new Triangle(5, 4, 0);
            double expected = 0;

            double actual = t.Area();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AreaZeroTriangleAtPoints()
        {
            List<PointF> p = new List<PointF> { new PointF(-5, 2),
                                              new PointF(2,5),
                                              new PointF(6,6.7142867f) };
            Triangle t = new Triangle(p);
            double expected = 0;

            double actual = t.Area();

            Assert.AreEqual(expected, actual,0.00001);

        }
    }
}

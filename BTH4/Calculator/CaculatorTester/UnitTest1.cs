using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BT_Calculator;
namespace CaculatorTester
{
    [TestClass]
    public class UnitTest1
    {
        private Caculation Ca;
        [TestInitialize]
        public void Setup()
        {
           Ca = new Caculation(5, 6);
        }
        [TestMethod]
        public void TestCong()
        {
            Assert.AreEqual(Ca.Execute("+"), 11);
        }
        [TestMethod]
        public void TestTru()
        {
            Assert.AreEqual(Ca.Execute("-"), -1);
        }
        [TestMethod]
        public void TestNhan()
        {
            Assert.AreEqual(Ca.Execute("*"), 30);
        }
        [TestMethod]
        public void TestChia()
        {
            Assert.AreEqual(Ca.Execute("/"),0.83 );
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod1()
        {
           Caculation ca2 = new Caculation(5,0);
           ca2.Execute("/");
        }
    }
}

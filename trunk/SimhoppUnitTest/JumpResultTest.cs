using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.RegularExpressions;

using Simhopp.Model;

namespace SimhoppUnitTest
{
    [TestFixture]
    class JumpResultTest
    {
        /// <summary>
        /// Testing the default constructor and how it implements new JumpResult-objects.
        /// </summary>
        [Test]
        public void DefaultConstructorTest()
        {
            JumpResult jr = new JumpResult();
            string s = jr.TrickName;
            Assert.That(s, Is.StringMatching(""));
            double point = jr.GetJudgePoint(0);
            Assert.That(point, Is.EqualTo(0));
            point = jr.GetJudgePoint(1);
            Assert.That(point, Is.EqualTo(0));
            point = jr.GetJudgePoint(2);
            Assert.That(point, Is.EqualTo(0));
            point = jr.GetJudgePoint(3);
            Assert.That(point, Is.EqualTo(0));
            point = jr.GetJudgePoint(4);
            Assert.That(point, Is.EqualTo(0));
            point = jr.GetJudgePoint(5);
            Assert.That(point, Is.EqualTo(0));
            point = jr.GetJudgePoint(6);
            Assert.That(point, Is.EqualTo(0));
            double res = jr.SumJudgePoints;
            Assert.That(res, Is.EqualTo(0));
        }

        /// <summary>
        /// Testing the constructor that takes parameters and creates a JumpResult-objekt.
        /// </summary>
        [Test]
        public void ConstuctorWithParametersTest()
        {
            JumpResult jr = new JumpResult("flip", 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0);
            string s = jr.TrickName;
            Assert.That(s, Is.StringMatching("flip"));
            /*double point = jr.GetJudgePoint(0);
            Assert.That(point, Is.EqualTo(1.0).Within(0.005));
            point = jr.GetJudgePoint(1);
            Assert.That(point, Is.EqualTo(2.0).Within(0.005));
            point = jr.GetJudgePoint(2);
            Assert.That(point, Is.EqualTo(3.0).Within(0.005));
            point = jr.GetJudgePoint(3);
            Assert.That(point, Is.EqualTo(4.0).Within(0.005));
            point = jr.GetJudgePoint(4);
            Assert.That(point, Is.EqualTo(5.0).Within(0.005));
            point = jr.GetJudgePoint(5);
            Assert.That(point, Is.EqualTo(6.0).Within(0.005));
            point = jr.GetJudgePoint(6);
            Assert.That(point, Is.EqualTo(7.0).Within(0.005));*/
            double res = jr.SumJudgePoints;
            Assert.That(res, Is.EqualTo(20.0).Within(0.005));
        }

        /// <summary>
        /// Test to validate that the CalculateResult method works.
        /// </summary>
        [Test]
        public void CalculateRestultTest()
        {
            JumpResult jr = new JumpResult();
            jr.SetJudgePoint(0, 1.0);
            jr.SetJudgePoint(1, 2.0);
            jr.SetJudgePoint(2, 3.0);
            jr.SetJudgePoint(3, 4.0);
            jr.SetJudgePoint(4, 5.0);
            jr.SetJudgePoint(5, 6.0);
            jr.SetJudgePoint(6, 7.0);
            jr.CalculateResult();
            double p = jr.SumJudgePoints;
            Assert.That(p, Is.EqualTo(20).Within(0.05));
        }

        /// <summary>
        /// Validates the SetJudgePoint method.
        /// </summary>
        [Test]
        public void SetResultTest()
        {
            JumpResult jr = new JumpResult();
            jr.SetJudgePoint(0, 1.0);
            double point = jr.GetJudgePoint(0);
            Assert.That(point, Is.EqualTo(1.0).Within(0.05));
            jr.SetJudgePoint(1, 2.0);
            point = jr.GetJudgePoint(1);
            Assert.That(point, Is.EqualTo(2.0).Within(0.05));
            jr.SetJudgePoint(2, 3.0);
            point = jr.GetJudgePoint(2);
            Assert.That(point, Is.EqualTo(3.0).Within(0.05));
            jr.SetJudgePoint(3, 4.0);
            point = jr.GetJudgePoint(3);
            Assert.That(point, Is.EqualTo(4.0).Within(0.05));
            jr.SetJudgePoint(4, 5.0);
            point = jr.GetJudgePoint(4);
            Assert.That(point, Is.EqualTo(5.0).Within(0.05));
            jr.SetJudgePoint(5, 6.0);
            point = jr.GetJudgePoint(5);
            Assert.That(point, Is.EqualTo(6.0).Within(0.05));
            jr.SetJudgePoint(6, 7.0);
            point = jr.GetJudgePoint(6);
            Assert.That(point, Is.EqualTo(7.0).Within(0.05));
            Assert.That(point, Is.Not.EqualTo(5.0).Within(0.05));
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NUnitTestDemo
{
    public class ParameterizedTests
    {
        [Should("Pass")]
        [TestCase(2, 2, 4)]
        [TestCase(0, 5, 5)]
        [TestCase(31, 11, 42)]
        public void TestCaseSucceeds(int a, int b, int sum)
        {
            Assert.That(a + b, Is.EqualTo(sum));
        }

        [Should("Pass")]
        [TestCase(2, 2, ExpectedResult = 4)]
        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(31, 11, ExpectedResult = 42)]
        public int TestCaseSucceeds_Result(int a, int b)
        {
            return a + b;
        }

        [Should("Fail")]
        [TestCase(31, 11, 99)]
        public void TestCaseFails(int a, int b, int sum)
        {
            Assert.That(a + b, Is.EqualTo(sum));
        }

        [TestCase(31, 11, ExpectedResult = 99), Should("Fail")]
        public int TestCaseFails_Result(int a, int b)
        {
            return a + b;
        }

        [TestCase(31, 11), Should("Inconclusive")]
        public void TestCaseIsInconclusive(int a, int b)
        {
            Assert.Inconclusive("Inconclusive test case");
        }

        [Ignore("Ignored test"), Should("Ignore")]
        [TestCase(31, 11)]
        public void TestCaseIsIgnored_Attribute(int a, int b)
        {
        }

        [TestCase(31, 11, Ignore = "Ignoring this"), Should("Ignore")]
        public void TestCaseIsIgnored_Property(int a, int b)
        {
        }

        [TestCase(31, 11), Should("Ignore")]
        public void TestCaseIsIgnored_Assert(int a, int b)
        {
            Assert.Ignore("Ignoring this test case");
        }

        [TestCase(31, 11), Should("Error")]
        public void TestCaseThrowsException(int a, int b)
        {
            throw new Exception("Exception from test case");
        }

        [TestCase(42, TestName="AlternateTestName"), Should("Pass")]
        public void TestCaseWithAlternateName(int x)
        {
        }
    }
}

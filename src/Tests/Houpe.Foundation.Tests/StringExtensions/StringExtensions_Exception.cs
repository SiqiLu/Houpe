// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_Exception.cs
// CreatedAt        : 2021-06-07
// LastModifiedAt   : 2021-06-27
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFirst_ArgumentNullException() => _ = ((string)null).GetFirst();

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetFirst_ArgumentOutOfRangeException()
        {
            int count = new Randomizer().Int(int.MinValue, -1);
            _ = "Hello World!".GetFirst(count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetLast_ArgumentNullException() => _ = ((string)null).GetLast();

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetLast_ArgumentOutOfRangeException()
        {
            int count = new Randomizer().Int(int.MinValue, -1);
            _ = "Hello World!".GetLast(count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_ArgumentNullException()
        {
            string target = new Randomizer().String(1, 10);
            _ = ((string)null).Remove(target);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_Target_ArgumentNullException()
        {
            string s = new Randomizer().String(1, 10);
            _ = s.Remove(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Remove_Target_ArgumentException()
        {
            string s = new Randomizer().String(1, 10);
            _ = s.Remove(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SubString_ArgumentNullException()
        {
            int start = new Randomizer().Number(0, int.MaxValue);
            _ = ((string)null).SubString(start);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SubString_StartNeg_ArgumentOutOfRangeException()
        {
            int start = new Randomizer().Int(int.MinValue, -1);
            _ = "Hello World!".SubString(start);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SubString_Count_ArgumentOutOfRangeException()
        {
            int count = new Randomizer().Int(int.MinValue, -1);
            _ = "Hello World!".SubString(1, count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SeparatePascalCase_ArgumentNullException() => _ = ((string)null).SeparatePascalCase();
    }
}

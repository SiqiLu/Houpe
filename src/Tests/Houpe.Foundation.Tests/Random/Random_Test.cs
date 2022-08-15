// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : Random_Test.cs
// CreatedAt        : 2022-08-07
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class Random_Test
    {
        [TestMethod]
        public void Random_Should()
        {
            Random random = new Random();
            int number1 = random.Next();
            int number2 = random.Next(100);
            int number3 = random.Next(100, 200);
            double number4 = random.NextDouble();

            byte[] buffer1 = new byte[10];
            Span<byte> buffer2 = new byte[10];

            random.NextBytes(buffer1);
            random.NextBytes(buffer2);

            Assert.IsTrue(number1 >= 0);
            Assert.IsTrue(number2 >= 0 && number2 < 100);
            Assert.IsTrue(number3 >= 100 && number3 < 200);
            Assert.IsTrue(number4 >= 0 && number4 < 1);

            Assert.IsTrue(buffer1.Length == 10);
            Assert.IsTrue(buffer2.Length == 10);
        }
    }
}

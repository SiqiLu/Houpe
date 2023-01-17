// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IntExtensions_Times_Test.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class IntExtensions_Times_Test
{
    [TestMethod]
    public void Times_Input10_Should()
    {
        int input = 10;

        int n = 0;

        _ = input.Times().Do(() => n++);

        Assert.AreEqual(10, n);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Times_InputMinValue_Exception()
    {
        int input = int.MinValue;
        int i = 0;
        _ = input.Times().Do(() => i++);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Times_InputNeg_Exception()
    {
        int input = -1;
        int i = 0;
        _ = input.Times().Do(() => i++);
    }
}

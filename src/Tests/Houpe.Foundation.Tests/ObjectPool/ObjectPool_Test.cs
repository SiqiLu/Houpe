// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ObjectPool_Test.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

#pragma warning disable CS8625

namespace Houpe.Foundation.Tests;

[TestClass]
public class ObjectPool_Test
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ObjectPool_Test_ArgumentNullException() => _ = new ObjectPool<StringBuilder>(null);

    [TestMethod]
    public async Task ObjectPool_Test_Should()
    {
        ObjectPool<StringBuilder> pool = new ObjectPool<StringBuilder>(() => new StringBuilder());

        StringBuilder sb1 = pool.GetObject();
        StringBuilder sb2 = pool.GetObject();

        pool.PutObject(sb1);

        StringBuilder sb3 = pool.GetObject();

        Assert.IsFalse(ReferenceEquals(sb1, sb2));
        Assert.IsTrue(ReferenceEquals(sb1, sb3));

        StringBuilder sb4 = new StringBuilder();
        StringBuilder sb5 = new StringBuilder();
        StringBuilder sb6 = new StringBuilder();
        StringBuilder sb7 = new StringBuilder();

        pool.Using(sb =>
        {
            _ = sb.Append("Hello");
            sb4 = sb;
        });

        await pool.UsingAsync(async sb =>
        {
            await Task.Delay(1);
            _ = sb.Append("World");
            sb5 = sb;
        });

        _ = await pool.UsingAsync(async sb =>
        {
            await Task.Delay(1);
            _ = sb.Append("World");
            sb6 = sb;
            return sb.ToString();
        });

        pool.PutObject(sb2);

        pool.Using(sb =>
        {
            _ = sb.Append("Hello");
            sb7 = sb;
        });

        Assert.IsTrue(ReferenceEquals(sb4, sb5));
        Assert.IsTrue(ReferenceEquals(sb4, sb6));
        Assert.IsTrue(ReferenceEquals(sb5, sb6));
        Assert.IsTrue(ReferenceEquals(sb2, sb7));
    }
}

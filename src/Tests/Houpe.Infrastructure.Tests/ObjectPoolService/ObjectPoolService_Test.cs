// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Infrastructure.Tests
// File             : ObjectPoolService_Test.cs
// CreatedAt        : 2022-08-07
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Infrastructure.Tests
{
    [TestClass]
    public class ObjectPoolService_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ObjectPoolService_Test_ArgumentNullException() => _ = new ObjectPoolService<StringBuilder>(null);

        [TestMethod]
        public async Task ObjectPoolService_Test_Should()
        {
            IObjectPoolService<StringBuilder> pool = new ObjectPoolService<StringBuilder>(() => new StringBuilder());

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
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : TaskExtensions_Should.cs
// CreatedAt        : 2021-07-01
// LastModifiedAt   : 2022-08-01
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class TaskExtensions_Should
    {
        [TestMethod]
        [SuppressMessage("Style", "IDE0039:Use local function", Justification = "<Pending>")]
        public void Forget_Should()
        {
            Task t = new Task<string>(() => "");
            t.RunSynchronously();
            t.Forget();

            Action<Exception> handler = _ => { };

            Task exceptionTask = new Task<string>(() => throw new ApplicationException("Test exception"));
            exceptionTask.RunSynchronously();
            exceptionTask.Forget();
            exceptionTask.Forget();
            exceptionTask.Forget(handler);
        }

        [TestMethod]
        public void GetResult_Should()
        {
            Task<string> t = new Task<string>(() => "Hello World!");

            t.RunSynchronously();

            Assert.AreEqual("Hello World!", t.GetResult());
        }
    }
}

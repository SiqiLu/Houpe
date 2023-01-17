// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : TaskExtensions_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Houpe.Foundation.Tests;

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

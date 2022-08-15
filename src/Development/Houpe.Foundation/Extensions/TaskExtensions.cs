// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : TaskExtensions.cs
// CreatedAt        : 2021-07-01
// LastModifiedAt   : 2021-07-01
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Threading.Tasks;

namespace Houpe.Foundation
{
    /// <summary>
    ///     <see cref="System.Threading.Tasks.Task" /> 的扩展类。
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        ///     配置指定的 <see cref="System.Threading.Tasks.Task" /> 实例不要在原始上下文中继续延续任务。
        /// </summary>
        /// <param name="task">指定的 <see cref="System.Threading.Tasks.Task" /> 的实例。</param>
        /// <param name="exceptionHandler">用于处理 <see cref="System.Threading.Tasks.Task" /> 执行中遇到的异常的处理方法。</param>
        public static async void Forget(this Task task, Action<Exception> exceptionHandler = null)
        {
            try
            {
                await task.ConfigureAwait(false);
            }
            catch (Exception e)
            {
                exceptionHandler?.Invoke(e);
            }
        }

        /// <summary>
        ///     更好的使用 Task.Result 的方法。
        /// </summary>
        /// <typeparam name="T">Task结果的类型。</typeparam>
        /// <param name="task"><see cref="System.Threading.Tasks.Task{T}" /> 的实例。</param>
        /// <remarks>
        ///     The rationale for GetAwaiter().GetResult() instead of .Result
        ///     is presented at https://github.com/aspnet/Security/issues/59.
        /// </remarks>
        /// <returns>Task的结果。</returns>
        public static T GetResult<T>(this Task<T> task) => task.GetAwaiter().GetResult();
    }
}

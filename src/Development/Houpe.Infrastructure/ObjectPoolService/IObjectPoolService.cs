// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Infrastructure
// File             : IObjectPoolService.cs
// CreatedAt        : 2022-08-07
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Threading.Tasks;

namespace Houpe.Infrastructure
{
    /// <summary>
    ///     IObjectPoolService
    /// </summary>
    public interface IObjectPoolService<T>
    {
        /// <summary>
        ///     从对象池中获取一个对象。
        /// </summary>
        /// <returns>指定要获取的对象。</returns>
        public T GetObject();

        /// <summary>
        ///     向对象池中添加一个对象。
        /// </summary>
        /// <param name="item">指定要添加的对象。</param>
        public void PutObject(T item);

        /// <summary>
        ///     针对对象池中的一个对象，执行指定委托。
        /// </summary>
        /// <param name="action">指定的委托。</param>
        public void Using(Action<T> action);

        /// <summary>
        ///     针对对象池中的一个对象，执行指定委托。
        /// </summary>
        /// <param name="func">指定的委托。</param>
        public Task UsingAsync(Func<T, Task> func);

        /// <summary>
        ///     针对对象池中的一个对象，执行指定委托。
        /// </summary>
        /// <typeparam name="TResult">委托的结果的类型。</typeparam>
        /// <param name="func">指定的委托。</param>
        /// <returns>委托的结果。></returns>
        public Task<TResult> UsingAsync<TResult>(Func<T, Task<TResult>> func);
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Infrastructure
// File             : ObjectPoolService.cs
// CreatedAt        : 2022-08-07
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Threading.Tasks;
using Houpe.Foundation;

namespace Houpe.Infrastructure
{
    /// <summary>
    ///     ObjectPoolService
    /// </summary>
    public class ObjectPoolService<T> : IObjectPoolService<T>
    {
        private readonly ObjectPool<T> _objectPool;

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="objectGenerator">类型初始化器。</param>
        public ObjectPoolService(Func<T> objectGenerator)
        {
            if (objectGenerator == null)
            {
                throw new ArgumentNullException(nameof(objectGenerator));
            }

            _objectPool = new ObjectPool<T>(objectGenerator);
        }

        #region IObjectPoolService<T> Members

        /// <summary>
        ///     从对象池中获取一个对象。
        /// </summary>
        /// <returns>指定要获取的对象。</returns>
        public T GetObject() => _objectPool.GetObject();

        /// <summary>
        ///     向对象池中添加一个对象。
        /// </summary>
        /// <param name="item">指定要添加的对象。</param>
        public void PutObject(T item) => _objectPool.PutObject(item);

        /// <summary>
        ///     针对对象池中的一个对象，执行指定委托。
        /// </summary>
        /// <param name="action">指定的委托。</param>
        public void Using(Action<T> action) => _objectPool.Using(action);

        /// <summary>
        ///     针对对象池中的一个对象，执行指定委托。
        /// </summary>
        /// <param name="func">指定的委托。</param>
        public async Task UsingAsync(Func<T, Task> func) => await _objectPool.UsingAsync(func);

        /// <summary>
        ///     针对对象池中的一个对象，执行指定委托。
        /// </summary>
        /// <typeparam name="TResult">委托的结果的类型。</typeparam>
        /// <param name="func">指定的委托。</param>
        /// <returns>委托的结果。></returns>
        public async Task<TResult> UsingAsync<TResult>(Func<T, Task<TResult>> func) => await _objectPool.UsingAsync(func);

        #endregion
    }
}

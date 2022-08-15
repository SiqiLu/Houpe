// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : ObjectPool.cs
// CreatedAt        : 2020-11-28
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Houpe.Foundation
{
    /// <summary>
    ///     ObjectPool
    /// </summary>
    /// <typeparam name="T">对象池中的类型。</typeparam>
    public class ObjectPool<T>
    {
        private readonly Func<T> _objectGenerator;
        private readonly ConcurrentStack<T> _objects;

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="objectGenerator">类型初始化器。</param>
        public ObjectPool(Func<T> objectGenerator)
        {
            _objects = new ConcurrentStack<T>();
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
        }

        /// <summary>
        ///     从对象池中获取一个对象。
        /// </summary>
        /// <returns>指定要获取的对象。</returns>
        public T GetObject() => _objects.TryPop(out T item) ? item : _objectGenerator();

        /// <summary>
        ///     向对象池中添加一个对象。
        /// </summary>
        /// <param name="item">指定要添加的对象。</param>
        public void PutObject(T item) => _objects.Push(item);

        /// <summary>
        ///     针对对象池中的一个对象，执行指定委托。
        /// </summary>
        /// <param name="action">指定的委托。</param>
        public void Using(Action<T> action)
        {
            T t = GetObject();
            try
            {
                action(t);
            }
            finally
            {
                PutObject(t);
            }
        }

        /// <summary>
        ///     针对对象池中的一个对象，执行指定委托。
        /// </summary>
        /// <param name="func">指定的委托。</param>
        public async Task UsingAsync(Func<T, Task> func)
        {
            T t = GetObject();
            try
            {
                await func(t);
            }
            finally
            {
                PutObject(t);
            }
        }

        /// <summary>
        ///     针对对象池中的一个对象，执行指定委托。
        /// </summary>
        /// <typeparam name="TResult">委托的结果的类型。</typeparam>
        /// <param name="func">指定的委托。</param>
        /// <returns>委托的结果。></returns>
        public async Task<TResult> UsingAsync<TResult>(Func<T, Task<TResult>> func)
        {
            T t = GetObject();
            try
            {
                TResult result = await func(t);
                return result;
            }
            finally
            {
                PutObject(t);
            }
        }
    }
}

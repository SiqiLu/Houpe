// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : InvalidEnumCodeException.cs
// CreatedAt        : 2020-10-24
// LastModifiedAt   : 2022-08-06
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;

namespace Houpe.Foundation
{
    /// <summary>
    ///     当使用错误的枚举代码构建枚举值时引发的异常。
    /// </summary>
    [Serializable]
    public class InvalidEnumCodeException : InvalidOperationException
    {
        /// <summary>
        ///     使用当时引起异常的错误枚举代码、枚举类型和默认的错误消息初始化 <see cref="InvalidEnumCodeException"/> 类的新实例。
        ///     默认的错误消息：“Invalid code "{0}" for enum type "{1}".”
        /// </summary>
        /// <param name="initCode">错误枚举代码。</param>
        /// <param name="enumType">枚举类型。</param>
        public InvalidEnumCodeException(int initCode, Type enumType) : base(Resource.InvalidOperation_InvalidEnumCode)
        {
            InitCode = initCode;
            EnumType = enumType;
        }

        /// <summary>
        ///     使用当时引起异常的错误枚举代码、枚举类型和指定的错误消息初始化 <see cref="InvalidEnumCodeException"/> 类的新实例。
        /// </summary>
        /// <param name="initCode">错误枚举代码。</param>
        /// <param name="enumType">枚举类型。</param>
        /// <param name="message">指定的描述错误的消息。</param>
        public InvalidEnumCodeException(int initCode, Type enumType, string message) : base(message)
        {
            InitCode = initCode;
            EnumType = enumType;
        }

        /// <summary>
        ///     使用当时引起异常的错误枚举代码、枚举类型、指定的异常信息和导致当前异常的内部异常初始化 <see cref="InvalidEnumCodeException"/> 类的新实例。
        /// </summary>
        /// <param name="initCode">错误枚举代码。</param>
        /// <param name="enumType">枚举类型。</param>
        /// <param name="message">指定的描述错误的消息。</param>
        /// <param name="innerException">导致当前异常的内部异常。</param>
        public InvalidEnumCodeException(int initCode, Type enumType, string message, Exception innerException) : base(message, innerException)
        {
            InitCode = initCode;
            EnumType = enumType;
        }

        /// <summary>
        ///     异常发生的枚举类型。
        /// </summary>
        public Type EnumType { get; }

        /// <summary>
        ///     错误枚举代码。
        /// </summary>
        public int InitCode { get; }

        /// <summary>
        ///     错误消息字符串。
        /// </summary>
        public override string Message => base.Message.FormatWithValues(InitCode, EnumType.FullName);
    }
}

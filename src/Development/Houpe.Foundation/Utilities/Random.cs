// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : Random.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Houpe.Foundation;

/// <summary>
///     Thread-safe random number generator.
///     Has same API as System.Random but is thread safe, similar to the implementation by Steven Toub: http://blogs.msdn.com/b/pfxteam/archive/2014/10/20/9434171.aspx
/// </summary>
public class Random
{
    private static readonly RandomNumberGenerator s_globalCryptoProvider = RandomNumberGenerator.Create();

    [ThreadStatic]
    private static System.Random? s_random;

    /// <summary>
    ///     Returns a non-negative random integer.
    /// </summary>
    /// <returns>A 32-bit signed integer that is greater than or equal to 0 and less than <see cref="int.MaxValue" />.</returns>
    public int Next() => GetRandom().Next();

    /// <summary>
    ///     Returns a non-negative random integer that is less than the specified maximum.
    /// </summary>
    /// <param name="maxValue">The exclusive upper bound of the random number to be generated. <paramref name="maxValue" /> must be greater than or equal to 0.</param>
    /// <returns>
    ///     A 32-bit signed integer that is greater than or equal to 0, and less than <paramref name="maxValue" />;
    ///     that is, the range of return values ordinarily includes 0 but not maxValue. However, if maxValue equals 0, maxValue is returned.
    /// </returns>
    public int Next(int maxValue) => GetRandom().Next(maxValue);

    /// <summary>
    ///     Returns a random integer that is within a specified range.
    /// </summary>
    /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned. <paramref name="maxValue" /> must be greater than or equal to minValue.</param>
    /// <returns>
    ///     A 32-bit signed integer greater than or equal to <paramref name="minValue" /> and less than <paramref name="maxValue" />;
    ///     that is, the range of return values includes <paramref name="minValue" /> but not <paramref name="maxValue" />.
    ///     If <paramref name="minValue" /> equals <paramref name="maxValue" />, <paramref name="minValue" /> is returned.
    /// </returns>
    public int Next(int minValue, int maxValue) => GetRandom().Next(minValue, maxValue);

    /// <summary>
    ///     Fills the elements of a specified array of bytes with random numbers.
    /// </summary>
    /// <param name="buffer">The array to be filled with random numbers.</param>
    /// <exception cref="ArgumentNullException"><paramref name="buffer" /> is <c>null</c>.</exception>
    public void NextBytes(byte[] buffer) => GetRandom().NextBytes(buffer);

    /// <summary>
    ///     Fills the elements of a specified span of bytes with random numbers.
    /// </summary>
    /// <param name="buffer">The array to be filled with random numbers.</param>
    /// <remarks>Each element of the span of bytes is set to a random number greater than or equal to 0 and less than or equal to <see cref="byte.MaxValue" />.</remarks>
    public void NextBytes(Span<byte> buffer) => GetRandom().NextBytes(buffer);

    /// <summary>
    ///     Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    /// </summary>
    /// <returns>A double-precision floating point number that is greater than or equal to 0.0, and less than 1.0.</returns>
    public double NextDouble() => GetRandom().NextDouble();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static System.Random GetRandom()
    {
        if (s_random == null)
        {
            byte[] buffer = new byte[4];
            s_globalCryptoProvider.GetBytes(buffer);
            s_random = new System.Random(BitConverter.ToInt32(buffer, 0));
        }

        return s_random;
    }
}

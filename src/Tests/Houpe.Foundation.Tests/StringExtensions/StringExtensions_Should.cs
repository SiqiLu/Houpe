// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus;
using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

#pragma warning disable CS8625

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_Should
{
    [TestMethod]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void GetFirst_Should()
    {
        string testData = "Hello World!";

        Assert.AreEqual("H", testData.GetFirst());
        Assert.AreEqual("He", testData.GetFirst(2));
        Assert.AreEqual("Hel", testData.GetFirst(3));
        Assert.AreEqual("Hell", testData.GetFirst(4));
        Assert.AreEqual("Hello", testData.GetFirst(5));
        Assert.AreEqual("Hello ", testData.GetFirst(6));
        Assert.AreEqual("Hello W", testData.GetFirst(7));
        Assert.AreEqual("Hello Wo", testData.GetFirst(8));
        Assert.AreEqual("Hello Wor", testData.GetFirst(9));
        Assert.AreEqual("Hello Worl", testData.GetFirst(10));
        Assert.AreEqual("Hello World", testData.GetFirst(11));
        Assert.AreEqual("Hello World!", testData.GetFirst(12));
        Assert.AreEqual("Hello World!", testData.GetFirst(13));
        Assert.AreEqual("Hello World!", testData.GetFirst(int.MaxValue));

        // 如果取全部长度，就会获得原字符串
        Assert.AreEqual(testData, testData.GetFirst(testData.Length));

        // String.Empty 无论获取多少长度，都会获得 String.Empty
        Assert.AreEqual(string.Empty, string.Empty.GetFirst());
        Assert.AreEqual(string.Empty, string.Empty.GetFirst(2));
        Assert.AreEqual(string.Empty, string.Empty.GetFirst(10));
        Assert.AreEqual(string.Empty, string.Empty.GetFirst(int.MaxValue));

        Randomizer r = new Randomizer();

        100.Times().Do(() =>
        {
            string testString = r.String(1, 100);
            int testCount = r.Number();
            string actual = testString.GetFirst(testCount);
            string expected = testString.SubString(0, testCount);
            Assert.AreEqual(expected, actual);
        });
    }

    [TestMethod]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void GetLast_Should()
    {
        string testData = "Hello World!";

        Assert.AreEqual("!", testData.GetLast());
        Assert.AreEqual("d!", testData.GetLast(2));
        Assert.AreEqual("ld!", testData.GetLast(3));
        Assert.AreEqual("rld!", testData.GetLast(4));
        Assert.AreEqual("orld!", testData.GetLast(5));
        Assert.AreEqual("World!", testData.GetLast(6));
        Assert.AreEqual(" World!", testData.GetLast(7));
        Assert.AreEqual("o World!", testData.GetLast(8));
        Assert.AreEqual("lo World!", testData.GetLast(9));
        Assert.AreEqual("llo World!", testData.GetLast(10));
        Assert.AreEqual("ello World!", testData.GetLast(11));
        Assert.AreEqual("Hello World!", testData.GetLast(12));
        Assert.AreEqual("Hello World!", testData.GetLast(13));
        Assert.AreEqual("Hello World!", testData.GetLast(int.MaxValue));

        // 如果取全部长度，就会获得原字符串
        Assert.AreEqual(testData, testData.GetLast(testData.Length));

        // String.Empty 无论获取多少长度，都会获得 String.Empty
        Assert.AreEqual(string.Empty, string.Empty.GetLast());
        Assert.AreEqual(string.Empty, string.Empty.GetLast(2));
        Assert.AreEqual(string.Empty, string.Empty.GetLast(10));
        Assert.AreEqual(string.Empty, string.Empty.GetLast(int.MaxValue));

        Randomizer r = new Randomizer();

        100.Times().Do(() =>
        {
            string testString = r.String(1, 100);
            int testCount = r.Number();

            int start = testString.Length - testCount;
            if (start < 0)
            {
                start = 0;
            }

            string actual = testString.GetLast(testCount);
            string expected = testString.SubString(start, testCount);
            Assert.AreEqual(expected, actual);
        });
    }

    [TestMethod]
    public void IsNotNullOrEmpty_False_Should()
    {
        Assert.IsFalse(((string?)null).IsNotNullOrEmpty());
        Assert.IsFalse(string.Empty.IsNotNullOrEmpty());
        Assert.IsFalse("".IsNotNullOrEmpty());
    }

    [TestMethod]
    public void IsNotNullOrEmpty_True_Should()
    {
        Assert.IsTrue("a".IsNotNullOrEmpty());
        Assert.IsTrue(" ".IsNotNullOrEmpty());
    }

    [TestMethod]
    public void IsNotNullOrWhiteSpace_False_Should()
    {
        Assert.IsFalse(((string?)null).IsNotNullOrWhiteSpace());
        Assert.IsFalse(string.Empty.IsNotNullOrWhiteSpace());
        Assert.IsFalse("".IsNotNullOrWhiteSpace());
        Assert.IsFalse(" ".IsNotNullOrWhiteSpace());
        Assert.IsFalse("  ".IsNotNullOrWhiteSpace());
    }

    [TestMethod]
    public void IsNotNullOrWhiteSpace_True_Should() => Assert.IsTrue("a".IsNotNullOrWhiteSpace());

    [TestMethod]
    public void IsNullOrEmpty_False_Should()
    {
        Assert.IsFalse("a".IsNullOrEmpty());
        Assert.IsFalse(" ".IsNullOrEmpty());
    }

    [TestMethod]
    public void IsNullOrEmpty_True_Should()
    {
        Assert.IsTrue(((string?)null).IsNullOrEmpty());
        Assert.IsTrue(string.Empty.IsNullOrEmpty());
        Assert.IsTrue("".IsNullOrEmpty());
    }

    [TestMethod]
    public void IsNullOrWhiteSpace_False_Should() => Assert.IsFalse("a".IsNullOrWhiteSpace());

    [TestMethod]
    public void IsNullOrWhiteSpace_True_Should()
    {
        Assert.IsTrue(((string?)null).IsNullOrWhiteSpace());
        Assert.IsTrue(string.Empty.IsNullOrWhiteSpace());
        Assert.IsTrue("".IsNullOrWhiteSpace());
        Assert.IsTrue(" ".IsNullOrWhiteSpace());
        Assert.IsTrue("  ".IsNullOrWhiteSpace());
    }

    [TestMethod]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void Remove_Should()
    {
        string test = "abcde";

        Assert.AreEqual("abcde", test.Remove(" "));
        Assert.AreEqual("bcde", test.Remove("a"));
        Assert.AreEqual("acde", test.Remove("b"));
        Assert.AreEqual("abde", test.Remove("c"));
        Assert.AreEqual("abce", test.Remove("d"));
        Assert.AreEqual("abcd", test.Remove("e"));
        Assert.AreEqual("cde", test.Remove("ab"));
        Assert.AreEqual("ade", test.Remove("bc"));
        Assert.AreEqual("de", test.Remove("abc"));
        Assert.AreEqual("ae", test.Remove("bcd"));
        Assert.AreEqual("", test.Remove("abcde"));

        string test2 = "aaabbbccc";
        Assert.AreEqual("bbbccc", test2.Remove("a"));
        Assert.AreEqual("abbbccc", test2.Remove("aa"));
        Assert.AreEqual("bbbccc", test2.Remove("aaa"));
        Assert.AreEqual("aabbccc", test2.Remove("ab"));
        Assert.AreEqual("aaabbbccc", test2.Remove("abc"));

        Randomizer r = new Randomizer();

        100.Times().Do(() =>
        {
            string s = r.String(1, 10);
            Assert.AreEqual(s.Replace("a", ""), s.Remove("a"), s);
        });
    }

    [TestMethod]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void SeparatePascalCase_Should()
    {
        Assert.AreEqual("Hello World!", "HelloWorld!".SeparatePascalCase());
        Assert.AreEqual("helloworld!", "helloworld!".SeparatePascalCase());
        Assert.AreEqual("Helloworld!", "Helloworld!".SeparatePascalCase());
        Assert.AreEqual("Hello World!", " HelloWorld! ".SeparatePascalCase());

        Assert.AreEqual("", " ".SeparatePascalCase());
        Assert.AreEqual(string.Empty, string.Empty.SeparatePascalCase());

        Name r = new Name();

        100.Times().Do(() =>
        {
            string s = r.FullName().Replace(" ", "").Trim();

            Assert.AreEqual(Regex.Replace(s, "([A-Z])", " $1").Trim(), s.SeparatePascalCase());
        });
    }

    [TestMethod]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void SubString_Should()
    {
        string testData = "Hello World!";

        Assert.AreEqual("H", testData.SubString(0));
        Assert.AreEqual("e", testData.SubString(1));
        Assert.AreEqual("l", testData.SubString(2));
        Assert.AreEqual("l", testData.SubString(3));
        Assert.AreEqual("o", testData.SubString(4));
        Assert.AreEqual(" ", testData.SubString(5));
        Assert.AreEqual("W", testData.SubString(6));
        Assert.AreEqual("o", testData.SubString(7));
        Assert.AreEqual("r", testData.SubString(8));
        Assert.AreEqual("l", testData.SubString(9));
        Assert.AreEqual("d", testData.SubString(10));
        Assert.AreEqual("!", testData.SubString(11));

        // 取最后一个值
        Assert.AreEqual("!", testData.SubString(testData.Length - 1));

        Assert.AreEqual("He", testData.SubString(0, 2));
        Assert.AreEqual("el", testData.SubString(1, 2));
        Assert.AreEqual("ll", testData.SubString(2, 2));
        Assert.AreEqual("lo", testData.SubString(3, 2));
        Assert.AreEqual("o ", testData.SubString(4, 2));
        Assert.AreEqual(" W", testData.SubString(5, 2));
        Assert.AreEqual("Wo", testData.SubString(6, 2));
        Assert.AreEqual("or", testData.SubString(7, 2));
        Assert.AreEqual("rl", testData.SubString(8, 2));
        Assert.AreEqual("ld", testData.SubString(9, 2));
        Assert.AreEqual("d!", testData.SubString(10, 2));
        Assert.AreEqual("!", testData.SubString(11, 2));

        Assert.AreEqual("Hello World!", testData.SubString(0, int.MaxValue));
        Assert.AreEqual("ello World!", testData.SubString(1, int.MaxValue));
        Assert.AreEqual("llo World!", testData.SubString(2, int.MaxValue));
        Assert.AreEqual("lo World!", testData.SubString(3, int.MaxValue));
        Assert.AreEqual("o World!", testData.SubString(4, int.MaxValue));
        Assert.AreEqual(" World!", testData.SubString(5, int.MaxValue));
        Assert.AreEqual("World!", testData.SubString(6, int.MaxValue));
        Assert.AreEqual("orld!", testData.SubString(7, int.MaxValue));
        Assert.AreEqual("rld!", testData.SubString(8, int.MaxValue));
        Assert.AreEqual("ld!", testData.SubString(9, int.MaxValue));
        Assert.AreEqual("d!", testData.SubString(10, int.MaxValue));
        Assert.AreEqual("!", testData.SubString(11, int.MaxValue));

        // 如果取全部长度，就会获得原字符串
        Assert.AreEqual(testData, testData.SubString(0, testData.Length));

        Randomizer r = new Randomizer();

        // String.Empty 的任意子字符串都是 String.Empty
        Assert.AreEqual(string.Empty, string.Empty.SubString(r.Number(), r.Number()));

        100.Times().Do(() =>
        {
            string testString = r.String(0, 100);
            int testStart = r.Number();
            int testCount = r.Number();
            string actual = testString.SubString(testStart, testCount);

            if (testStart < testString.Length && testStart + testCount <= testString.Length)
            {
                string expected = testString.Substring(testStart, testCount);
                Assert.AreEqual(expected, actual);
            }
        });
    }

    [TestMethod]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void ToCamelCase_Should()
    {
        Assert.AreEqual("helloWorld!", "HelloWorld!".ToCamelCase());
        Assert.AreEqual("helloworld!", "helloworld!".ToCamelCase());
        Assert.AreEqual("helloworld!", "Helloworld!".ToCamelCase());
        Assert.AreEqual(" HelloWorld! ", " HelloWorld! ".ToCamelCase());

        Assert.AreEqual(null, ((string?)null).ToCamelCase());
        Assert.AreEqual(" ", " ".ToCamelCase());
        Assert.AreEqual("  ", "  ".ToCamelCase());
        Assert.AreEqual(string.Empty, string.Empty.ToCamelCase());

        // IPadIsUnsupported
        // PadIsUnsupported
        Assert.AreEqual("iPadIsUnsupported!", "IPadIsUnsupported!".ToCamelCase());
        Assert.AreEqual("padIsUnsupported!", "PadIsUnsupported!".ToCamelCase());
    }

    [TestMethod]
    public void ToEmptyIfNull_Should()
    {
        Assert.AreEqual(string.Empty, ((string?)null).ToEmptyIfNull());
        Assert.AreEqual(string.Empty, string.Empty.ToEmptyIfNull());

        Assert.AreEqual("HelloWorld!", "HelloWorld!".ToEmptyIfNull());
        Assert.AreEqual(" ", " ".ToEmptyIfNull());
    }

    [TestMethod]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void ToMosaicString_Should()
    {
        // 如果位数大于 12，则保留前4位和后4位，其它的以“*”替代
        Assert.AreEqual("1234*********defg", "1234567890abcdefg".ToMosaicString());
        Assert.AreEqual("1234****90ab", "1234567890ab".ToMosaicString());

        // 如果位数小于 12，则保留后4位，其它的以“*”替代
        Assert.AreEqual("*******890a", "1234567890a".ToMosaicString());
        Assert.AreEqual("*2345", "12345".ToMosaicString());

        // 如果位数小于 4，则返回原字符串
        Assert.AreEqual("1234", "1234".ToMosaicString());
        Assert.AreEqual("123", "123".ToMosaicString());
        Assert.AreEqual("12", "12".ToMosaicString());
        Assert.AreEqual("1", "1".ToMosaicString());

        // 如果是 null 或者 Empty，则返回 空字符串
        Assert.AreEqual(string.Empty, ((string?)null).ToMosaicString());
        Assert.AreEqual(string.Empty, string.Empty.ToMosaicString());

        // 空字符串和一般字符串是一致的
        Assert.AreEqual("", "".ToMosaicString());
        Assert.AreEqual(" ", " ".ToMosaicString());
        Assert.AreEqual("  ", "  ".ToMosaicString());
        Assert.AreEqual("   ", "   ".ToMosaicString());
        Assert.AreEqual("    ", "    ".ToMosaicString());
        Assert.AreEqual("*    ", "     ".ToMosaicString());
        Assert.AreEqual("    ****    ", "            ".ToMosaicString());
    }

    [TestMethod]
    public void ToNullIfEmpty_Should()
    {
        Assert.AreEqual(null, string.Empty.ToNullIfEmpty());
        Assert.AreEqual(null, ((string?)null).ToNullIfEmpty());

        Assert.AreEqual("HelloWorld!", "HelloWorld!".ToNullIfEmpty());
        Assert.AreEqual(" ", " ".ToNullIfEmpty());
    }

    [TestMethod]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void ToUnderScope_Should()
    {
        Assert.AreEqual("Hello_World!", "HelloWorld!".ToUnderScope());
        Assert.AreEqual("helloworld!", "helloworld!".ToUnderScope());
        Assert.AreEqual("Helloworld!", "Helloworld!".ToUnderScope());
        Assert.AreEqual(" _Hello_World! ", " HelloWorld! ".ToUnderScope());

        Assert.AreEqual(null, ((string?)null).ToUnderScope());
        Assert.AreEqual(" ", " ".ToUnderScope());
        Assert.AreEqual("  ", "  ".ToUnderScope());
        Assert.AreEqual(string.Empty, string.Empty.ToUnderScope());

        // for test nextCharIsUpper
        // ascii:
        // A-1 = @
        // Z+1 = [
        Assert.AreEqual("a_A", "aA".ToUnderScope());
        Assert.AreEqual("A_A", "AA".ToUnderScope());
        Assert.AreEqual("a_B", "aB".ToUnderScope());
        Assert.AreEqual("A_B", "AB".ToUnderScope());
        Assert.AreEqual("a_Z", "aZ".ToUnderScope());
        Assert.AreEqual("A_Z", "AZ".ToUnderScope());
        Assert.AreEqual("a[", "a[".ToUnderScope());
        Assert.AreEqual("A[", "A[".ToUnderScope());
        Assert.AreEqual("a@", "a@".ToUnderScope());
        Assert.AreEqual("A@", "A@".ToUnderScope());
        Assert.AreEqual("a", "a".ToUnderScope());
        Assert.AreEqual("A", "A".ToUnderScope());
    }
}

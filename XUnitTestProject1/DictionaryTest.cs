using System;
using System.Collections.Generic;
using Xunit;

namespace IDictionaryImplementation
{
    public class DictionaryTest
    {
        [Fact]
        public void CheckAddAndItemFunction()
        {
            var dict = new Dictionary<int, int>(1){ { 21, 20 }, { 12, 102 } };

            Assert.Equal(20, dict[21]);
            Assert.Equal(102, dict[12]);
        }

        [Fact]
        public void CheckSetterItemFunction()
        {
            var dict = new Dictionary<int, int>(100) { { 2, 100 }, { 203, 5 } };

            Assert.Equal(100, dict[2]);

            dict[2] = 300;

            Assert.Equal(300, dict[2]);
        }

        [Fact]
        public void CountFunction()
        {
            var dict = new Dictionary<int, int>(5){ { 2, 5 } };

            Assert.Single(dict);

            dict.Add(5, 6);

            Assert.Equal(2, dict.Count);
        }

        [Fact]
        public void KeysListReturn()
        {
            var dict = new Dictionary<int, int>(10) { { 2, 54 } , { 5, 10 } };

            Assert.Contains(2, dict.Keys);
            Assert.Contains(5, dict.Keys);
        }

        [Fact]
        public void ValueListReturn()
        {
            var dict = new Dictionary<int, string>(10) { { 1, "Abc" }, { 2, "aBc" } };

            Assert.Contains("Abc", dict.Values);
            Assert.Contains("aBc", dict.Values);
        }

        [Fact]
        public void ClearDictionary()
        {
            var dict = new Dictionary<string, int>(10) { { "a", 3 }, { "b", 2 } };

            Assert.Equal(2, dict.Count);

            dict.Clear();
            Assert.Empty(dict);
        }

        [Fact]
        public void ContainFunction()
        {
            var dict = new Dictionary<int, string>(10) { { 1, "Abc" }, { 2, "aBc" } };

            Assert.Contains(new KeyValuePair<int, string>(1, "Abc"), dict);
            Assert.DoesNotContain(new KeyValuePair<int, string>(1, "abc"), dict);
        }

        [Fact]
        public void ContainKeyFunctionality()
        {
            var dict = new Dictionary<int, int>(10) { { 1, 2 }, { 3, 4 }, { 4, 5 } };

            Assert.True(dict.ContainsKey(1));
            Assert.False(dict.ContainsKey(2));
        }

        [Fact]
        public void RemoveFunctionByKey()
        {
            var dict = new Dictionary<int, int>(10) { { 1, 2 }, { 2, 3 } };

            dict.Remove(2);

            Assert.DoesNotContain(2, dict.Keys);
            Assert.DoesNotContain(3, dict.Values);
        }

        [Fact]
        public void TryGetValueReturns()
        {
            var dict = new Dictionary<int, int>(10) { { 1, 2 }, { 2, 3 } };

            Assert.True(dict.TryGetValue(2, out int value));
            Assert.Equal(3, value);
        }

        [Fact]
        public void CopyToFunction()
        {
            var dict = new Dictionary<int, int>(10) { { 1, 2 }, { 2, 3 }, { 15, 20 }, { 10, 11 } };
            var copyOfPartialDictionary = new KeyValuePair<int, int>[10];

            dict.CopyTo(copyOfPartialDictionary, 2);

            Assert.Contains(copyOfPartialDictionary[2], dict);
            Assert.Contains(copyOfPartialDictionary[3], dict);
        }

        [Fact]
        public void ItemNullException()
        {
            var dict = new Dictionary<int, int>(5);

            Exception exception = Assert.Throws<ArgumentNullException>(() => dict[2]);

            Assert.Equal("Value cannot be null.", exception.Message);
        }

        [Fact]
        public void ItemKeyNotFoundException()
        {
            var dict = new Dictionary<int, int>(10) { { 10, 15 } };

            Exception exception = Assert.Throws<KeyNotFoundException>(() => dict[0]);

            Assert.Equal("The given key was not present in the dictionary.", exception.Message);
        }

        [Fact]
        public void AddAnItemWithSameKeyException()
        {
            var dict = new Dictionary<int, int>(10) { { 2, 50 } };

            Exception exception = Assert.Throws<ArgumentException>(() => dict.Add(new KeyValuePair<int, int>(2, 22)));

            Assert.Equal("Value does not fall within the expected range.", exception.Message);
        }

        [Fact]
        public void CopyToIndexLessThanZero()
        {
            var dict = new Dictionary<int, int>(10);
            var copyOf = new KeyValuePair<int, int>[10];

            Exception exception = Assert.Throws<ArgumentOutOfRangeException>(() => dict.CopyTo(copyOf, -2));

            Assert.Equal("Specified argument was out of the range of valid values.", exception.Message);
        }

        [Fact]
        public void IndexMoreThanLenght()
        {
            var dict = new Dictionary<int, int>(10);
            var copyOf = new KeyValuePair<int, int>[10];

            Exception exception = Assert.Throws<ArgumentException>(() => dict.CopyTo(copyOf, 12));

            Assert.Equal("Value does not fall within the expected range.", exception.Message);
        }

        [Fact]
        public void CheckTryGetValueForNotFoundKey()
        {
            var dict = new Dictionary<int, int>(10) { { 1, 2 }, { 2, 3 } };

            Assert.False(dict.TryGetValue(5, out int value));
        }
    }
}

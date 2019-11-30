using System;
using Xunit;

namespace IListImplementation
{
    public class ListTest
    {
        [Fact]
        public void CheckAnEmptyList()
        {
            var list = new List<int>();

            Assert.Empty(list);
        }

        [Fact]
        public void CheckAddFunction()
        {
            var list = new List<int>();

            list.Add(1);
            Assert.Single(list);

            list.Add(2);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void CheckAnItemFromAPozition()
        {
            var list = new List<int> { 1, 2 };

            Assert.Equal(2, list[1]);

            list[1] = 5;
            Assert.Equal(5, list[1]);
        }

        [Fact]
        public void CheckIfListIsNotReadOnly()
        {
            var list = new List<int>();

            Assert.False(list.IsReadOnly);
        }

        [Fact]
        public void CheckIfClearWork()
        {
            var list = new List<int>();

            list.Add(5);
            Assert.Single(list);

            list.Clear();
            Assert.Empty(list);
        }

        [Fact]
        public void CheckContainsFunctionWorking()
        {
            var list = new List<int>();

            list.Add(2);
            list.Add(5);
            list.Add(22);

            Assert.Contains(5, list);
            Assert.Contains(22, list);
            Assert.DoesNotContain(15, list);
            Assert.DoesNotContain(10, list);
        }

        [Fact]
        public void CheckCopyToFunctionaliti()
        {
            var list = new List<string>();
            string[] name = new string[5];

            list.Add("Razvan");
            list.Add("Vlad");
            list.Add("Alin");
            list.Add("Mihai");
            list.CopyTo(name, 2);

            Assert.Equal(list[2], name[2]);
            Assert.Equal(list[3], name[3]);
        }

        [Fact]
        public void CheckIndexOfIfWork()
        {
            var list = new List<char>();

            list.Add('a');
            list.Add('b');
            list.Add('c');

            Assert.Equal(0, list.IndexOf('a'));
            Assert.Equal(2, list.IndexOf('c'));
            Assert.Equal(-1, list.IndexOf('e'));
        }

        [Fact]
        public void CheckInsertFunction()
        {
            var list = new List<int>();

            list.Add(1);
            list.Add(3);
            list.Insert(1, 2);

            Assert.Equal(1, list.IndexOf(2));
        }

        [Fact]
        public void RemoveFunction()
        {
            var list = new List<int>();

            list.Add(1);
            list.Add(3);

            Assert.True(list.Remove(3));
            Assert.False(list.Remove(3));
        }

        [Fact]
        public void RemoveAtFunction()
        {
            var list = new List<int>();

            list.Add(1);
            list.Add(2);
            list.RemoveAt(1);

            Assert.Single(list);
        }

        [Fact]
        public void EnumeratorTesting()
        {
            Assert.Equal(new int[] { 1, 2, 3 }, new List<int> { 1, 2, 3 });
        }

        [Fact]
        public void CheckTthisGetException()
        {
            List<int> list = new List<int>();

            list.Add(40);
            Exception exception = Assert.Throws<IndexOutOfRangeException>(() => list[2]);

            Assert.Equal("Index out of range!", exception.Message);
        }

        [Fact]
        public void CheckTthisSetException()
        {
            List<int> list = new List<int>();

            list.Add(10);
            Exception exception = Assert.Throws<IndexOutOfRangeException>(() => list[2]);

            Assert.Equal("Index out of range!", exception.Message);
        }

        [Fact]
        public void CheckCopyToException()
        {
            List<int> list = new List<int>() { 1, 2 };
            int[] array = new int[1];
            int[] arrayNull = null;

            Exception exception = Assert.Throws<IndexOutOfRangeException>(() => list.CopyTo(array, 4));
            Assert.Equal("Index out of range!", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => list.CopyTo(arrayNull, 0));
            Assert.Equal("Value cannot be null.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => list.CopyTo(array, 2));
            Assert.Equal("Array don't have enough space!", exception.Message);
        }

        [Fact]
        public void CheckRemoveException()
        {
            List<int> list = new List<int>() { 1, 2 };

            Exception exception = Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(4));

            Assert.Equal("Index is out of range!", exception.Message);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Test
{
    [TestFixture]
    public class CollectionTest
    {
        public IReadOnlyCollection<int> _Collection;

        public CollectionTest()
        {
            var list = new List<int>();
            for(var i=0; i<1000; i++)
                list.Add(i);
            _Collection = new ReadOnlyCollection<int>(list);
        }

        public void Before()
        {
        }

        [Ignore]
        [TestCase(1, 10, TestName = "11")]
        [TestCase(2, 10, TestName = "12")]
        [TestCase(1, 5000000, TestName = "21")]
        [TestCase(2, 5000000, TestName = "22")]
        [TestCase(1, 10, TestName = "31")]
        public void AnyTest1(int method, int amount)
        {
            var expected = new List<int> { 3, 4, 5, 6, 7 };
            for (var n = 0; n < amount; n++)
            {
                IEnumerable<int> list;
                if (method == 1)
                {
                    list = new List<int>();
                    for (var i = 3; i < 8; i++)
                        ((List<int>) list).Add(_Collection.ElementAt(i));
                }
                else
                {
                    list = _Collection.Skip(3).Take(5);
                }

                Assert.AreEqual(expected, list);
            }
        }

        [Ignore]
        [Test]
        public void EnumerableEnumeratorTest()
        {
            var collection = new BoxCollection()
            {
                new Box() {Name = "Box0"},
                new Box() {Name = "Box1"},
                new Box() {Name = "Box2"},
                new Box() {Name = "Box3"},
                new Box() {Name = "Box4"},
            };

            foreach (var box in collection)
            {
                Console.WriteLine(box.Name);
            }
        }

        public class BoxEnumerator : IEnumerator<Box>
        {
            private BoxCollection _collection;
            private int curIndex;
            private Box curBox;


            public BoxEnumerator(BoxCollection collection)
            {
                _collection = collection;
                curIndex = -1;
                curBox = default(Box);

            }

            public bool MoveNext()
            {
                //Avoids going beyond the end of the collection.
                curIndex += 2;
                if (curIndex >= _collection.Count)
                {
                    return false;
                }
                else
                {
                    // Set current box to next item in collection.
                    curBox = _collection[curIndex];
                }
                return true;
            }

            public void Reset() { curIndex = -1; }

            void IDisposable.Dispose() { }

            public Box Current
            {
                get { return curBox; }
            }


            object IEnumerator.Current
            {
                get { return Current; }
            }

        }
    }

    public class BoxCollection : List<Box>
    {
        public new CollectionTest.BoxEnumerator GetEnumerator()
        {
            return new CollectionTest.BoxEnumerator(this);
        }
    }

    public class Box
    {
        public string Name;
    }
}

// ***********************************************************************
// Copyright (c) 2007 Charlie Poole, Rob Prouse
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using System.Collections;
using NUnit.TestUtilities.Collections;

namespace NUnit.Framework.Assertions
{
    /// <summary>
    /// Summary description for ArrayEqualTests.
    /// </summary>
    [TestFixture]
    public class ArrayEqualsFixture
    {
#pragma warning disable 183, 184 // error number varies in different runtimes
        // Used to detect runtimes where ArraySegments implement IEnumerable
        private static readonly bool ArraySegmentImplementsIEnumerable = new ArraySegment<int>() is IEnumerable;
#pragma warning restore 183, 184

        [Test]
        public void ArrayIsEqualToItself()
        {
            string[] array = { "one", "two", "three" };
            Assert.That( array, Is.SameAs(array) );
            Assert.AreEqual( array, array );
        }

        [Test]
        public void ArraysOfString()
        {
            string[] array1 = { "one", "two", "three" };
            string[] array2 = { "one", "two", "three" };
            Assert.IsFalse( array1 == array2 );
            Assert.AreEqual(array1, array2);
            Assert.AreEqual(array2, array1);
        }

        [Test]
        public void ArraysOfInt()
        {
            int[] a = new int[] { 1, 2, 3 };
            int[] b = new int[] { 1, 2, 3 };
            Assert.AreEqual(a, b);
            Assert.AreEqual(b, a);
        }

        [Test]
        public void ArraysOfDouble()
        {
            double[] a = new double[] { 1.0, 2.0, 3.0 };
            double[] b = new double[] { 1.0, 2.0, 3.0 };
            Assert.AreEqual(a, b);
            Assert.AreEqual(b, a);
        }

        [Test]
        public void ArraysOfDecimal()
        {
            decimal[] a = new decimal[] { 1.0m, 2.0m, 3.0m };
            decimal[] b = new decimal[] { 1.0m, 2.0m, 3.0m };
            Assert.AreEqual(a, b);
            Assert.AreEqual(b, a);
        }

        [Test]
        public void ArrayOfIntAndArrayOfDouble()
        {
            int[] a = new int[] { 1, 2, 3 };
            double[] b = new double[] { 1.0, 2.0, 3.0 };
            Assert.AreEqual(a, b);
            Assert.AreEqual(b, a);
        }

        [Test]
        public void ArraysDeclaredAsDifferentTypes()
        {
            string[] array1 = { "one", "two", "three" };
            object[] array2 = { "one", "two", "three" };
            Assert.AreEqual( array1, array2, "String[] not equal to Object[]" );
            Assert.AreEqual( array2, array1, "Object[] not equal to String[]" );
        }

        [Test]
        public void ArraysOfMixedTypes()
        {
            DateTime now = DateTime.Now;
            object[] array1 = new object[] { 1, 2.0f, 3.5d, 7.000m, "Hello", now };
            object[] array2 = new object[] { 1.0d, 2, 3.5, 7, "Hello", now };
            Assert.AreEqual( array1, array2 );
            Assert.AreEqual(array2, array1);
        }

        [Test]
        public void DoubleDimensionedArrays()
        {
            int[,] a = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] b = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Assert.AreEqual(a, b);
            Assert.AreEqual(b, a);
        }

        [Test]
        public void TripleDimensionedArrays()
        {
            int[, ,] expected = new int[,,] { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } };
            int[,,] actual = new int[,,] { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FiveDimensionedArrays()
        {
            int[, , , ,] expected = new int[2, 2, 2, 2, 2] { { { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } }, { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } } }, { { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } }, { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } } } };
            int[, , , ,] actual = new int[2, 2, 2, 2, 2] { { { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } }, { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } } }, { { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } }, { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } } } };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArraysOfArrays()
        {
            int[][] a = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            int[][] b = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            Assert.AreEqual(a, b);
            Assert.AreEqual(b, a);
        }

        [Test]
        public void JaggedArrays()
        {
            int[][] expected = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6, 7 }, new int[] { 8, 9 } };
            int[][] actual = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6, 7 }, new int[] { 8, 9 } };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArraysPassedAsObjects()
        {
            object a = new int[] { 1, 2, 3 };
            object b = new double[] { 1.0, 2.0, 3.0 };
            Assert.AreEqual(a, b);
            Assert.AreEqual(b, a);
        }

        [Test]
        public void ArrayAndCollection()
        {
            int[] a = new int[] { 1, 2, 3 };
            ICollection b = new SimpleObjectCollection( 1, 2, 3 );
            Assert.AreEqual(a, b);
            Assert.AreEqual(b, a);
        }

        [Test]
        public void ArraysWithDifferentRanksComparedAsCollection()
        {
            int[] expected = new int[] { 1, 2, 3, 4 };
            int[,] actual = new int[,] { { 1, 2 }, { 3, 4 } };

            Assert.AreNotEqual(expected, actual);
            Assert.That(actual, Is.EqualTo(expected).AsCollection);
        }

        [Test]
        public void ArraysWithDifferentDimensionsMatchedAsCollection()
        {
            int[,] expected = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] actual = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

            Assert.AreNotEqual(expected, actual);
            Assert.That(actual, Is.EqualTo(expected).AsCollection);
        }

        private static int[] underlyingArray = new int[] { 1, 2, 3, 4, 5 };

        [Test]
        public void ArraySegmentAndArray()
        {
            Assume.That(ArraySegmentImplementsIEnumerable);
            Assert.That(new ArraySegment<int>(underlyingArray, 1, 3), Is.EqualTo(new int[] { 2, 3, 4 }));
        }

        [Test]
        public void EmptyArraySegmentAndArray()
        {
            Assume.That(ArraySegmentImplementsIEnumerable);
            Assert.That(new ArraySegment<int>(), Is.Not.EqualTo(new int[] { 2, 3, 4 }));
        }

        [Test]
        public void ArrayAndArraySegment()
        {
            Assume.That(ArraySegmentImplementsIEnumerable);
            Assert.That(new int[] { 2, 3, 4 }, Is.EqualTo(new ArraySegment<int>(underlyingArray, 1, 3)));
        }

        [Test]
        public void ArrayAndEmptyArraySegment()
        {
            Assume.That(ArraySegmentImplementsIEnumerable);
            Assert.That(new int[] { 2, 3, 4 }, Is.Not.EqualTo(new ArraySegment<int>()));
        }

        [Test]
        public void TwoArraySegments()
        {
            Assume.That(ArraySegmentImplementsIEnumerable);
            Assert.That(new ArraySegment<int>(underlyingArray, 1, 3), Is.EqualTo(new ArraySegment<int>(underlyingArray, 1, 3)));
        }

        [Test]
        public void TwoEmptyArraySegments()
        {
            Assume.That(ArraySegmentImplementsIEnumerable);
            Assert.That(new ArraySegment<int>(), Is.EqualTo(new ArraySegment<int>()));
        }
    }
}

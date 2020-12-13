using NUnit.Framework;
using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Tests
{
    class StackTests
    {
        [Test]
        public void CanPush10000itemsOntoStack()
        {
            var stack = new RollingStack();

            for (int n = 0; n < 10000; n++) stack.Push(n);

            Assert.AreEqual(10000, stack.Count);
        }

        [Test]
        public void CanPopFromStack()
        {
            var stack = new RollingStack();

            stack.Push(1);
            stack.Push(2);

            var popped = stack.Pop();

            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(2, popped);
        }

        [TestCase(1, 1, "0,1,2,3,4,5,6,7,9,8")]
        [TestCase(2, 1, "0,1,2,3,4,5,6,9,7,8")]
        [TestCase(3, 1, "0,1,2,3,4,5,9,6,7,8")]
        [TestCase(4, 1, "0,1,2,3,4,9,5,6,7,8")]
        [TestCase(4, 2, "0,1,2,3,4,8,9,5,6,7")]
        [TestCase(1, 2, "0,1,2,3,4,5,6,7,8,9")]
        [TestCase(1, 4, "0,1,2,3,4,5,6,7,8,9")]
        [TestCase(100, 1, "0,1,2,3,4,5,6,7,8,9")]
        public void RollPerformsAsExpected(int rollDepth, int rollNumber, string expectedResult)
        {
            var stack = new RollingStack();

            for (int n = 0; n < 10; n++) stack.Push(n);

            stack.Roll(rollNumber, rollDepth);

            var expected = expectedResult.Split(',').Select(s => int.Parse(s)).ToList();
            for (int n = expected.Count - 1; n >= 0; n--)
            {
                Assert.AreEqual(expected[n], stack.Pop());
            }
        }

        [Test]
        public void RollingTwiceToDepth1DoesNothing()
        {
            var stack = new RollingStack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            // 1 2 3 4

            stack.Roll(2, 1);
            // 1 2 3 4

            Assert.AreEqual(4, stack.Count);
            Assert.AreEqual(4, stack.Pop());
            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
        }

        [Test]
        public void CanRollMultiple()
        {
            var stack = new RollingStack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            // 1 2 3 4 5

            stack.Roll(2, 3);
            // 1 4 5 2 3

            Assert.AreEqual(5, stack.Count);
            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(5, stack.Pop());
            Assert.AreEqual(4, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
        }

        [Test]
        public void CanPerformNegativeRoll()
        {
            var stack = new RollingStack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            // 1 2 3 4

            stack.Roll(2, -2);
            // 1 4 2 3

            Assert.AreEqual(4, stack.Count);
            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(4, stack.Pop());
        }
    }
}

using NUnit.Framework;

using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_ArgumentIsNull_ThrowsArgumentNullException()
        {
            var stack = new Stack<object>();

            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ArgumentIsValid_AddsToList()
        {
            var stack = new Stack<object>();

            stack.Push(1);

            Assert.That(stack.Count, Is.EqualTo(1));
        }


        [Test]
        public void Pop_StackIsEmpty_ThrowsInvalidOperationException()
        {
            var stack = new Stack<object>();

            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackHasItems_ReturnTopmostElementAndRemoveItFromStack()
        {
            var stack = new Stack<object>();
            stack.Push(1);
            stack.Push(2);

            var result = stack.Pop();


            Assert.That(result, Is.EqualTo(2));
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Peek_StackIsEmpty_ThrowsInvalidOperationException()
        {
            var stack = new Stack<object>();

            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }


        [Test]
        public void Pop_StackHasItems_ReturnTopmostElementAndDontRemoveItFromStack()
        {
            var stack = new Stack<object>();
            stack.Push(1);
            stack.Push(2);

            var result = stack.Peek();


            Assert.That(result, Is.EqualTo(2));
            Assert.That(stack.Count, Is.EqualTo(2));
        }
    }
}

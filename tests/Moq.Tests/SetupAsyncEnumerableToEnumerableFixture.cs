// Copyright (c) 2007, Clarius Consulting, Manas Technology Solutions, InSTEDD, and Contributors.
// All rights reserved. Licensed under the BSD 3-Clause License; see License.txt.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;

namespace Moq.Tests
{
	public class SetupAsyncEnumerableToEnumerableFixture
	{
		public interface IAsyncInterface
		{
			IAsyncEnumerable<string> NoParametersRefReturnType();

			IAsyncEnumerable<int> NoParametersValueReturnType();

			IAsyncEnumerable<string> RefParameterRefReturnType(string value);

			IAsyncEnumerable<int> RefParameterValueReturnType(string value);

			IAsyncEnumerable<string> ValueParameterRefReturnType(int value);

			IAsyncEnumerable<int> ValueParameterValueReturnType(int value);

			IAsyncEnumerable<Guid> NewGuidAsync();

			IAsyncEnumerable<object> NoParametersObjectReturnType();

			IAsyncEnumerable<object> OneParameterObjectReturnType(string value);

			IAsyncEnumerable<object> ManyParametersObjectReturnType(string arg1, bool arg2, float arg3);

			IAsyncEnumerable<DateTime> ParamsAsync(params DateTime[] dateTimes);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsync_on_NoParametersRefReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.NoParametersRefReturnType()).Returns(new[] { "TestString" }.ToAsyncEnumerable());

			var enumerable = mock.Object.NoParametersRefReturnType();
			var task = enumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<string>>(enumerable);
			Assert.True(task.IsCompleted);
			Assert.Equal(new[] { "TestString" }, task.Result);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsync_on_NoParametersValueReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.NoParametersValueReturnType()).Returns(new[] { 36 }.ToAsyncEnumerable());

			var enumerable = mock.Object.NoParametersValueReturnType();
			var task = enumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<int>>(enumerable);
			Assert.True(task.IsCompleted);
			Assert.Equal(new[] { 36 }, task.Result);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsync_on_RefParameterRefReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.RefParameterRefReturnType("Param1")).Returns(new[] { "TestString" }.ToAsyncEnumerable());

			var enumerable = mock.Object.RefParameterRefReturnType("Param1");
			var task = enumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<string>>(enumerable);
			Assert.True(task.IsCompleted);
			Assert.Equal(new[] { "TestString" }, task.Result);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsync_on_RefParameterValueReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.RefParameterValueReturnType("Param1")).Returns(new[] { 36 }.ToAsyncEnumerable());

			var enumerable = mock.Object.RefParameterValueReturnType("Param1");
			var task = enumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<int>>(enumerable);
			Assert.True(task.IsCompleted);
			Assert.Equal(new[] { 36 }, task.Result);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsync_on_ValueParameterRefReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.ValueParameterRefReturnType(36)).Returns(new[] { "TestString" }.ToAsyncEnumerable());

			var enumerable = mock.Object.ValueParameterRefReturnType(36);
			var task = enumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<string>>(enumerable);
			Assert.True(task.IsCompleted);
			Assert.Equal(new[] { "TestString" }, task.Result);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsync_on_ValueParameterValueReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.ValueParameterValueReturnType(36)).Returns(new[] { 37 }.ToAsyncEnumerable());

			var enumerable = mock.Object.ValueParameterValueReturnType(36);
			var task = enumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<int>>(enumerable);
			Assert.True(task.IsCompleted);
			Assert.Equal(new[] { 37 }, task.Result);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsyncFunc_on_NoParametersRefReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.NoParametersRefReturnType()).Returns(() => new[] { "TestString" }.ToAsyncEnumerable());

			var enumerable = mock.Object.NoParametersRefReturnType();
			var task = enumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<string>>(enumerable);
			Assert.True(task.IsCompleted);
			Assert.Equal(new[] { "TestString" }, task.Result);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsyncFunc_on_NoParametersValueReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.NoParametersValueReturnType()).Returns(() => new[] { 36 }.ToAsyncEnumerable());

			var enumerable = mock.Object.NoParametersValueReturnType();
			var task = enumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<int>>(enumerable);
			Assert.True(task.IsCompleted);
			Assert.Equal(new[] { 36 }, task.Result);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsyncFunc_on_RefParameterRefReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.RefParameterRefReturnType("Param1")).Returns(() => new[] { "TestString" }.ToAsyncEnumerable());

			var enumerable = mock.Object.RefParameterRefReturnType("Param1");
			var task = enumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<string>>(enumerable);
			Assert.True(task.IsCompleted);
			Assert.Equal(new[] { "TestString" }, task.Result);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsyncFunc_on_RefParameterValueReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.RefParameterValueReturnType("Param1")).Returns(() => new[] { 36 }.ToAsyncEnumerable());

			var enumerable = mock.Object.RefParameterValueReturnType("Param1");
			var task = enumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<int>>(enumerable);
			Assert.True(task.IsCompleted);
			Assert.Equal(new[] { 36 }, task.Result);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsyncFunc_on_ValueParameterRefReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.ValueParameterRefReturnType(36)).Returns(() => new[] { "TestString" }.ToAsyncEnumerable());

			var enumerable = mock.Object.ValueParameterRefReturnType(36);
			var task = enumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<string>>(enumerable);
			Assert.True(task.IsCompleted);
			Assert.Equal(new[] { "TestString" }, task.Result);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsyncFunc_on_ValueParameterValueReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.ValueParameterValueReturnType(36)).Returns(() => new[] { 37 }.ToAsyncEnumerable());

			var enumerable = mock.Object.ValueParameterValueReturnType(36);
			var task = enumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<int>>(enumerable);
			Assert.True(task.IsCompleted);
			Assert.Equal(new[] { 37 }, task.Result);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsyncFunc_onEachInvocation_ValueReturnTypeLazyEvaluation()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.NewGuidAsync()).Returns(() => new[] { Guid.NewGuid() }.ToAsyncEnumerable());

			var firstEnumerable = mock.Object.NewGuidAsync();
			var secondEnumerable = mock.Object.NewGuidAsync();
			var firstTask = firstEnumerable.ToArrayAsync();
			var secondTask = secondEnumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<Guid>>(firstEnumerable);
			Assert.IsAssignableFrom<IAsyncEnumerable<Guid>>(secondEnumerable);
			Assert.NotEqual(firstTask.Result, secondTask.Result);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsyncFunc_onEachInvocation_RefReturnTypeLazyEvaluation()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.ValueParameterRefReturnType(36)).Returns(() => new[] { new string(new[] { 'M', 'o', 'q', '4' }) }.ToAsyncEnumerable());

			var firstEnumerable = mock.Object.ValueParameterRefReturnType(36);
			var secondEnumerable = mock.Object.ValueParameterRefReturnType(36);
			var firstTask = firstEnumerable.ToArrayAsync();
			var secondTask = secondEnumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<string>>(firstEnumerable);
			Assert.IsAssignableFrom<IAsyncEnumerable<string>>(secondEnumerable);
			Assert.NotSame(firstTask.Result, secondTask.Result);
		}

		[Fact]
		public void AsyncEnumerableThrowsAsync_on_NoParametersRefReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			var exception = new InvalidOperationException();
			mock.Setup(x => x.NoParametersRefReturnType()).Throws(exception);

			var actualException = Assert.Throws<InvalidOperationException>(() => mock.Object.NoParametersRefReturnType());
			Assert.Equal(exception, actualException);
		}

		[Fact]
		public void AsyncEnumerableThrowsAsync_on_NoParametersValueReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			var exception = new InvalidOperationException();
			mock.Setup(x => x.NoParametersValueReturnType()).Throws(exception);

			var actualException = Assert.Throws<InvalidOperationException>(() => mock.Object.NoParametersValueReturnType());
			Assert.Equal(exception, actualException);
		}

		[Fact]
		public void AsyncEnumerableThrowsAsync_on_RefParameterRefReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			var exception = new InvalidOperationException();
			mock.Setup(x => x.RefParameterRefReturnType("Param1")).Throws(exception);

			var actualException = Assert.Throws<InvalidOperationException>(() => mock.Object.RefParameterRefReturnType("Param1"));
			Assert.Equal(exception, actualException);
		}

		[Fact]
		public void AsyncEnumerableThrowsAsync_on_RefParameterValueReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			var exception = new InvalidOperationException();
			mock.Setup(x => x.RefParameterValueReturnType("Param1")).Throws(exception);

			var actualException = Assert.Throws<InvalidOperationException>(() => mock.Object.RefParameterValueReturnType("Param1"));
			Assert.Equal(exception, actualException);
		}

		[Fact]
		public void AsyncEnumerableThrowsAsync_on_ValueParameterRefReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			var exception = new InvalidOperationException();
			mock.Setup(x => x.ValueParameterRefReturnType(36)).Throws(exception);

			var actualException = Assert.Throws<InvalidOperationException>(() => mock.Object.ValueParameterRefReturnType(36));
			Assert.Equal(exception, actualException);
		}

		[Fact]
		public void AsyncEnumerableThrowsAsync_on_ValueParameterValueReturnType()
		{
			var mock = new Mock<IAsyncInterface>();
			var exception = new InvalidOperationException();
			mock.Setup(x => x.ValueParameterValueReturnType(36)).Throws(exception);

			var actualException = Assert.Throws<InvalidOperationException>(() => mock.Object.ValueParameterValueReturnType(36));
			Assert.Equal(exception, actualException);
		}

#if DELAY_SUPPORT
		[Fact]
		public void AsyncEnumerableReturnsAsyncWithDelayDoesNotImmediatelyComplete()
		{
			var longEnoughForAnyBuildServer = TimeSpan.FromSeconds(5);

			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.RefParameterValueReturnType("test")).Returns(new[] { 5 }, longEnoughForAnyBuildServer);

			var enumerable = mock.Object.RefParameterValueReturnType("test");
			var task = enumerable.ToArrayAsync();

			Assert.IsAssignableFrom<IAsyncEnumerable<int>>(enumerable);
			Assert.False(task.IsCompleted);
		}

		[Theory]
		[InlineData(-1, true)]
		[InlineData(0, true)]
		[InlineData(1, false)]
		public void AsyncEnumerableDelayMustBePositive(int ticks, bool mustThrow)
		{
			var mock = new Mock<IAsyncInterface>();

			Action setup = () => mock
				.Setup(x => x.RefParameterValueReturnType("test"))
				.ReturnsAsync(new[] { 5 }, TimeSpan.FromTicks(ticks));

			if (mustThrow)
				Assert.Throws<ArgumentException>(setup);
			else
				setup();
		}

		[Fact]
		public async Task AsyncEnumerableReturnsAsyncWithDelayReturnsValue()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.RefParameterValueReturnType("test")).Returns(new[] { 5 }, TimeSpan.FromMilliseconds(1));

			var enumerable = mock.Object.RefParameterValueReturnType("test");
			var value = await Assert.IsAssignableFrom<IAsyncEnumerable<int>>(enumerable).ToArrayAsync();

			Assert.Equal(new[] { 5 }, value);
		}

		[Fact]
		public async Task AsyncEnumerableReturnsAsyncWithMinAndMaxDelayReturnsValue()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.RefParameterValueReturnType("test")).Returns(new[] { 5 }, TimeSpan.FromMilliseconds(1), TimeSpan.FromMilliseconds(2));

			var enumerable = mock.Object.RefParameterValueReturnType("test");
			var value = await Assert.IsAssignableFrom<IAsyncEnumerable<int>>(enumerable).ToArrayAsync();

			Assert.Equal(new[] { 5 }, value);
		}

		[Fact]
		public async Task AsyncEnumerableReturnsAsyncWithMinAndMaxDelayAndOwnRandomGeneratorReturnsValue()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.RefParameterValueReturnType("test")).Returns(new[] { 5 }, TimeSpan.FromMilliseconds(1), TimeSpan.FromMilliseconds(2), new Random());

			var task = mock.Object.RefParameterValueReturnType("test");
			var value = await Assert.IsAssignableFrom<IAsyncEnumerable<int>>(task).ToArrayAsync();

			Assert.Equal(new[] { 5 }, value);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsyncWithNullRandomGenerator()
		{
			var mock = new Mock<IAsyncInterface>();

			Action setup = () => mock
				.Setup(x => x.RefParameterValueReturnType("test"))
				.ReturnsAsync(new[] { 5 }, TimeSpan.FromMilliseconds(1), TimeSpan.FromMilliseconds(2), null);

			var paramName = Assert.Throws<ArgumentNullException>(setup).ParamName;
			Assert.Equal("random", paramName);
		}

		[Fact]
		public async Task AsyncEnumerableThrowsWithDelay()
		{
			var mock = new Mock<IAsyncInterface>();

			mock
				.Setup(x => x.RefParameterValueReturnType("test"))
				.ThrowsAsync(new ArithmeticException("yikes"), TimeSpan.FromMilliseconds(1));

			Func<IAsyncEnumerable<int>> test = () => mock.Object.RefParameterValueReturnType("test");

			var exception = await Assert.ThrowsAsync<ArithmeticException>(() => test().ToArrayAsync().AsTask());
			Assert.Equal("yikes", exception.Message);
		}

		[Fact]
		public async Task AsyncEnumerableThrowsWithRandomDelay()
		{
			var mock = new Mock<IAsyncInterface>();

			var minDelay = TimeSpan.FromMilliseconds(1);
			var maxDelay = TimeSpan.FromMilliseconds(2);

			mock
				.Setup(x => x.RefParameterValueReturnType("test"))
				.ThrowsAsync(new ArithmeticException("yikes"), minDelay, maxDelay);

			Func<IAsyncEnumerable<int>> test = () => mock.Object.RefParameterValueReturnType("test");

			var exception = await Assert.ThrowsAsync<ArithmeticException>(() => test().ToArrayAsync().AsTask());
			Assert.Equal("yikes", exception.Message);
		}

		[Fact]
		public async Task AsyncEnumerableThrowsWithRandomDelayAndOwnRandomGenerator()
		{
			var mock = new Mock<IAsyncInterface>();

			var minDelay = TimeSpan.FromMilliseconds(1);
			var maxDelay = TimeSpan.FromMilliseconds(2);

			mock
				.Setup(x => x.RefParameterValueReturnType("test"))
				.ThrowsAsync(new ArithmeticException("yikes"), minDelay, maxDelay, new Random());

			Func<IAsyncEnumerable<int>> test = () => mock.Object.RefParameterValueReturnType("test");

			var exception = await Assert.ThrowsAsync<ArithmeticException>(() => test().ToArrayAsync().AsTask());
			Assert.Equal("yikes", exception.Message);
		}

		[Fact]
		public void AsyncEnumerableThrowsAsyncWithNullRandomGenerator()
		{
			var mock = new Mock<IAsyncInterface>();

			Action setup = () =>
			{
				var anyException = new Exception();
				var minDelay = TimeSpan.FromMilliseconds(1);
				var maxDelay = TimeSpan.FromMilliseconds(2);

				mock
					.Setup(x => x.RefParameterValueReturnType("test"))
					.ThrowsAsync(anyException, minDelay, maxDelay, null);
			};

			var paramName = Assert.Throws<ArgumentNullException>(setup).ParamName;
			Assert.Equal("random", paramName);
		}
#endif

		[Fact]
		public void No_parameters_object_return_type__ReturnsAsync_null__returns_null_AsyncEnumerable()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(m => m.NoParametersObjectReturnType()).Returns((IAsyncEnumerable<object>) null);

			var result = mock.Object.NoParametersObjectReturnType();

			Assert.Null(result);
		}

		[Fact]
		public void One_parameter_object_return_type__ReturnsAsync_null__returns_null_AsyncEnumerable()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(m => m.OneParameterObjectReturnType("")).Returns((IAsyncEnumerable<object>) null);

			var result = mock.Object.OneParameterObjectReturnType("");

			Assert.Null(result);
		}

		[Fact]
		public void Many_parameters_object_return_type__ReturnsAsync_null__returns_null_AsyncEnumerable()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(m => m.ManyParametersObjectReturnType("", false, 0f)).Returns((IAsyncEnumerable<object>) null);

			var result = mock.Object.ManyParametersObjectReturnType("", false, 0f);

			Assert.Null(result);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsync_onSingleParameter_ParameterUsedForCalculationOfTheResult()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.ValueParameterValueReturnType(It.IsAny<int>())).Returns((int x) => new[] { x * x }.ToAsyncEnumerable());

			int[] evaluationResult = mock.Object.ValueParameterValueReturnType(2).ToArrayAsync().Result;

			Assert.Equal(new[] { 4 }, evaluationResult);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsync_onSingleParameter_LazyEvaluationOfTheResult()
		{
			int coefficient = 5;
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.ValueParameterValueReturnType(It.IsAny<int>())).Returns((int x) => new[] { x * coefficient }.ToAsyncEnumerable());

			int[] firstEvaluationResult = mock.Object.ValueParameterValueReturnType(2).ToArrayAsync().Result;

			coefficient = 10;
			int[] secondEvaluationResult = mock.Object.ValueParameterValueReturnType(2).ToArrayAsync().Result;

			Assert.NotEqual(firstEvaluationResult, secondEvaluationResult);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsync_onMultiParameter_ParametersUsedForCalculationOfTheResult()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.ManyParametersObjectReturnType(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<float>())).Returns((string first, bool second, float third) => new[] { first + third.ToString("N0") }.ToAsyncEnumerable());

			object[] evaluationResult = mock.Object.ManyParametersObjectReturnType("Moq", true, 4.0f).ToArrayAsync().Result;

			Assert.Equal(new[] { "Moq4" }, evaluationResult);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsync_onMultiParameter_LazyEvaluationOfTheResult()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.ManyParametersObjectReturnType(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<float>())).Returns((string first, bool second, float third) => new[] { first + third.ToString("N0") }.ToAsyncEnumerable());

			object[] firstEvaluationResult = mock.Object.ManyParametersObjectReturnType("Moq", true, 4.0f).ToArrayAsync().Result;
			object[] secondEvaluationResult = mock.Object.ManyParametersObjectReturnType("Moq", true, 4.0f).ToArrayAsync().Result;

			Assert.NotSame(firstEvaluationResult, secondEvaluationResult);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsync_onParams_AllParametersUsedForCalculationOfTheResult()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.ParamsAsync(It.IsAny<DateTime[]>()))
				.Returns((DateTime[] dateTimes) => dateTimes.ToAsyncEnumerable());

			var now = DateTime.Now;

			DateTime[] evaluationResult = mock.Object.ParamsAsync(DateTime.MinValue, now, DateTime.MaxValue).ToArrayAsync().Result;

			Assert.Equal(new[] { DateTime.MinValue, now, DateTime.MaxValue }, evaluationResult);
		}

		[Fact]
		public void AsyncEnumerableReturnsAsync_onParams_LazyEvaluationOfTheResult()
		{
			DateTime comparedDateTime = DateTime.MinValue;
			var mock = new Mock<IAsyncInterface>();
			mock.Setup(x => x.ParamsAsync(It.IsAny<DateTime[]>()))
				.Returns((DateTime[] dateTimes) => dateTimes.Concat(new[] { comparedDateTime }).ToAsyncEnumerable());

			DateTime now = DateTime.Now;
			DateTime[] firstEvaluationResult = mock.Object.ParamsAsync(DateTime.MinValue, now).ToArrayAsync().Result;

			comparedDateTime = DateTime.MaxValue;
			DateTime[] secondEvaluationResult = mock.Object.ParamsAsync(DateTime.MinValue, now).ToArrayAsync().Result;

			Assert.NotEqual(firstEvaluationResult, secondEvaluationResult);
		}

		[Fact]
		public async Task PerformSequenceAsyncEnumerableAsync()
		{
			var mock = new Mock<IAsyncInterface>();

			mock.SetupSequence(x => x.NoParametersValueReturnType())
				.Returns(new[] { 2 }.ToAsyncEnumerable())
				.Returns(() => new[] { 3 }.ToAsyncEnumerable())
				.Throws(new InvalidOperationException());

			Assert.Equal(new[] { 2 }, await mock.Object.NoParametersValueReturnType().ToArrayAsync());
			Assert.Equal(new[] { 3 }, await mock.Object.NoParametersValueReturnType().ToArrayAsync());
			await Assert.ThrowsAsync<InvalidOperationException>(async () => await mock.Object.NoParametersValueReturnType().ToArrayAsync());
		}

		[Fact]
		public async Task PerformSequenceAsync_ReturnsAsync_for_AsyncEnumerable_with_value_function()
		{
			var mock = new Mock<IAsyncInterface>();
			mock.SetupSequence(m => m.NoParametersValueReturnType())
				.Returns(() => new[] { 1 }.ToAsyncEnumerable())
				.Returns(() => new[] { 2 }.ToAsyncEnumerable());

			Assert.Equal(new[] { 1 }, await mock.Object.NoParametersValueReturnType().ToArrayAsync());
			Assert.Equal(new[] { 2 }, await mock.Object.NoParametersValueReturnType().ToArrayAsync());
		}

		[Fact]
		public async Task Func_are_invoked_deferred_for_AsyncEnumerable()
		{
			var mock = new Mock<IAsyncInterface>();
			var i = new[] { 0 };
			mock.SetupSequence(m => m.NoParametersValueReturnType())
				.Returns(() => i.ToAsyncEnumerable());

			i[0]++;

			Assert.Equal(i, await mock.Object.NoParametersValueReturnType().ToArrayAsync());
		}
	}
}

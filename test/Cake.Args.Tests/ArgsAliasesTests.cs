using System;
using Cake.Core;
using FluentAssertions;
using Moq;
using Xunit;

namespace Cake.Args.Tests
{
    public class ArgsAliasesTests
    {
        private readonly Mock<ICakeContext> _cakeContextMock;
        private readonly Mock<ICakeArguments> _cakeArgumentsMock;

        public ArgsAliasesTests()
        {
            _cakeContextMock = new Mock<ICakeContext>(MockBehavior.Strict);
            _cakeArgumentsMock = new Mock<ICakeArguments>(MockBehavior.Strict);

            _cakeContextMock.Setup(x => x.Arguments).Returns(_cakeArgumentsMock.Object);
        }

        [Fact]
        public void ArgumentOrDefault_of_string_returns_value_when_arg_is_present()
        {
            _cakeArgumentsMock.Setup(x => x.GetArguments("configuration")).Returns(new [] { "Release" });

            var context = _cakeContextMock.Object;
            var value = context.ArgumentOrDefault<string>("configuration");

            value.Should().Be("Release");
        }

        [Fact]
        public void ArgumentOrDefault_of_int_returns_value_when_arg_is_present()
        {
            _cakeArgumentsMock.Setup(x => x.GetArguments("number")).Returns(new [] { "42" });

            var context = _cakeContextMock.Object;
            var value = context.ArgumentOrDefault<int>("number");

            value.Should().Be(42);
        }

        [Fact]
        public void ArgumentOrDefault_of_bool_returns_value_when_arg_is_present()
        {
            _cakeArgumentsMock.Setup(x => x.GetArguments("publish")).Returns(new [] { "true" });

            var context = _cakeContextMock.Object;
            var value = context.ArgumentOrDefault<bool>("publish");

            value.Should().Be(true);
        }

        [Fact]
        public void ArgumentOrDefault_of_nullable_int_returns_value_when_arg_is_present()
        {
            _cakeArgumentsMock.Setup(x => x.GetArguments("number")).Returns(new [] { "42" });

            var context = _cakeContextMock.Object;
            var value = context.ArgumentOrDefault<int?>("number");

            value.Should().Be(42);
        }

        [Fact]
        public void ArgumentOrDefault_of_string_returns_null_when_arg_is_missing()
        {
            _cakeArgumentsMock.Setup(x => x.GetArguments("configuration")).Returns(Array.Empty<string>());

            var context = _cakeContextMock.Object;
            var value = context.ArgumentOrDefault<string>("configuration");

            value.Should().BeNull();
        }

        [Fact]
        public void ArgumentOrDefault_of_int_returns_zero_when_arg_is_missing()
        {
            _cakeArgumentsMock.Setup(x => x.GetArguments("number")).Returns(Array.Empty<string>());

            var context = _cakeContextMock.Object;
            var value = context.ArgumentOrDefault<int>("number");

            value.Should().Be(0);
        }

        [Fact]
        public void ArgumentOrDefault_of_bool_returns_false_when_arg_is_missing()
        {
            _cakeArgumentsMock.Setup(x => x.GetArguments("publish")).Returns(Array.Empty<string>());

            var context = _cakeContextMock.Object;
            var value = context.ArgumentOrDefault<bool>("publish");

            value.Should().Be(false);
        }

        [Fact]
        public void ArgumentOrDefault_of_nullable_int_returns_null_when_arg_is_missing()
        {
            _cakeArgumentsMock.Setup(x => x.GetArguments("number")).Returns(Array.Empty<string>());

            var context = _cakeContextMock.Object;
            var value = context.ArgumentOrDefault<int?>("number");

            value.Should().BeNull();
        }
    }
}

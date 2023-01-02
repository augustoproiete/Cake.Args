#region Copyright 2021-2023 C. Augusto Proiete & Contributors
//
// Licensed under the MIT (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://opensource.org/licenses/MIT
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System;
using Cake.Core;
using FluentAssertions;
using Moq;
using Xunit;

namespace Cake.Args.Tests;

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

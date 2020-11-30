using System;
using AdventOfCode.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Days
{

    public class Day7Tests
    {
        private readonly ISolution _sut = new Day07();

        [Fact]
        public void PartOne_WhenCalled_DoesNotThrowNotImplementedException()
        {
            Action act = () => _sut.PartOne(_sut.Input());

            act.Should().NotThrow<NotImplementedException>();
        }

        [Fact]
        public void PartOne_WhenCalled_Returns()
        {
            var input = new[]
            {
                "123 -> x",
                "456 -> y",
                "x AND y -> d",
                "x OR y -> e",
                "x LSHIFT 2 -> f",
                "y RSHIFT 2 -> g",
                "NOT x -> h",
                "NOT y -> i"
            };

            var result = _sut.PartOne(input);
            result.Should().Be("d = 72,e = 507,f = 492,g = 114,h = 65412,i = 65079,x = 123,y = 456");
        }
    }
}
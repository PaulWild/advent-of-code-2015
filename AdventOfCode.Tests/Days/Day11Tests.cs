using System;
using AdventOfCode.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Days
{
    
    public class Day11Tests
    {
        private readonly ISolution _sut = new Day11();
        
        [Fact]
        public void PartOne_WhenCalled_DoesNotThrowNotImplementedException()
        {
            Action act = () =>  _sut.PartOne(_sut.Input());
            
            act.Should().NotThrow<NotImplementedException>();
        }
            
        [Fact]
        public void PartOne_WhenCalled_ShouldWork()
        {
            var res =  _sut.PartOne(new[] { "abcdefgh"});
            res.Should().Be("abcdffaa");
        }
        
        [Fact]
        public void PartOne_WhenCalled_ShouldWorkExample2()
        {
            var res =  _sut.PartOne(new[] { "ghijklmn"});
            res.Should().Be("ghjaabcc");
        }
        
        [Fact]
        public void PartTwo_WhenCalled_DoesNotThrowNotImplementedException()
        {
            Action act = () =>  _sut.PartTwo(_sut.Input());
            
            act.Should().NotThrow<NotImplementedException>();
        }
    }
}
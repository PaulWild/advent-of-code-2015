using System;
using AdventOfCode.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Days
{
    
    public class Day8Tests
    {
        private readonly ISolution _sut = new Day8();
        
        [Fact]
        public void PartOne_WhenCalled_DoesNotThrowNotImplementedException()
        {
            Action act = () =>  _sut.PartOne(_sut.Input());
            
            act.Should().NotThrow<NotImplementedException>();
        }
        
        [Fact]
        public void PartOne_WhenCalled_Works()
        {
            var res = _sut.PartOne(new [] { @"""aaa\""aaa""", @"""\x27""", @"""abc""", @""""""});
            res.Should().Be("12");
        }
        
        [Fact]
        public void PartTwo_WhenCalled_DoesNotThrowNotImplementedException()
        {
            Action act = () =>  _sut.PartTwo(_sut.Input());
            
            act.Should().NotThrow<NotImplementedException>();
        }
        
        [Fact]
        public void PartTwo_WhenCalled_Works()
        {
            var res = _sut.PartTwo(new [] { @"""aaa\""aaa""", @"""\x27""", @"""abc""", @""""""});
            res.Should().Be("19");
        }
    }
}
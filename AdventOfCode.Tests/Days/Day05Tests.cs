using System;
using AdventOfCode.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Days
{
    
    public class Day5Tests
    {
        private readonly ISolution _sut = new Day05();
        
        [Fact]
        public void PartOne_WhenCalled_DoesNotThrowNotImplementedException()
        {
            Action act = () =>  _sut.PartOne(_sut.Input());
            
            act.Should().NotThrow<NotImplementedException>();
        }
        
        [Fact]
        public void PartTwo_WhenCalled_DoesNotThrowNotImplementedException()
        {
            Action act = () =>  _sut.PartTwo(_sut.Input());
            
            act.Should().NotThrow<NotImplementedException>();
        }
        
                
        [Fact]
        public void PartTwo_WhenCalled_ReturnsCorrectly()
        {
            var result =  _sut.PartTwo(new []{"qjhvhtzxzqqjkmpb"});

            result.Should().Be("1");
        }
    }
}
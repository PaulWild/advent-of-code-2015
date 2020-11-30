using System;
using AdventOfCode.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Days
{
    
    public class Day9Tests
    {
        private readonly ISolution _sut = new Day09();
        
        [Fact]
        public void PartOne_WhenCalled_DoesNotThrowNotImplementedException()
        {
            Action act = () =>  _sut.PartOne(_sut.Input());
            
            act.Should().NotThrow<NotImplementedException>();
        }
        
        [Fact]
        public void PartOne_WhenCalled_WorksWithTestData()
        {
            var input = new[]
            {
                "London to Dublin = 464",
                "London to Belfast = 518",
                "Dublin to Belfast = 141"
            };
            
            var res=  _sut.PartOne(input);
            
            res.Should().Be("605");
        }

        [Fact]
        public void PartTwo_WhenCalled_DoesNotThrowNotImplementedException()
        {
            Action act = () => _sut.PartTwo(_sut.Input());

            act.Should().NotThrow<NotImplementedException>();
        }
      
    }
}
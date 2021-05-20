using System;
using System.Configuration;
using System.Threading;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace StopWatch.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Chrono_running_for_10_second()
        {
            var clock = Substitute.For<IClock>();
            clock.Now.Returns(DateTime.Now);
            var chrono = new Chrono(clock);

            chrono.StartStop();
            clock.Now.Returns(clock.Now.AddSeconds(10));
            chrono.StartStop();

            chrono.Elapsed.Should().BeCloseTo(TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(15));
        }

        [Fact]
        public void Chrono_lap_and_reset()
        {
            var clock = Substitute.For<IClock>();
            clock.Now.Returns(DateTime.Now);
            var chrono = new Chrono(clock);

            chrono.StartStop();
            clock.Now.Returns(clock.Now.AddSeconds(10));
            chrono.LapReset();

            chrono.Elapsed.Should().BeCloseTo(TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(15));
            
            clock.Now.Returns(clock.Now.AddSeconds(10));
            chrono.StartStop();

            chrono.Elapsed.Should().BeCloseTo(TimeSpan.FromSeconds(20), TimeSpan.FromMilliseconds(15));

            chrono.StartStop();

            chrono.Elapsed.Should().BeCloseTo(TimeSpan.FromSeconds(00), TimeSpan.FromMilliseconds(15));
        }
    }

}

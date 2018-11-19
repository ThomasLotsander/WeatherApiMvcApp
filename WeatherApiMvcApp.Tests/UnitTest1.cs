using System;
using Xunit;
using Xunit.Abstractions;

namespace WeatherApiMvcApp.Tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {

            var temp = "my class!";
            output.WriteLine("This is output from {0}", temp);
        }
    }
}

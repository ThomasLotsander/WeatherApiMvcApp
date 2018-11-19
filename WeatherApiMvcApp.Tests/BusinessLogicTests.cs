using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApiMvcApp.BLL;
using WeatherApiMvcApp.DAL;
using WeatherApiMvcApp.Models.ApiModels;
using WeatherApiMvcApp.Models.ViewModels;
using Xunit;
using Xunit.Abstractions;

namespace WeatherApiMvcApp.Tests
{
    public class BusinessLogicTests
    {
        private readonly ITestOutputHelper output;

        public BusinessLogicTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ConvertNumberToAccuretTime_NumberIsCorrect_ReturnsDateTime()
        {
            // Arrage
            var mock = new Mock<IDataAccess>();
            var business = new BusinessLogic(mock.Object);
            double seconds = 123456;

           // Act
            DateTime actual  = business.ConvertNumberToAccuretTime(seconds);
            DateTime expected = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(seconds);

            // Assert
            Assert.Equal(expected, actual);
        }

        
        [Fact]
        public void ConvertNumberToAccuretTime_NumberIsNotCorrect_ReturnsError()
        {
            // Arrage
            var data = new Mock<IDataAccess>();
            var business = new BusinessLogic(data.Object);
            
            // Assert
            Assert.Throws<InvalidCastException>(() => business.ConvertNumberToAccuretTime(123123123123123));
        }

        [Fact]
        public void CreateViewModel_ApiCallIsOK_ReturnsViewModel()
        {
            // Arrage
            var data = new Mock<IDataAccess>();

            RootObject rootObject = new RootObject();
            rootObject.cod = 200;
            
            data
                .Setup(x => x.GetWeather(It.IsAny<string>()))
                .Returns(Task.FromResult(rootObject));

            var business = new BusinessLogic(data.Object);
            var result = business.CreateViewModel(rootObject);

            Assert.NotNull(result);

        }

        [Fact]
        public void CreateViewModel_ApiCodeIsNotOK_Null()
        {
            var mock = new Mock<IDataAccess>();

            RootObject root = new RootObject() { cod = 401 };
            var business = new BusinessLogic(mock.Object);
            var result = business.CreateViewModel(root);

            Assert.Null(result);

        }
    }
}

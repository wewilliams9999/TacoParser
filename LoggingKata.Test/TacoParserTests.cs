using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        //Test whether Longitude method works as expected
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)] //-84.677017 is the expected
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange --Parse method is inside TacoParser class
            var tacoParserInstance = new TacoParser();

            //Act
            var actual = tacoParserInstance.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }


        //TODO: Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        public void ShouldParseLatitude(string line, double expected)
        {

            //Arrange --Parse method is inside TacoParser class
            var tacoParse = new TacoParser();

            //Act
            var actual = tacoParse.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Latitude);

        }
    }
}

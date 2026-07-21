using FizzBuzzProblem.Services;
namespace FizzBuzzUniteTesting
{
    public class UnitTest1
    {
        [Fact]
        public void Should_Replace_Third_Word()
        {
            var detector = new FizzBuzzDetector();

            var result = detector.DetectFizzBuzz("One two three four five six seven");

            Assert.Contains("Fizz", result.OutputText);
        }

        [Fact]
        public void Should_Replace_Fifth_Word_With_Buzz()
        {
            var detector = new FizzBuzzDetector();

            var result = detector.DetectFizzBuzz("One two three four five six seven");

            Assert.Contains("Buzz", result.OutputText);
        }

        [Fact]
        public void Should_Replace_Fifteenth_Word_With_FizzBuzz()
        {
            var detector = new FizzBuzzDetector();

            string input =
                "one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen";

            var result = detector.DetectFizzBuzz(input);

            Assert.Contains("FizzBuzz", result.OutputText);
        }

        [Fact]
        public void Should_Count_Correctly()
        {
            var detector = new FizzBuzzDetector();

            string input =
                "one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen";

            var result = detector.DetectFizzBuzz(input);

            Assert.Equal(7, result.Count);
        }

        [Fact]
        public void Should_Throw_When_Input_Is_Null()
        {
            var detector = new FizzBuzzDetector();

            Assert.Throws<ArgumentNullException>(() => detector.DetectFizzBuzz(null));
        }
    }
}

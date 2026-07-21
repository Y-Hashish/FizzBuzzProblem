using FizzBuzzProblem.Services;

namespace FizzBuzzProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string text = "Mary had a little lamb Little lamb, little lamb Mary had a little lamb It's fleece was white as snow";

            var detector = new FizzBuzzDetector();

            var result = detector.DetectFizzBuzz(text);

            Console.WriteLine(result.OutputText);
            Console.WriteLine();
            Console.WriteLine(result.Count);

        }
    }
}

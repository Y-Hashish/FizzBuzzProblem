using FizzBuzzProblem.Services;

namespace FizzBuzzProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine() ;

            var detector = new FizzBuzzDetector();

            var result = detector.DetectFizzBuzz(text);

            Console.WriteLine(result.OutputText);
            Console.WriteLine();
            Console.WriteLine(result.Count);

        }
    }
}

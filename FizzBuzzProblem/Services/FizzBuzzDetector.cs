using FizzBuzzProblem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzzProblem.Services
{
    /// <summary>
    /// Detects every third and fifth alphanumeric word in a text and replaces
    /// them with Fizz, Buzz or FizzBuzz.
    /// </summary>
    public class FizzBuzzDetector
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        private const string FizzBuzz = "FizzBuzz";

        /// <summary>
        /// this method detects every third and fifth alphanumeric word in a text and replaces them with Fizz,
        /// Buzz or FizzBuzz.
        /// in case the word index % 3 == 0 the word it self woll be replaced with Fizz,
        /// in case the word index % 5 == 0 the word it self will be replaced with Buzz,
        /// and in case the word index % 15 == 0 the word it self will be replaced with FizzBuzz.
        /// <param name="input"/> Input text</param>
        /// <returns>FizzBuzzResponse whic contains the output text and the count of the replaced words</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when input length is outside the allowed range.
        /// </exception>
        /// </summary>
        public FizzBuzzResponse DetectFizzBuzz(string input)
        {
            ValidateInput(input);

            var outputBuilder = new StringBuilder();

            int currentWordIndex = 0;
            int replacementCount = 0;
            int currentIndex = 0;

            while (currentIndex < input.Length)
            {
                if (!IsWordCharacter(input[currentIndex]))
                {
                    outputBuilder.Append(input[currentIndex]);
                    currentIndex++;
                    continue;
                }

                int wordStart = currentIndex;

                while (currentIndex < input.Length &&
                       IsWordCharacter(input[currentIndex]))
                {
                    currentIndex++;
                }

                currentWordIndex++;

                string replacement = GetReplacement(currentWordIndex);

                if (string.IsNullOrEmpty(replacement))
                {
                    outputBuilder.Append(input, wordStart, currentIndex - wordStart);
                }
                else
                {
                    outputBuilder.Append(replacement);
                    replacementCount++;
                }
            }

            return new FizzBuzzResponse
            {
                OutputText = outputBuilder.ToString(),
                Count = replacementCount
            };
        }
        /// <summary>
        /// based on the word index,
        /// this method returns the appropriate replacement string (Fizz, Buzz, FizzBuzz) or an empty string 
        /// if no replacement is needed.
        /// </summary>
        /// <param name="wordIndex"></param>
        /// <returns>string</returns>
        private static string GetReplacement(int wordIndex)
        {
            if (wordIndex % 15 == 0)
            {
                return FizzBuzz;
            }

            if (wordIndex % 3 == 0)
            {
                return Fizz;
            }

            if (wordIndex % 5 == 0)
            {
                return Buzz;
            }

            return string.Empty;
        }

        /// <summary>
        /// validate the input string to ensure it is not null and its length is between 7 and 100 characters.
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="ArgumentException"></exception>
        private static void ValidateInput(string input)
        {
            ArgumentNullException.ThrowIfNull(input);

            if (input.Length < 7 || input.Length > 100)
            {
                Console.WriteLine(input.Length);
                throw new ArgumentException(
                    "Input length must be between 7 and 100 characters.",
                    nameof(input));
            }
        }

        /// <summary>
        /// it detect the chars that are part of the word
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private static bool IsWordCharacter(char character)
        {
            return char.IsLetterOrDigit(character) || character == '\'';
        }

    }
}

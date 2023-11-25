using System.Diagnostics;

namespace Quicksort
{
    class Program
    {
        static readonly Random random = new();

        static void Main()
        {
            var timer = new Stopwatch();

            int[] textConvertedIntoArray;

            // Path of the text file with numbers separated by commas
            var PathOfFileWithArrayOfNumbers = "../../../arrayOfNumbers.txt";

            using (var reader = new StreamReader(PathOfFileWithArrayOfNumbers))
            {
                var text = reader.ReadToEnd();

                textConvertedIntoArray = text.Split(",").Select(item => Convert.ToInt32(item)).ToArray();
            }

            timer.Start();
            Console.WriteLine(QuickSort(textConvertedIntoArray));
            timer.Stop();

            Console.WriteLine($"Time elapsed: {timer.ElapsedMilliseconds} milliseconds");

            Console.ReadLine();
        }

        static string QuickSort(int[] arrayOfNumbers)
        {
            if (arrayOfNumbers.Length == 1)
            {
                return $"{arrayOfNumbers[0]}";
            }
            else if (arrayOfNumbers.Length == 0)
            {
                return "";
            }

            var lowestRandomValue = 0;
            var highestRandomValue = arrayOfNumbers.Length - 1;

            var pivot = arrayOfNumbers[random.Next(lowestRandomValue, highestRandomValue)];

            var left = new List<int>();
            var right = new List<int>();
            var sameAsPivot = new List<int>();

            foreach (var item in arrayOfNumbers)
            {
                if (item < pivot)
                {
                    left.Add(item);
                }
                else if (item > pivot)
                {
                    right.Add(item);
                }
                else
                {
                    sameAsPivot.Add(item);
                }
            }

            var text = $"{QuickSort([.. left])},{string.Join(",", sameAsPivot)},{QuickSort([.. right])}";

            if (text.StartsWith(','))
            {
                text = text[1..];
            }

            if (text.EndsWith(','))
            {
                text = text[..^1];
            }

            return text;
        }
    }
}

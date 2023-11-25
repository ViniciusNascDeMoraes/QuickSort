using System.Diagnostics;

namespace Quicksort
{
    class Program
    {
        static readonly Random random = new();

        static void Main()
        {
            var timer = new Stopwatch();

            var textConverted = new List<int>();

            // Go to this path and put a textfile with numbers separated by commas if desired, example: 1,2,3,4,5
            var PathOfFileWithArrayOfNumbers = "../../../arrayOfNumbers.txt";

            using (var reader = new StreamReader(PathOfFileWithArrayOfNumbers))
            {
                var text = reader.ReadToEnd();

                var textDivided = text.Split(",");

                foreach (var item in textDivided)
                {
                    textConverted.Add(Convert.ToInt32(item));
                }
            }

            timer.Start();
            Console.WriteLine(QuickSort([.. textConverted]));
            timer.Stop();

            Console.WriteLine($"Time elapsed: {timer.ElapsedMilliseconds} milliseconds");

            Console.ReadLine();
        }

        static string QuickSort(int[] arr)
        {
            if (arr.Length == 1)
            {
                return arr[0].ToString();
            }
            else if (arr.Length == 0)
            {
                return "";
            }

            var pivot = arr[random.Next(0, arr.Length - 1)];

            var left = new List<int>();
            var right = new List<int>();
            var sameAsPivot = new List<int>();

            foreach (var item in arr)
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

            if (text.StartsWith(Convert.ToChar(",")))
            {
                text = text[1..];
            }

            if (text.EndsWith(Convert.ToChar(",")))
            {
                text = text[..^1];
            }

            return text;
        }
    }
}

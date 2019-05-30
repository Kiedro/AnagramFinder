using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagramsFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Run program with single arguments - full path to file containing text data");
            }

            IEnumerable<Word> words;
            try
            {
                using (var streamReader = new StreamReader(args[0]))
                {
                    words = DataParser.Parse(streamReader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't read the file.");
                Console.WriteLine(ex.Message);
                return;
            }

            var processor = new AnagramsProcessor(words);

            Program.PrintResult("Anagrams:", processor.Anagrams);
            Program.PrintResult("Anagrams with longest words:", processor.LongestAnagrams);
            Program.PrintResult("Anagrams with most words:", processor.MostWordsInGroup);
        }

        private static void PrintResult(string message, IEnumerable<IGrouping<string, Word>> result)
        {
            Console.WriteLine(message);
            foreach (var group in result)
            {

                Console.WriteLine(string.Join(' ', group));
            }
            Console.WriteLine();
        }
    }
}

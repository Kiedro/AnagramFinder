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

            var dictionary = new List<IGrouping<string, Word>>();
            try
            {
                using (var streamReader = new StreamReader(args[0]))
                {
                    List<Word> words = new List<Word>();
                    while (streamReader.EndOfStream == false)
                    {
                        var inputLine = streamReader.ReadLine();
                        if (string.IsNullOrWhiteSpace(inputLine))
                        {
                            continue;
                        }
                        var word = new Word(inputLine);
                        words.Add(word);
                    }
                    dictionary = words.GroupBy(x => x.SortedCharacters).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldt'n read the file.");
                Console.WriteLine(ex.Message);
            }

            foreach (var group in dictionary)
            {
                //Console.WriteLine(group.Key);
                Console.WriteLine(String.Join(' ', group));
            }


        }
    }
}

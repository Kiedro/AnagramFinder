using System.Collections.Generic;
using System.IO;

namespace AnagramsFinder
{
    static class DataParser
    {
        public static IEnumerable<Word> Parse(StreamReader reader)
        {
            List<Word> words = new List<Word>();
            while (reader.EndOfStream == false)
            {
                var inputLine = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    continue;
                }
                var word = new Word(inputLine);
                words.Add(word);
            }

            return words;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramsFinder
{
    public class AnagramsProcessor
    {
        public List<IGrouping<string, Word>> Anagrams { get; }

        public List<IGrouping<string, Word>> MostWordsInGroup => GetGroupingsBy(x => x.Count());

        public List<IGrouping<string, Word>> LongestAnagrams => GetGroupingsBy(x => x.Key.Length);

        public AnagramsProcessor(IEnumerable<Word> words)
        {
            this.Anagrams = words.GroupBy(x => x.SortedCharacters).Where(x => x.Count() > 1).ToList();
        }

        private List<IGrouping<string, Word>> GetGroupingsBy(Func<IGrouping<string, Word>, int> expression)
        {
            int currentMax = 0;
            List<IGrouping<string, Word>> result = new List<IGrouping<string, Word>>();
            foreach (var group in this.Anagrams)
            {
                if (expression.Invoke(group) > currentMax)
                {
                    result.Clear();
                    result.Add(group);
                    currentMax = expression.Invoke(group);
                    continue;
                }

                if (expression.Invoke(group) == currentMax)
                {
                    result.Add(group);
                    continue;
                }
            }

            return result;
        }
    }
}


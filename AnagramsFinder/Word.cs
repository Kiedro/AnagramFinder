using System;

namespace AnagramsFinder
{
    public class Word
    {
        public string OrginalWord { get; }

        public string SortedCharacters { get; }

        public Word(string word)
        {
            this.OrginalWord = word.Trim();

            var characters = OrginalWord.ToLowerInvariant().ToCharArray();
            Array.Sort<char>(characters);
            this.SortedCharacters = string.Concat(characters);
        }

        public override string ToString()
        {
            return this.OrginalWord;
        }
    }
}

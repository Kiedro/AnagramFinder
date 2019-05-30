using System;

namespace AnagramsFinder
{
    public class Word
    {
        public string OrginalWord { get; }

        public string SortedCharacters { get; }

        public Word(string word)
        {
            this.OrginalWord = word;

            var characters = OrginalWord.ToLowerInvariant().ToCharArray();
            Array.Sort<char>(characters);
            this.SortedCharacters = String.Concat(characters);
        }

        public override string ToString()
        {
            return this.OrginalWord;
        }
    }
}

using AnagramsFinder;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AnagramFinderTests
{
    public class AnagramsProcessorTests
    {
        [Fact]
        public void Anagrams_AnagramWords_AnagramsGroupings()
        {
            // Arrange
            var words = CreateWords("abc", "bca", "ab", "ba");

            // Act
            var processor = new AnagramsProcessor(words);

            var result = processor.Anagrams;

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void LongestAnagrams_GroupingsWithSameWordLength_2GroupsWithLongestAnagrams()
        {
            // Arrange
            var words = CreateWords("abcd", "bcda", "ab", "bc", "qwer", "rewq");

            // Act
            var processor = new AnagramsProcessor(words);

            var result = processor.LongestAnagrams;

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void MostWordsInGroup_GroupingsWithWordCount_2GroupsWithMostWords()
        {
            // Arrange
            var words = CreateWords("abcde", "bcdae", "ab", "bc", "qwert", "trewq");

            // Act
            var processor = new AnagramsProcessor(words);

            var result = processor.MostWordsInGroup;

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void Anagrams_NoAnagramsInInput_EmptyResult()
        {
            // Arrange
            var words = CreateWords("a", "ab", "abc");

            // Act
            var processor = new AnagramsProcessor(words);

            var result = processor.MostWordsInGroup;

            // Assert
            Assert.Empty(result);
        }

        private static IEnumerable<Word> CreateWords(params string[] input)
        {
            return (input.Select(item => new Word(item))).ToList();
        }
    }
}

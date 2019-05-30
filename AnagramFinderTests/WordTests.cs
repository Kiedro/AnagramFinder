using Xunit;
using AnagramsFinder;

namespace AnagramFinderTests
{
    public class WordTests
    {
        [Theory]
        [InlineData("abc", "abc")]
        [InlineData("bca", "abc")]
        [InlineData("BCA", "abc")]
        [InlineData(" cba ", "abc")]
        [InlineData("cba1", "1abc")]
        public void SortedCharacters_ValidInput_LowercaseSortedString(string input, string expected)
        {
            var word = new Word(input);

            Assert.Equal(word.SortedCharacters, expected);
        }
    }
}

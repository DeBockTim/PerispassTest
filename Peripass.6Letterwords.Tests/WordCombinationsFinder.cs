using System;
using System.Collections.Generic;
using FluentAssertions;
using Perispass._6Letterwords.Domain.Services;
using Xunit;

namespace Perispass._6Letterwords.Tests
{
    public class WordCombinationsFinderTests
    {
        [Fact]
        public void Find_ShouldFindAllValidCombinationsForNarrow()
        {
            // A
            var words = new List<string>
            {
                "na", "pa", "to", "yo", "lo", "rrow", "ro", "n", "a", "ow", "wo", "rr","narrow"
            };

            var finder = new WordCombinationsFinder();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // A
            finder.Find(words);
            string cleanedOutput = consoleOutput.ToString().Replace("\r\n", " ").Trim();

            // A
            consoleOutput.ToString().Should().Contain("Number of word parts: 12");
            consoleOutput.ToString().Should().Contain("Number of existing 6 letter words: 1");
            consoleOutput.ToString().Should().Contain("\r\n");

            // A
            consoleOutput.ToString().Should().Contain("na+rrow=narrow");
            consoleOutput.ToString().Should().Contain("n+a+rr+ow=narrow");
            consoleOutput.ToString().Should().Contain("na+rr+ow=narrow");
            consoleOutput.ToString().Should().Contain("n+a+rrow=narrow");
        }
        [Fact]
        public void Find_ShouldNotFindAnyCombinationsForNarrow()
        {
            // A
            var words = new List<string>
            {
                "na", "pa", "to", "yo", "lo", "rrow", "ro", "n", "a", "ow", "wo", "rr"
            };

            var finder = new WordCombinationsFinder();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // A
            finder.Find(words);
            string cleanedOutput = consoleOutput.ToString().Replace("\r\n", " ").Trim();

            // A
            consoleOutput.ToString().Should().Contain("Number of word parts: 12");
            consoleOutput.ToString().Should().Contain("Number of existing 6 letter words: 0");

            // A
            consoleOutput.ToString().Should().NotContain("=narrow");

        }
    }
}

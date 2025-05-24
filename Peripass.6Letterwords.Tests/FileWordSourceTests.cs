using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Perispass._6Letterwords.Domain.Port;
using Perispass._6Letterwords.Infrastructure;
using Xunit;

namespace Peripass._6Letterwords.Tests
{
    public class FileWordSourceTests
    {
        private readonly Mock<IWordSource> _mockWordSource;
        private readonly string _testFilePath;

        public FileWordSourceTests()
        {
            _testFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "testfile.txt");
            _mockWordSource = new Mock<IWordSource>();
        }

        [Fact]
        public void ReadWords_ShouldReadFromRealFile()
        {
            // A
            var testFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "testfile.txt");

            var wordsInFile = new[] { "  Apple  ", "banana", "longword", "  car  ", "" };
            Directory.CreateDirectory(Path.GetDirectoryName(testFilePath));
            File.WriteAllLines(testFilePath, wordsInFile);

            // A
            var wordSource = new FileWordSource(testFilePath);
            var result = wordSource.ReadWords().ToList();

            // A
            result.Count.Should().Be(3);
            result.Should().Contain("apple");
            result.Should().Contain("banana");
            result.Should().Contain("car");

            File.Delete(testFilePath);
        }

        // no file handle
    }
}

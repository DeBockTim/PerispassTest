using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Perispass._6Letterwords.Domain.Port;

namespace Perispass._6Letterwords.Infrastructure
{
    public class FileWordSource : IWordSource
    {
        private readonly string _path;
        private const int MaxLength = 6;

        public FileWordSource(string path) => _path = path;

        public IEnumerable<string> ReadWords()
        {
            return File.ReadLines(_path)
                       .Select(w => w.Trim().ToLowerInvariant())
                       .Where(w => !string.IsNullOrEmpty(w) && w.Length <= MaxLength);
        }
    }
}

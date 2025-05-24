using Perispass._6Letterwords.Domain.Services;
using Perispass._6Letterwords.Infrastructure;

var source = new FileWordSource("input.txt");
var finder = new WordCombinationsFinder();

finder.Find(source.ReadWords());
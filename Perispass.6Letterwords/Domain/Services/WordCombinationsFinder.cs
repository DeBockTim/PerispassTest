using System;
using System.Collections.Generic;
using System.Linq;
namespace Perispass._6Letterwords.Domain.Services;
public class WordCombinationsFinder
{
    private int _targetLength = 6;

    public void Find(IEnumerable<string> words)
    {
        var wordList = words
            .Select(w => w.Trim().ToLowerInvariant())
            .Where(w => !string.IsNullOrEmpty(w) && w.Length <= _targetLength)
            .Distinct()
            .ToList();

        // HashSets for efficiency
        var wordPartSet = new HashSet<string>(wordList.Where(w => w.Length < _targetLength));
        var existing6LetterWordsInFile = new HashSet<string>(wordList.Where(w => w.Length == _targetLength));

        Console.WriteLine($"Number of word parts: {wordPartSet.Count}\nNumber of existing 6 letter words: {existing6LetterWordsInFile.Count}");

        // Run combo check for each word in the wordPartSet
        var visitedPaths = new HashSet<string>();
        foreach (var word in wordPartSet)
        {
            FindCombinations(word, new List<string> { word }, wordPartSet, existing6LetterWordsInFile, visitedPaths);
        }
    }

    // Recursively check paths for valid combinations
    private void FindCombinations(
        string current,
        List<string> path,
        HashSet<string> wordPartSet,
        HashSet<string> existing6LetterWordsInFile,
        HashSet<string> visitedPaths)
    {
        // Combo could be bigger than 6
        if (current.Length > _targetLength)
            return;

        // If the current length is 6, check if it's a valid word
        if (current.Length == _targetLength)
        {
            if (existing6LetterWordsInFile.Contains(current))
            {
                string pathKey = string.Join("+", path);
                if (visitedPaths.Add(pathKey))
                {
                    Console.WriteLine($"{pathKey}={current}");
                }
                else
                {
                    Console.WriteLine($"{pathKey} already exists");
                }
            }
            return;
        }

        // Too short, find the next word to add
        foreach (var word in wordPartSet)
        {
            // To check space combinations, we concatenate the words with a space in between
            path.Add(word);
            FindCombinations(current + word, path, wordPartSet, existing6LetterWordsInFile, visitedPaths);
            path.RemoveAt(path.Count - 1); // Backtrack
        }
    }
}
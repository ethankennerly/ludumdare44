using UnityEngine;
using UnityEditor;

namespace FineGameDesign.Anagram
{
    public static class CrosswordGeneratorEditor
    {
        [MenuItem("Superpow/Play Mode/Log Error If Missing Answer In Crossword")]
        private static void LogErrorIfMissingAnswerInCrossword()
        {
            CrosswordGenerator generator = new CrosswordGenerator();
            var levels = AnagramLevelsController.instance.Levels;
            foreach (var level in levels)
            {
                var wordList = CUtils.BuildListFromString<string>(level.answers);
                generator.SetWords(wordList);
                generator.RTL = ConfigController.Config.isRightToLeftLanguage;
                var crossedWords = CrosswordShuffler.Generate(generator);
                if (generator.allWordsFit)
                    continue;

                Debug.LogError("Not all words fit in level word=" + level.word);
            }
        }
    }
}

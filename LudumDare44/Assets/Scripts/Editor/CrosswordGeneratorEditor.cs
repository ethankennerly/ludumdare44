using UnityEngine;
using UnityEditor;

namespace FineGameDesign.Anagram
{
    public static class CrosswordGeneratorEditor
    {
        [MenuItem("Superpow/Play Mode/Log Missing Answer In Crossword")]
        private static void LogMissingAnswerInCrossword()
        {
            CrosswordGenerator generator = new CrosswordGenerator();
            var levels = AnagramLevelsController.instance.Levels;
            foreach (var level in levels)
            {
                var wordList = CUtils.BuildListFromString<string>(level.answers);
                generator.SetWords(wordList);
                generator.RTL = ConfigController.Config.isRightToLeftLanguage;
                var crossedWords = generator.Generate();
                if (generator.allWordsFit)
                    continue;

                Debug.LogWarning("Not all words fit in level word=" + level.word);
            }
        }
    }
}

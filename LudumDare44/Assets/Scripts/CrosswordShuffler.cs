using FineGameDesign.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace FineGameDesign.Anagram
{
    public static class CrosswordShuffler
    {
        /// <remarks>
        /// Shuffles up to 256 times.
        /// Otherwise, about 60 words did not fit in 720 levels.
        /// </remarks>
        public static List<CrossedWord> Generate(CrosswordGenerator generator)
        {
            int maxAttempts = 256;
            List<CrossedWord> originalCrossedWords = null;
            List<string> originalWords = null;
            for (int attempt = 0; attempt < maxAttempts; ++attempt)
            {
                generator.crossedWords = generator.TryGenerate();
                if (generator.allWordsFit)
                    return generator.crossedWords;

                if (originalCrossedWords == null)
                    originalCrossedWords = new List<CrossedWord>(generator.crossedWords);

                if (originalWords == null)
                    originalWords = new List<string>(generator.words);

                Deck.ShuffleList(generator.words);
            }

            generator.crossedWords = originalCrossedWords;
            generator.words = originalWords;
            Debug.LogError("Not all words fit. First word in generator was " + generator.words[0]);

            return generator.crossedWords;
        }
    }
}

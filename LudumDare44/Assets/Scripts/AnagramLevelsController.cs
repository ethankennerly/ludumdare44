using FineGameDesign.Utils;

namespace FineGameDesign.Anagram
{
    public sealed class AnagramLevelsController : ASingleton<AnagramLevelsController>
    {
        public AnagramLevel[] Levels { get; set; }
    }
}

using FineGameDesign.Utils;

namespace FineGameDesign.Anagram
{
    public sealed class AnagramLevelsController : ASingleton<AnagramLevelsController>
    {
        private AnagramLevel[] m_Levels;

        public AnagramLevel[] Levels
        {
            get
            {
                if (m_Levels == null)
                {
                    var parser = AnagramLevelsParser.instance;
                    parser.ParseLevels();
                    m_Levels = parser.Levels;
                }
                return m_Levels;
            }
        }
    }
}

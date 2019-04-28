using FineGameDesign.Utils;
using UnityEngine;

namespace FineGameDesign.Anagram
{
    public sealed class AnagramLevelsParser : MonoBehaviour
    {
        [SerializeField]
        private TextAsset m_LevelsCsv;

        private string[][] m_LevelsTable;

        public void ParseLevels()
        {
            string csvText = m_LevelsCsv.text;
            
            m_LevelsTable = StringUtil.ParseCsv(csvText);
        }
    }
}

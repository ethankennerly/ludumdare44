using FineGameDesign.Utils;
using System;
using UnityEngine;

namespace FineGameDesign.Anagram
{
    public sealed class AnagramLevelsParser : MonoBehaviour
    {
        [SerializeField]
        private TextAsset m_LevelsCsv;

        [SerializeField]
        private string m_WordColumnName = "word";
        private int m_WordColumn;

        [SerializeField]
        private string m_AnswersColumnName = "answers";
        private int m_AnswersColumn;

        [SerializeField]
        private string m_ValidWordsColumnName = "validWords";
        private int m_ValidWordsColumn;

        private string[][] m_LevelsTable;

        private AnagramLevel[] m_Levels;
        public AnagramLevel[] Levels
        {
            get { return m_Levels; }
        }

        private int m_NumLevels;

        public void ParseLevels()
        {
            string csvText = m_LevelsCsv.text;
            
            m_LevelsTable = StringUtil.ParseCsv(csvText);
            m_NumLevels = m_LevelsTable.Length - 1;
            m_Levels = new AnagramLevel[m_NumLevels];
            string[] header = m_LevelsTable[0];
            m_WordColumn = Array.IndexOf(header, m_WordColumnName);
            m_AnswersColumn = Array.IndexOf(header, m_AnswersColumnName);
            m_ValidWordsColumn = Array.IndexOf(header, m_ValidWordsColumnName);
            for (int index = 0; index < m_NumLevels; ++index)
            {
                int rowIndex = index + 1;
                string[] row = m_LevelsTable[rowIndex];
                string word = row[m_WordColumn];
                string answers = row[m_AnswersColumn];
                string validWords = row[m_ValidWordsColumn];
                var level = new AnagramLevel();
                level.word = word;
                level.answers = answers;
                level.validWords = validWords;
                m_Levels[index] = level;
            }
        }
    }
}

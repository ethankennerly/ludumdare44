using System;
using UnityEngine;

namespace FineGameDesign.Text
{
    public sealed class LetterPositioner : MonoBehaviour
    {
        [SerializeField]
        private TextAsset m_TextToPosition;

        [SerializeField]
        private Vector3 m_StartLocalPosition;

        [SerializeField]
        private Vector3 m_LocalOffsetPerColumn;

        [SerializeField]
        private Vector3 m_LocalOffsetPerRow;

        private char[] m_PrintableCharacters;
        public char[] PrintableCharacters
        {
            get { return m_PrintableCharacters; }
        }

        private Vector3[] m_LocalPositions;
        private Vector3[] LocalPositions
        {
            get { return m_LocalPositions; }
        }

        public void ParseText()
        {
            string textToPosition = m_TextToPosition.text;
            // Last character is end of file.
            int numChars = textToPosition.Length - 1;
            m_PrintableCharacters = new char[numChars];
            m_LocalPositions = new Vector3[numChars];
            int printableCharIndex = 0;
            Vector3 localPosition = m_StartLocalPosition;
            for (int charIndex = 0; charIndex < numChars; ++charIndex)
            {
                char character = textToPosition[charIndex];
                if (character == '\n')
                {
                    localPosition += m_LocalOffsetPerRow;
                    continue;
                }
                m_PrintableCharacters[printableCharIndex] = character;
                m_LocalPositions[printableCharIndex] = localPosition;
                printableCharIndex++;
                localPosition += m_LocalOffsetPerColumn;
            }
            int numPrintableCharacters = printableCharIndex + 1;
            Array.Resize(ref m_PrintableCharacters, numPrintableCharacters);
            Array.Resize(ref m_LocalPositions, numPrintableCharacters);
        }
    }
}

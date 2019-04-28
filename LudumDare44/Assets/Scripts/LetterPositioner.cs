using UnityEngine;

namespace FineGameDesign.Text
{
    public sealed class LetterPositioner : MonoBehaviour
    {
        [SerializeField]
        private TextAsset m_TextAsset;

        [SerializeField]
        private Vector3 m_StartLocalPosition;

        [SerializeField]
        private Vector3 m_LocalOffsetPerColumn;

        [SerializeField]
        private Vector3 m_LocalOffsetPerRow;

        private string m_Letters;
        public string Letters
        {
            get { return m_Letters; }
        }

        private Vector3 m_LocalPositions;
        private Vector3 LocalPositions
        {
            get { return m_LocalPositions; }
        }

        // TODO
        public void ParseText()
        {
        }
    }
}

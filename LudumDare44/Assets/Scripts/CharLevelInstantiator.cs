using System;
using UnityEngine;

namespace FineGameDesign.Text
{
    public sealed class CharLevelInstantiator : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_PreviousLevelPrefab;
        [SerializeField]
        private GameObject m_CurrentLevelPrefab;
        [SerializeField]
        private GameObject m_NextLevelPrefab;

        [SerializeField]
        private int m_OverrideCurrentIndex = -1;

        /// <remarks>
        /// Spawn prefabs at positions.
        /// TODO: For pre/cur levels, reveal letters.
        /// </remarks>
        public void Instantiate(int currentIndex, Transform parent, char[] characters, Vector3[] localPositions)
        {
            if (m_OverrideCurrentIndex >= 0)
                currentIndex = m_OverrideCurrentIndex;

            int numLevels = localPositions.Length;
            if (currentIndex >= numLevels)
                currentIndex = numLevels;
            
            for (int previousIndex = 0; previousIndex < currentIndex; ++previousIndex)
            {
                GameObject previousClone = Instantiate(m_PreviousLevelPrefab, parent);
                previousClone.name += "_" + previousIndex;
                ((RectTransform)(previousClone.transform)).anchoredPosition = localPositions[previousIndex];
                LevelButton previousButton = previousClone.GetComponent<LevelButton>();
                previousButton.LevelIndex = previousIndex;
                previousButton.LevelNumberText.text = characters[previousIndex].ToString();
            }

            if (currentIndex >= numLevels)
                return;

            GameObject currentClone = Instantiate(m_CurrentLevelPrefab, parent);
            currentClone.name += "_" + currentIndex;
            ((RectTransform)(currentClone.transform)).anchoredPosition = localPositions[currentIndex];
            LevelButton currentButton = currentClone.GetComponent<LevelButton>();
            currentButton.LevelIndex = currentIndex;

            for (int nextIndex = currentIndex + 1; nextIndex < numLevels; ++nextIndex)
            {
                GameObject nextClone = Instantiate(m_NextLevelPrefab, parent);
                nextClone.name += "_" + nextIndex;
                ((RectTransform)(nextClone.transform)).anchoredPosition = localPositions[nextIndex];
            }
        }
    }
}

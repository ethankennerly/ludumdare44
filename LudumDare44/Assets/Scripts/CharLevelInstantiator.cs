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

        /// <remarks>
        /// Spawn prefabs at positions.
        /// TODO: For pre/cur levels, reveal letters.
        /// </remarks>
        public void Instantiate(int currentIndex, Transform parent, char[] characters, Vector3[] localPositions)
        {
            int numLevels = localPositions.Length;
            if (currentIndex >= numLevels)
                currentIndex = numLevels - 1;
            
            for (int previousIndex = 0; previousIndex < currentIndex; ++previousIndex)
            {
                GameObject previousClone = Instantiate(m_PreviousLevelPrefab, parent);
                ((RectTransform)(previousClone.transform)).anchoredPosition = localPositions[previousIndex];
            }

            GameObject currentClone = Instantiate(m_CurrentLevelPrefab, parent);
            ((RectTransform)(currentClone.transform)).anchoredPosition = localPositions[currentIndex];

            for (int nextIndex = currentIndex + 1; nextIndex < numLevels; ++nextIndex)
            {
                Vector3 nextPosition = parent.TransformPoint(localPositions[nextIndex]);
                GameObject nextClone = Instantiate(m_NextLevelPrefab, parent);
                ((RectTransform)(nextClone.transform)).anchoredPosition = localPositions[nextIndex];
            }
        }
    }
}

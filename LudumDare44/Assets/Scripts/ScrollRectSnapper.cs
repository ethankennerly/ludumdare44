using UnityEngine;
using UnityEngine.UI;

namespace FineGameDesign.UI
{
    public static class ScrollRectSnapper
    {
        /// <remarks>
        /// Adapted from:
        /// <a href="https://stackoverflow.com/questions/30766020/how-to-scroll-to-a-specific-element-in-scrollrect-with-unity-ui#_=_">
        /// How to scroll to a specific element in ScrollRect with Unity UI?
        /// </a>
        public static void SnapTo(ScrollRect scroll, Transform target)
        {
            if (scroll == null)
            {
                Debug.LogError("Expected scroll was defined.");
                return;
            }

            RectTransform content = scroll.content;
            if (content == null)
            {
                Debug.LogError("Expected content defined in scroll=" + scroll);
                return;
            }
            Transform scrollTransform = scroll.transform;

            if (target == null)
            {
                Debug.LogError("Expected target defined for content=" + content);
                return;
            }

            Canvas.ForceUpdateCanvases();

            Vector2 contentInScroll = scrollTransform.InverseTransformPoint(content.position);
            Vector2 targetInScroll = scrollTransform.InverseTransformPoint(target.position);
            Vector2 nextContentPosition = contentInScroll - targetInScroll;
            if (!scroll.horizontal)
                nextContentPosition.x = contentInScroll.x;
            if (!scroll.vertical)
                nextContentPosition.y = contentInScroll.y;
            content.anchoredPosition = nextContentPosition;
        }

        public static Transform GetChild(Transform parent, int childIndex)
        {
            if (parent == null)
            {
                Debug.LogError("Expected parent defined.");
                return null;
            }

            int numChildren = parent.childCount;
            if (numChildren == 0)
            {
                Debug.LogError("Expected parent has a child. parent=" + parent);
                return null;
            }

            childIndex = Mathf.Clamp(childIndex, 0, numChildren - 1);
            Transform child = parent.GetChild(childIndex);
            return child;
        }
    }
}

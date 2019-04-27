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
            Canvas.ForceUpdateCanvases();

            RectTransform content = scroll.content;
            Transform scrollTransform = scroll.transform;
            Vector2 contentInScroll = scrollTransform.InverseTransformPoint(content.position);
            Vector2 targetInScroll = scrollTransform.InverseTransformPoint(target.position);
            Vector2 nextContentPosition = contentInScroll - targetInScroll;
            content.anchoredPosition = nextContentPosition;
        }

        public static void SnapToChild(ScrollRect scroll, int childIndex)
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
            if (content.childCount == 0)
            {
                Debug.LogError("Expected content has a child. content=" + content);
                return;
            }

            childIndex = Mathf.Clamp(childIndex, 0, content.childCount - 1);
            Transform child = content.GetChild(childIndex);
            SnapTo(scroll, child);
        }
    }
}

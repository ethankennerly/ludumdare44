using UnityEngine;

namespace FineGameDesign.UI
{
    public static class AspectScaler
    {
        public static float FitInSpace(float minX, float minY, float maxX, float maxY,
            float maxScale = 1f, float spaceX = 0.5f, float spaceY = 0.5f)
        {
            Vector2 size = new Vector2(maxX - minX, maxY - minY);
            Vector2 scale = new Vector2(spaceX / size.x, spaceY / size.y);
            float minScale = scale.x > scale.y ? scale.y : scale.x;
            if (minScale > maxScale)
                minScale = maxScale;
            return minScale;
        }
    }
}

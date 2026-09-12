using UnityEngine;

namespace UUP.Utilities.MeshRendererUtils
{
    public static class MeshRendererUtilities
    {
        public static void SetColor(MeshRenderer rend, Color color)
        {
            rend.material.color = color;
        }

        public static void LerpColor(MeshRenderer rend, Color startColor, Color endColor, float fraction)
        {
            rend.material.color = Color.Lerp(startColor, endColor, fraction);
        }

        public static void SetAlpha(MeshRenderer rend, float alpha)
        {
            var color = rend.material.color;
            rend.material.color = new Color(color.r, color.g, color.b, alpha);
        }

        public static void LerpAlpha(MeshRenderer rend, float startAlpha, float endAlpha, float fraction)
        {
            var color = rend.material.color;
            var startColor = new Color(color.r, color.g, color.b, startAlpha);
            var endColor = new Color(color.r, color.g, color.b, endAlpha);
            rend.material.color = Color.Lerp(startColor, endColor, fraction);
        }

        public static void BlackFadeLerper(MeshRenderer rend, float fraction)
        {
            Color color = Color.black;
            Color startColor = new Color(color.r, color.g, color.b, 0);
            Color endColor = new Color(color.r, color.g, color.b, 1);
            rend.material.color = Color.Lerp(startColor, endColor, fraction);
        }

        // Adding more methods is possible but also depends on the shader properties of the material
        public static void SetEmission(MeshRenderer rend, Color emission)
        {
            rend.material.SetColor("_EmissionColor", emission);
        }

        public static void LerpEmission(MeshRenderer rend, Color startEmission, Color endEmission, float fraction)
        {
            rend.material.SetColor("_EmissionColor", Color.Lerp(startEmission, endEmission, fraction));
        }

    }
}

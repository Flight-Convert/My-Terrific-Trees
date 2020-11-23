using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class DesaturationEffect : MonoBehaviour
{
    public Material desaturationMat;
    float saturation;

    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        // Calculate the current saturation based on the score
        saturation = GameManager.instance.score / GameManager.instance.targetScore;
        saturation = Mathf.Clamp(saturation, 0f, 1f);
        desaturationMat.SetFloat("_Saturation", saturation);

        // Apply the desaturation effect to the screen
        RenderTexture rt = RenderTexture.GetTemporary(src.width, src.height);
        Graphics.Blit(src, dst, desaturationMat);
        RenderTexture.ReleaseTemporary(rt);
    }
}

using DG.Tweening;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class CameraFader : MonoBehaviour
{
    public Image Image;
    public void FadeOut(float duration)
    {
        Image.DOFade(1f, duration);
    }

    public void FadeIn(float duration)
    {
        Image.DOFade(0f, duration);
    }
}
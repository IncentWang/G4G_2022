using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class CameraFader : MonoBehaviour
{
    public Image Image;
    public void FadeOut(float duration)
    {
        iTween.FadeTo(Image.gameObject, 0, duration);
    }
}
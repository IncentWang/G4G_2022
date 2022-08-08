using System.Collections;
using System.Collections.Generic;
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
        StartCoroutine(FadeinWithDelay());
        // Image.DOFade(0f, duration);
    }

    private IEnumerator FadeinWithDelay()
    {
        yield return new WaitForSeconds(1f);
        Image.DOFade(0f, 1f);
    }
}
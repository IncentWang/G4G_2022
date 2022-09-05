using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UIFramework;
using DG.Tweening;

public class DoorRotate : MonoBehaviour
{
    public RectTransform leftRectTransform;
    public RectTransform rightRectTransform;
    public RectTransform imageRectTransform;

    private Sequence sequence;

    private void Start()
    {
        
        imageRectTransform.DORotate(new Vector3(0, 0, 45), 1f).SetEase(Ease.Linear).SetLoops(-1,LoopType.Incremental).SetId("imageRotate");
    }
    public void OnClickStartButton()
    {
        sequence = DOTween.Sequence();
        sequence.Append(leftRectTransform.DORotate(new Vector3(0, -91, 0), 1f).OnComplete(() => {
            UIManager.Instance.EnterNextScene();
            DOTween.Kill("imageRotate");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }));
        sequence.Insert(0,rightRectTransform.DORotate(new Vector3(0, 90, 0), 1f));
    }

}

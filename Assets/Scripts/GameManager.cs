using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 使用该类来放置游戏中的所有游戏时数据、Flowchart、工具函数
    public GameObject NeedBubble;
    public AudioClip clip;
    public Transform cam;

    /// <summary>
    /// 显示客人头上的需求泡泡。
    /// </summary>
    public void ShowNeedBubble()
    {
        NeedBubble.SetActive(true);
    }

    /// <summary>
    /// 将客人头上的需求泡泡隐藏。
    /// </summary>
    public void HideNeedBubble()
    {
        NeedBubble.SetActive(false);
    }

    public void Update()
    {
        // 仅用于测试API
        if (Input.GetKeyDown(KeyCode.C))
        {
            ShowNeedBubble();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            HideNeedBubble();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            AudioSource.PlayClipAtPoint(clip, cam.position);
        }
    }

    public void ChangeToDart()
    {
        
    }
}
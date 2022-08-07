using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 使用该类来放置游戏中的所有游戏时数据、Flowchart、工具函数
    public GameObject NeedBubble;

    public void ShowNeedBubble()
    {
        NeedBubble.SetActive(true);
    }

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
    }
}
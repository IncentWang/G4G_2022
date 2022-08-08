using Fungus;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 使用该类来放置游戏中的所有游戏时数据、Flowchart、工具函数
    public GameObject NeedBubble;
    public AudioClip clip;
    public Transform cam;
    public Flowchart Flowchart;

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

    public void ContinueStory(bool drinkStatus, bool dartStatus)
    {
        string currentProcess = Flowchart.GetStringVariable("StoryProcess");
        Flowchart.SetBooleanVariable("AlocholStatus", drinkStatus);
        Flowchart.SetBooleanVariable("DartsEvent", dartStatus);

        switch (currentProcess)
        {
            case "营救人质上":
                Flowchart.ExecuteBlock("营救人质（上）调酒后");
                break;
            case "营救人质下":
                Flowchart.ExecuteBlock("营救人质（下）调酒后");
                break;
            case "断油行动":
                Flowchart.ExecuteBlock("断油行动调酒后");
                break;
            case "猎杀狙击手":
                Flowchart.ExecuteBlock("猎杀狙击手（调酒后）");
                break;
            // case "营救人质上":
            //     Flowchart.ExecuteBlock("营救人质（下）调酒后");
            //     break;
            // case "营救人质上":
            //     Flowchart.ExecuteBlock("营救人质（下）调酒后");
            //     break;
            // case "营救人质上":
            //     Flowchart.ExecuteBlock("营救人质（下）调酒后");
            //     break;
            // case "营救人质上":
            //     Flowchart.ExecuteBlock("营救人质（下）调酒后");
            //     break;
        }
    }
}
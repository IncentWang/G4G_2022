using Fungus;
using UIFramework;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // 使用该类来放置游戏中的所有游戏时数据、Flowchart、工具函数
    public GameObject NeedBubble;
    public AudioClip clip;
    public Transform cam;
    public Flowchart Flowchart;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(this);
    }

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
        UIManager.Instance.PushPanel(UIPanelType.Shooter);
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
            case "营救人质飞镖":
                Flowchart.ExecuteBlock("营救人质（上）飞镖后");
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
            case "猎杀狙击手（调酒后）":
                Flowchart.ExecuteBlock("射飞镖事件");
                break;
            case "换防事件":
                Flowchart.ExecuteBlock("换防事件（调酒后）");
                break;
            case "换防事件飞镖":
                Flowchart.ExecuteBlock("换防事件飞镖后");
                break;
            case "护送物资":
                Flowchart.ExecuteBlock("护送物资（调酒后）");
                break;
            case "摧毁防空阵地":
                Flowchart.ExecuteBlock("摧毁防空阵地（调酒后）");
                break;
            case "猎杀军官下":
                Flowchart.ExecuteBlock("猎杀军官（下）调酒后");
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
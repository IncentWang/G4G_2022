using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework;
public class Test : MonoBehaviour
{
    public ShootGamePlayerController SPC;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickShooterButton()
    {
        Debug.Log("Ω¯»Î∑…Ô⁄”Œœ∑");
        UIManager.Instance.PushPanel(UIPanelType.Shooter);
    }
    public void OnClickBartenderGameButton()
    {
        GameManager.Instance.HideNeedBubble();
        UIManager.Instance.PushPanel(UIPanelType.BartenderGame);

    }

    public void ContinueStory()
    {
        GameManager.Instance.ContinueStory(false, SPC.CompareScore());
    }

    public void Exit()
    {
        Application.Quit();
    }
}

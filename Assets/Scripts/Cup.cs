using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UIFramework;

public class Cup : MonoBehaviour
{
    public ChangeGlassColor changeGlassColor;
    public CreateCustomerNeed customerNeed;
    public float sweet;
    public float intensity;
    public float mellow;

    int emptyNum;
    public int emptyMaxNum;

    public Text textSweet;
    public Text textIntensity;
    public Text textMellow;
    // Start is called before the first frame update

    public void OnClickFinishButton()
    {
        // changeGlassColor.ClearCup();
        ChangeDes();
        //比较杯与客户需求
        Debug.Log("顾客是否满足"+ CompareNeed());
        UIManager.Instance.PopPanel();
        GameManager.Instance.ContinueStory(CompareNeed(), false);
        textSweet.text=textIntensity.text=textMellow.text ="";
}
    public void OnClickEmptyButton()
    {
        if ((emptyNum <= emptyMaxNum))
        {
            emptyNum++;
            //清空酒杯
            sweet = intensity = mellow = 0;
            ChangeDes();
        }

    }

    public void ChangeDes()
    {
        textSweet.text = NeedToString(sweet);
        textIntensity.text = NeedToString(intensity);
        textMellow.text = NeedToString(mellow);
    }

    private string NeedToString(float need)
    {
        if (need <= 0)
        {
            return "没有";
        }

        if (need <= 5)
        {
            return "轻微";
        }

        if (need <= 10)
        {
            return "适中";
        }

        return "很浓";
    }
    bool CompareNeed()
    {
        return customerNeed.sweet.text == textSweet.text && customerNeed.intensity.text == textIntensity.text &&
               customerNeed.mellow.text == textMellow.text;

    }
}

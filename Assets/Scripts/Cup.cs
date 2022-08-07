using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UIFramework;

public class Cup : MonoBehaviour
{
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
        textSweet.text = NeedToString(sweet);
        textIntensity.text = NeedToString(intensity);
        textMellow.text = NeedToString(mellow);
        //比较杯与客户需求
        CompareNeed();
        Debug.Log("顾客是否满足"+ CompareNeed());
        UIManager.Instance.PopPanel();
    }
    public void OnClickEmptyButton()
    {
        if ((emptyNum <= emptyMaxNum))
        {
            emptyNum++;
            //清空酒杯
            sweet = intensity = mellow = 0;
            textSweet.text=textIntensity.text= textMellow.text="无";  
        }

    }
    private string NeedToString(float need)
    {
        if (need <= 5)
        {
            return "轻微";
        }
        else if (need > 5 && need <= 10)
        {
            return "适中";
        }
        else
        {
            return "很浓";
        }
    }
    bool CompareNeed()
    {
        if(customerNeed.sweet.text != textSweet.text)
            return false;
        if (customerNeed.sweet.text != textIntensity.text)
            return false;
        if (customerNeed.sweet.text != textMellow.text)
            return false;
        return true;
    }
}

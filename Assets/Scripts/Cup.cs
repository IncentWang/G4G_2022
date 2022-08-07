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
        //�Ƚϱ���ͻ�����
        CompareNeed();
        Debug.Log("�˿��Ƿ�����"+ CompareNeed());
        UIManager.Instance.PopPanel();
    }
    public void OnClickEmptyButton()
    {
        if ((emptyNum <= emptyMaxNum))
        {
            emptyNum++;
            //��վƱ�
            sweet = intensity = mellow = 0;
            textSweet.text=textIntensity.text= textMellow.text="��";  
        }

    }
    private string NeedToString(float need)
    {
        if (need <= 5)
        {
            return "��΢";
        }
        else if (need > 5 && need <= 10)
        {
            return "����";
        }
        else
        {
            return "��Ũ";
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

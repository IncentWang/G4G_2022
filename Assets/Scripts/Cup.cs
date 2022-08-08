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
        //�Ƚϱ���ͻ�����
        Debug.Log("�˿��Ƿ�����"+ CompareNeed());
        UIManager.Instance.PopPanel();
        GameManager.Instance.ContinueStory(CompareNeed(), false);
        textSweet.text=textIntensity.text=textMellow.text ="";
}
    public void OnClickEmptyButton()
    {
        if ((emptyNum <= emptyMaxNum))
        {
            emptyNum++;
            //��վƱ�
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
            return "û��";
        }

        if (need <= 5)
        {
            return "��΢";
        }

        if (need <= 10)
        {
            return "����";
        }

        return "��Ũ";
    }
    bool CompareNeed()
    {
        return customerNeed.sweet.text == textSweet.text && customerNeed.intensity.text == textIntensity.text &&
               customerNeed.mellow.text == textMellow.text;

    }
}

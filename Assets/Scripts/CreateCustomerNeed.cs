using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;
using UnityEngine.UI;

public class CreateCustomerNeed : MonoBehaviour
{
    public  ExcelDataManager dataManager;

    public Text sweet;
    public Text intensity;
    public Text mellow;
    // Start is called before the first frame update
    private void OnEnable()
    {
        System.Random nrr = new System.Random();
        var rdm = nrr.Next(1,100);
        Debug.Log(rdm);
        var weightSum = 0;
        for (int i = 0; i < dataManager.Need.Length - 1; i++)
        {
            weightSum += dataManager.Need[i].weight;
            if (weightSum > rdm)
            {
                //����Ȩ��������˿�����
                if (i == 0)
                {
                    Debug.Log(dataManager.Need[i].id);
                    sweet.text = NeedToString(dataManager.Need[i].needSweet);
                    intensity.text = NeedToString(dataManager.Need[i].needIntensity);
                    mellow.text = NeedToString(dataManager.Need[i].needMellow);
                    return;
                }
                Debug.Log(dataManager.Need[i - 1].id);
                sweet.text = NeedToString(dataManager.Need[i - 1].needSweet);
                intensity.text = NeedToString(dataManager.Need[i - 1].needIntensity);
                mellow.text = NeedToString(dataManager.Need[i - 1].needMellow);
                return;
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private string NeedToString(int need)
    {
        if (need <= 5)
        {
            return "��΢";
        }else if (need > 5 && need <= 10)
        {
            return "����";
        }
        else
        {
            return "��Ũ";
        }
    }
}

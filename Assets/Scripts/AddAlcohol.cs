using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DefaultNamespace;

public class AddAlcohol : MonoBehaviour
{
    public ExcelDataManager excelDataManager;
    public Cup cup;
    public ChangeGlassColor ChangeGlassColor;
    public AlcoholPourer Pourer;

    public int sweet;
    public int intensity;
    public int mellow;
    public int ID;

    bool buttonDown;
    bool addAlcohol;
    public float switchSpeedTime;
    float speed=1;

    private NoRepeatRandom nrr;
    private Vector2 originalPosition;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent.Find("Slider").TryGetComponent<Slider>(out slider);
        transform.parent.Find("CupDetails").TryGetComponent<Cup>(out cup);
        sweet = GetAlcohol().sweet;
        intensity = GetAlcohol().intensity;
        mellow = GetAlcohol().mellow;
        nrr = new NoRepeatRandom(1000);
        originalPosition = ((RectTransform) transform).anchoredPosition;
    }
    
    public void OnClickAddAlcoholButton(bool down)
    {
        buttonDown = down;
        if (down)
        {
            slider.value = 0;
            //Debug.Log("加酒");
            Debug.Log(ID);
        }else
        {
            cup.sweet += slider.value * sweet;
            cup.intensity += slider.value * intensity;
            cup.mellow += slider.value * mellow;
            
            ChangeGlassColor.Add(ID, (int)Mathf.Ceil(slider.value * 3f));
        }
    }

    public void Reset()
    {
        EndPourAlcohol();
    }

    public void AddToGlass(float sliderValue)
    {
        cup.sweet += sliderValue * sweet;
        cup.intensity += sliderValue  * intensity;
        cup.mellow += sliderValue  * mellow;
        
        // 更改描述
        cup.ChangeDes();
            
        ChangeGlassColor.Add(ID, (int)Mathf.Ceil(slider.value * 3f));
        EndPourAlcohol();
    }

    public void StartPourAlcohol()
    {
        ((RectTransform) transform).anchoredPosition = new Vector2(-72f, 8.1f);
        transform.rotation = Quaternion.Euler(0f, 0f, -95f);
        if (Pourer.CallbackAlcohol != null&& Pourer.CallbackAlcohol!=this)
        {
            Pourer.Reset();
        }

        Pourer.StartTry(this);
    }

    public void EndPourAlcohol()
    {
        ((RectTransform) transform).anchoredPosition = originalPosition;
        transform.rotation = Quaternion.identity;
    }

    public AlcoholItem GetAlcohol()
    {
        return excelDataManager.AlcoholItem[ID - 1];
    }

}

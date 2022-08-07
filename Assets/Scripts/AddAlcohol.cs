using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddAlcohol : MonoBehaviour
{
    bool buttonDown;
    bool addAlcohol;
    public float switchSpeedTime;
    float speed=1;

    private NoRepeatRandom nrr;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent.Find("Slider").TryGetComponent<Slider>(out slider);
    }

    // Update is called once per frame
    void Update()
    {
        switchSpeedTime+=Time.deltaTime;
        if (switchSpeedTime >= 1)
        {
            nrr = new NoRepeatRandom(1000);
            speed = nrr.Next() * 2.5f;
            switchSpeedTime = 0;
        }
        
        if (buttonDown && addAlcohol)
        {
            slider.value += Time.deltaTime* speed;
        }else if (buttonDown && !addAlcohol)
        {
            slider.value -= Time.deltaTime* speed;
        }
        if (slider.value == 1)
        {
            addAlcohol = false;
        }else if (slider.value == 0)
        {
            addAlcohol= true;
        }
    }
    
    public void OnClickAddAlcoholButton(bool down)
    {
        buttonDown = down;
        if (down)
        {
            slider.value = 0;
            Debug.Log("加酒");
        }else
        {
            Debug.Log("停止加酒,加了:"+slider.value);
            
        }
    }
}

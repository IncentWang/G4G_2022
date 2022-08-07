using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddAlcohol : MonoBehaviour
{
    bool addAlcohol;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent.Find("Slider").TryGetComponent<Slider>(out slider);
    }

    // Update is called once per frame
    void Update()
    {
        if (addAlcohol)
        {
            slider.value += Time.deltaTime;
        }
    }
    
    public void OnClickAddAlcoholButton(bool down)
    {
        addAlcohol = down;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddAlcohol : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent.Find("Slider").TryGetComponent<Slider>(out slider);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnClickAddAlcoholButton()
    {
        slider.value+=Time.deltaTime;

    }
}

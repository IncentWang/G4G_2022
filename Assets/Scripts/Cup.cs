using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cup : MonoBehaviour
{
    public float sweet;
    public float intensity;
    public float mellow;

    public Text textSweet;
    public Text textIntensity;
    public Text textMellow;
    // Start is called before the first frame update
    void OnEnable()
    {
        transform.GetChild(0).GetChild(0).TryGetComponent<Text>(out textSweet);
        transform.GetChild(1).GetChild(0).TryGetComponent<Text>(out textIntensity);
        transform.GetChild(2).GetChild(0).TryGetComponent<Text>(out textMellow);

        textSweet.text = NeedToString(sweet);
        textIntensity.text = NeedToString(intensity);
        textMellow.text = NeedToString(mellow);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private string NeedToString(float need)
    {
        if (need <= 5)
        {
            return "ÇáÎ¢";
        }
        else if (need > 5 && need <= 10)
        {
            return "ÊÊÖÐ";
        }
        else
        {
            return "ºÜÅ¨";
        }
    }
}

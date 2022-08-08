using UnityEngine;
using UnityEngine.UI;

public class AlcoholPourer : MonoBehaviour
{
    public AddAlcohol CallbackAlcohol;
    public Slider ProcessSlider;
    public float SliderSpeed;
    public Text Hint;
    public AudioClip clip;
    public Transform cam;
    private NoRepeatRandom nrr;

    float switchSpeedTime;

    private bool movingBar;
    private bool movingUp;

    private void Start()
    {
        nrr = new NoRepeatRandom(1000);
    }
    public void Pour()
    {
        movingBar = false;
        CallbackAlcohol.AddToGlass(ProcessSlider.value);
        AudioSource.PlayClipAtPoint(clip, cam.position);
    }

    public void Reset()
    {
        movingBar = false;
        CallbackAlcohol.Reset();
        CallbackAlcohol = null;
    }

    public void StartTry(AddAlcohol callback)
    {
        CallbackAlcohol = callback;
        movingBar = true;
    }

    public void Update()
    {
        switchSpeedTime += Time.deltaTime;
        if (switchSpeedTime >= 1)
        {
            SliderSpeed = nrr.Next() * 2.5f;
            switchSpeedTime = 0;
        }
        // 控制进度条上上下下
        if (movingBar)
        {
            if (ProcessSlider.value == 0f && !movingUp)
            {
                movingUp = true;
            }

            if (ProcessSlider.value == 1f && movingUp)
            {
                movingUp = false;
            }

            if (movingUp)
            {
                ProcessSlider.value += Time.deltaTime * SliderSpeed;
            }
            else
            {
                ProcessSlider.value -= Time.deltaTime * SliderSpeed;
            }

            CallbackAlcohol.transform.rotation = Quaternion.Euler(0f, 0f, -95f - ProcessSlider.value * 100f * 0.5f);
        }

        if (CallbackAlcohol != null)
        {
            switch (CallbackAlcohol.ID)
            {
                case 1:
                    Hint.text = "威士忌：不甜、不烈、特别香醇";
                    break;
                case 2:
                    Hint.text = "朗姆酒：很甜，但是烈度香醇度没有很高";
                    break;
                case 3:
                    Hint.text = "伏特加：非常烈，而且会影响到甜度的表现";
                    break;
                case 4:
                    Hint.text = "利口酒：甜度适中，还会中和掉烈的味道";
                    break;
                case 5:
                    Hint.text = "白兰地：甜度烈度比较低，但是比较香醇";
                    break;
                case 6:
                    Hint.text = "力娇酒：甜度烈度适中，但是会影响到香醇的发挥";
                    break;
            }
        }
        else
        {
            Hint.text = "选择一款酒来查看笔记";
        }
    }
}
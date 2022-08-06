using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorRotate : MonoBehaviour
{
    bool isRotate;
    public bool isRight;
    public float time;

    private void Update()
    {
        if (isRotate&&!isRight)
        {
            transform.Rotate(-transform.up, 0.1f);
        }else if (isRotate && isRight)
        {
            transform.Rotate(transform.up, 0.1f);

        }
        time+=Time.deltaTime;
        if (time > 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
    public void OnClickStartButton()
    {
        isRotate = true;
    }

}

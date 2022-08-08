using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UIFramework;

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
        
        if (isRotate )
        {
            time += Time.deltaTime;
            
        }
        if (time > 1.8)
        {
            UIManager.Instance.PopPanel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
    public void OnClickStartButton()
    {
        isRotate = true;
    }

}

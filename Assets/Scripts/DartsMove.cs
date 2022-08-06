using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DartsMove : MonoBehaviour
{
    Vector2 velocityDir;
    Vector2 lastDir;
    Rigidbody2D rb;
    Transform centrePos;

    public int collNum;

    public float switchTargetTime;
    public float time;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Rigidbody2D>(out rb);
        Hashtable hashtable = new Hashtable();
        velocityDir = hashtable.Next();
        Debug.Log(velocityDir);
        velocityDir.Normalize();
        rb.velocity = velocityDir * speed;
    }

    // Update is called once per frame
    void Update()
    {

        //rectTransform.anchoredPosition = new Vector2( Mathf.Lerp(rectTransform.anchoredPosition.x, targetPos.x ,Time.deltaTime* speed), Mathf.Lerp(rectTransform.anchoredPosition.y, targetPos.y, Time.deltaTime* speed));
    }
    private void LateUpdate()
    {
        lastDir = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            collNum++;
            Vector2 reflexAngle = Vector2.Reflect(lastDir, collision.contacts[0].normal);
            rb.velocity = reflexAngle.normalized * lastDir.magnitude;
            if (new System.Random().Next(collNum, 10) > 8)
            {
                //Debug.Log("set Velocity");
                rb.velocity = centrePos.position * speed;
            }
        }
    }
}

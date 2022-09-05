using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DartsMove : MonoBehaviour
{
    Vector2 velocityDir;
    Vector2 lastDir;
    Rigidbody2D rb;
    private NoRepeatRandom nrr;

    int collNum;

    [Tooltip("运行时显示当前速度，更改来修改初始速度")]
    public float speed;
    [Tooltip("在X次碰撞之后一定向中心弹射")]
    public int AfterXCollisionToGoCenter;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Collider2D>().isTrigger = false;
        nrr = new NoRepeatRandom(1000);
        TryGetComponent<Rigidbody2D>(out rb);
        velocityDir.x = nrr.Next() * 300f - 150f;
        velocityDir.y = nrr.Next() * 300f - 150f;
        velocityDir.Normalize();
        rb.velocity = velocityDir * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void LateUpdate()
    {
        lastDir = velocityDir;
        rb.velocity = velocityDir * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            collNum++;
            Vector2 reflexAngle = Vector2.Reflect(lastDir, collision.contacts[0].normal);
            velocityDir = reflexAngle.normalized * lastDir.magnitude;
            if (new System.Random().Next(collNum, 10) > AfterXCollisionToGoCenter)
            {
                Vector2 tempVelocity = Vector2.zero - ((RectTransform) transform).anchoredPosition;
                velocityDir = tempVelocity.normalized;
                collNum = 0;
            }
        }
    }
}

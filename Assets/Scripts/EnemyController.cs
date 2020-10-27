using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 2.0f;
    public float ChangeTime = 4.0f;             //敌人改变方向的时间   这个时间得根据具体场景大小来调

    float ChangeTimer;                                      //计时器

    Rigidbody2D rigidbody;
    Vector2 moveDirection;
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        moveDirection = Vector2.right;
        ChangeTimer = ChangeTime;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeTimer -= Time.deltaTime;
        if (ChangeTimer < 0)
        {
            moveDirection *= -1;
            ChangeTimer = ChangeTime;
            if (renderer.flipX)
            {
                renderer.flipX = false;
            }
            else
            {
                renderer.flipX = true;
            }
         
        }
        Vector2 position = rigidbody.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        rigidbody.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            //调用重生函数
        }
    }
}

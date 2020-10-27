using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public GameObject model;
    [Header("=====   key settings   =====")]
    public string keyUp = "w";                      // 控制移动
    public string keyRight = "d";                   // 控制移动
    public string keyLeft = "a";                    // 控制移动
    public string keyClick = "e";                   // 与道具互动
    public string keyRun = "Space";                 // run

    public float walkSpeed = 2.0f;                  // 控制移动快慢
    public float runMultiplier = 2.0f;
    public bool run = false;
    public float jumpVelocity;

    public GamePanelLevel1 levelPanel1;
    public Canvas controlTips;
    public Canvas jumpTips;

    public GameObject IceDestroy;
    public GameObject PapersDestroy;
    public GameObject trophyDestroy;
    public GameObject PenDestroy;
    public GameObject football;



    public float horizontalSignal;               // 移动方向
    private bool jump;
    private bool lastJump;
    private float horizontalSpeed;                  // 移动速度
    private Vector2 jumpVec;
    private bool inputEnable = true;                       // 是否允许输入


    private Rigidbody2D rigid;
    private Animator anim;
    private ContainersManager containers;
    private AudioSource audio;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = model.GetComponent<Animator>();
        containers = ContainersManager.GetContainersVars();
        audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetKey(keyRun))
            run = true;
        else
            run = false;
        // calculate speed
        horizontalSignal = (Input.GetKey(keyRight) ? 1.0f : 0) - (Input.GetKey(keyLeft) ? 1.0f : 0);
        horizontalSpeed = horizontalSignal * walkSpeed * (run ? runMultiplier : 1);
        // orientation
        if (Mathf.Abs(horizontalSignal) > 0.1)
        {
            transform.right = new Vector3(1, 0, 0) * horizontalSignal;
        }
        // move animation
        anim.SetFloat("Speed", Mathf.Lerp(anim.GetFloat("Speed"), Mathf.Abs(horizontalSignal * (run ? 2 : 1)), 0.4f));



        // jump
        jump = Input.GetKey(keyUp) || Input.GetKeyDown(keyUp);
        // 防止再次跳跃
        if (Mathf.Abs(rigid.velocity.y) > 0.005f)
            jump = false;
        if (jump)
        {
            anim.SetTrigger("Jump");
            jumpVec = new Vector2(0, jumpVelocity);
        }

        //if(rigid.velocity.y > 0.2) {
        //    transform.GetComponent<CapsuleCollider2D>().enabled = false;
        //}
        //else {
        //    transform.GetComponent<CapsuleCollider2D>().enabled = true;
        //}

        // 按E键交互成功时（inputEnable变为false），播放交互动画时，jump和horizontalSpeed都是为0的，可能不能重复按E
        // 动画播放完 inputEnable变回true
        if (!inputEnable)
        {

        }


        // 边界处理
        if (transform.position.x < -Camera.main.orthographicSize * 16.0f / 10.0f + 2.0f)
        {
            Vector3 temp = new Vector3(-Camera.main.orthographicSize * 16.0f / 10.0f + 2.0f, transform.position.y, transform.position.z);
            transform.position = temp;
        }
        if (transform.position.x > 100)
        {
            Vector3 temp = new Vector3(100, transform.position.y, transform.position.z);
            transform.position = temp;
        }
    }



    private void FixedUpdate()
    {
        // move
        rigid.velocity = new Vector2(horizontalSpeed, rigid.velocity.y) + jumpVec;
        jumpVec = Vector2.zero;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "piano")
        {
            audio.Play();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // 是不是速度必须为0
        if (Input.GetKey(keyClick))
        {
            if (collision.tag == "Ice")
            {
                // 查看道具类别 可以写个enum类型
                StartCoroutine(levelPanel1.AddSlider());
                Destroy(collision.gameObject);
                Instantiate(IceDestroy, collision.gameObject.transform.position, Quaternion.identity);

            }
            else if (collision.tag == "Paper")
            {
                StartCoroutine(levelPanel1.AddSlider());

                Destroy(collision.gameObject);
                Instantiate(PapersDestroy, collision.gameObject.transform.position, Quaternion.identity);
            }
            else if (collision.tag == "football")
            {
                StartCoroutine(levelPanel1.AddSlider());

                Destroy(collision.gameObject);
                Instantiate(football, collision.gameObject.transform.position, Quaternion.identity);
            }
            else if (collision.tag == "pen")
            {
                StartCoroutine(levelPanel1.AddSlider());

                Destroy(collision.gameObject);
                Instantiate(PenDestroy, collision.gameObject.transform.position, Quaternion.identity);
            }
            else if (collision.tag == "Bad")
            {
                StartCoroutine(levelPanel1.AddSlider());

                Destroy(collision.gameObject);
                Instantiate(trophyDestroy, collision.gameObject.transform.position, Quaternion.identity);
            }



        }

        if (collision.name == "wall1")
        {
            foreach (var anim in controlTips.GetComponentsInChildren<Animator>())
            {
                anim.SetTrigger("Destroy");
            }
        }
        else if (collision.name == "jumpwall")
        {
            jumpTips.gameObject.SetActive(true);
        }

        if (collision.gameObject.name == "piano")
        {
            if (horizontalSignal > 0.1f)
            {
                audio.pitch = 2;
            }
            else if (horizontalSignal < -0.1)
            {
                audio.pitch = -2;
            }
            else
            {
                audio.pitch = 2;
            }
        }
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "jumpwall")
        {
            foreach (var anim in jumpTips.GetComponentsInChildren<Animator>())
            {
                anim.SetTrigger("Destroy");
            }
        }

    }
}

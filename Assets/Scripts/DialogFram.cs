using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogFram : MonoBehaviour
{
    public Text dialog;                                         //为了更改内容

    public float Showtime = 4;    //对话框显示时间

    public float ShowTimer;    //对话框计时器
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        ShowTimer = -1;
    }



    // Update is called once per frame
    void Update()
    {
        ShowTimer -= Time.deltaTime;
        if (ShowTimer < 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void ShowDialog()
    {
        ShowTimer = Showtime;
        this.gameObject.SetActive(true);
    }

    public void ChangeText(string s)
    {
        dialog.text = s;
    }
}

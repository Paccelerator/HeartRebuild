using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restore : MonoBehaviour
{
    public GameObject Original;
    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null && Input.GetKey(KeyCode.E))
        {
            //播放物体恢复的特性和动画
            Instantiate(Original);   //重新创建没被毁坏之前的物体
        }
    }
}

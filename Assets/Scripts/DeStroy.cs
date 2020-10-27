using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeStroy : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null && Input.GetKey(KeyCode.E))
        {
            //播放物体销毁的特性和动画
            Destroy(this.gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float camraDampValue = 0.5f;

    private Transform player;
    private new Transform camera;
    private Vector3 cameraDampVelocity;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        camera = Camera.main.transform;
    }


    private void FixedUpdate()
    {
        Vector3 temp = new Vector3(player.position.x, 0, -10);
        camera.position = Vector3.SmoothDamp(camera.position, temp, ref cameraDampVelocity, camraDampValue);
        //camera.position = temp;
        if (camera.position.x < 0)
            camera.position = new Vector3(0, 0, -10);
        if (camera.position.x > 90)
            camera.position = new Vector3(90, 0, -10);
    }


    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public GameObject shadow;
    // Start is called before the first frame update
    void Start()
    {
        var shadowMat = shadow.GetComponent<SpriteRenderer>().material;
        var playerTex = this.GetComponent<SpriteRenderer>().sprite.texture;
        shadowMat.SetTexture("_PlayerTex",playerTex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

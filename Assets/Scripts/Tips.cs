using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    public Canvas tips;

    private bool first = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") {
            if (first) {
                Vector3 position = transform.position;
                tips.gameObject.SetActive(true);
                first = false;
                tips.transform.position = transform.position + new Vector3(0, 2, 0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            tips.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Destroy");
            tips.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Destroy");
            StartCoroutine(GradientDestroy());
        }
    }

    IEnumerator GradientDestroy()
    {
        yield return new WaitForSeconds(1);
        tips.gameObject.SetActive(false);
    }


}

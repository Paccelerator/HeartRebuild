using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelLevel1 : MonoBehaviour
{
    public Slider slider_process;
    public float shakeAmout = 0.2f;

    private int count = 1;
    private ContainersManager containers;


    private void Awake()
    {
        slider_process = transform.Find("Parent").transform.Find("slider_process").GetComponent<Slider>();
    }


    // Start is called before the first frame update
    void Start()
    {
        slider_process.value = 0.0f;
        count = 1;
        containers = ContainersManager.GetContainersVars();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator AddSlider()
    {
        while(slider_process.value < 0.333f * count) {
            slider_process.value += 0.01f;
            yield return new WaitForEndOfFrame();
        }
        count++;
        if (slider_process.value > 0.998f){
            StartCoroutine(TwinkleBar());
            StartCoroutine(Shake());
        }
    }

    IEnumerator TwinkleBar()
    {
        slider_process.fillRect.GetComponent<Image>().sprite = containers.processBar[1];
        yield return new WaitForSeconds(0.3f);
        slider_process.fillRect.GetComponent<Image>().sprite = containers.processBar[0];
        yield return new WaitForSeconds(0.3f);
        slider_process.fillRect.GetComponent<Image>().sprite = containers.processBar[1];
        yield return new WaitForSeconds(0.3f);
        slider_process.fillRect.GetComponent<Image>().sprite = containers.processBar[0];
        yield return new WaitForSeconds(0.3f);
        slider_process.fillRect.GetComponent<Image>().sprite = containers.processBar[1];
        yield return new WaitForSeconds(0.3f);
        slider_process.fillRect.GetComponent<Image>().sprite = containers.processBar[0];
        yield return new WaitForSeconds(0.3f);
        slider_process.fillRect.GetComponent<Image>().sprite = containers.processBar[1];
        yield return new WaitForSeconds(0.3f);
        slider_process.fillRect.GetComponent<Image>().sprite = containers.processBar[0];
        yield return new WaitForSeconds(0.3f);
        slider_process.fillRect.GetComponent<Image>().sprite = containers.processBar[1];
    }

    IEnumerator Shake()
    {
        float timer = 2.4f;
        Vector3 originalPos = slider_process.transform.position;
        while(timer > 0) {
            slider_process.transform.position = originalPos + Random.insideUnitSphere * shakeAmout;
            timer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        slider_process.transform.position = originalPos;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    private GameObject countDown1;
    [SerializeField]
    private GameObject countDown2;
    [SerializeField]
    private GameObject countDown3;
    [SerializeField]
    private GameObject StartText;


    private void Start()
    {
        countDown1.SetActive(false);
        countDown2.SetActive(false);
        countDown3.SetActive(false);
        StartText.SetActive(false);

        StartCoroutine(Count());
    }

    private void Update()
    {
        
    }

    IEnumerator Count()
    {
        Time.timeScale = 0.0f;

        countDown1.SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        countDown1.SetActive(false);

        countDown2.SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        countDown2.SetActive(false);

        countDown3.SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        countDown3.SetActive(false);

        StartText.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        StartText.SetActive(false);

        Time.timeScale = 1.0f;
    }
}

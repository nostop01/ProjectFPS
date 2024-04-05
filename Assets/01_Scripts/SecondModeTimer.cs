using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondModeTimer : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField]
    private float timerCount;
    [SerializeField]
    private TMP_Text timerCountText;
    [SerializeField]
    private float maxTimerCount;
    [SerializeField]
    private float currentTimerCount;

    [SerializeField]
    private GameObject clearText;

    public bool TimeOver = false;

    private void Update()
    {
        timerCount += Time.deltaTime;

        timerCountText.text = timerCount.ToString("F2");

        if (timerCount >= 60)
        {
            TimeOver = true;
        }
        
        if(TimeOver == true)
        {
            StartCoroutine(DelayTime());
        }
    }

    IEnumerator DelayTime()
    {
        Time.timeScale = 0f;

        clearText.SetActive(true);

        yield return new WaitForSecondsRealtime(3.0f);

        SceneManager.LoadScene("MainMenu");

        Time.timeScale = 1f;

    }
}

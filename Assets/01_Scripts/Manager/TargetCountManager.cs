using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TargetCountManager : MonoBehaviour
{
    [Header("TargetCount")]
    [SerializeField]
    private TMP_Text targetCurrentCountText;
    [SerializeField]
    private int targetCurrentCount;

    [Header("MaxTargetCount")]
    [SerializeField]
    private TMP_Text maxTargetCountText;
    private int maxTargetCount;

    [SerializeField]
    private TargetCount targetCount;

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


    // Start is called before the first frame update
    void Start()
    {
        maxTargetCount = targetCount.maxTargetCount;

        timerCount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timerCount += Time.deltaTime;

        targetCurrentCount = targetCount.targetCount;

        if(targetCurrentCount >= maxTargetCount)
        {
            targetCurrentCount = maxTargetCount;
        }

        targetCurrentCountText.text = targetCurrentCount.ToString();

        maxTargetCountText.text = maxTargetCount.ToString();

        timerCountText.text = timerCount.ToString("F2");

        if(maxTargetCount == targetCurrentCount)
        {
            StartCoroutine(DelayTime());
        }

        if(maxTimerCount < timerCount)
        {
            maxTimerCount = timerCount;
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

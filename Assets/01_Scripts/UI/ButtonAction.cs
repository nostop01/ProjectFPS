using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    [SerializeField]
    private GameObject GameModePanel;

    [SerializeField]
    private bool GamePlayScene = false;

    [SerializeField]
    private bool GamePause = true;

    private void Update()
    {
        if(GamePlayScene == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameModePanel.SetActive(false);
            }
        }

        else if(GamePlayScene)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GameModePanel.SetActive(GamePause);
                GamePause = !GamePause;

                if(GamePause == false)
                {
                    Time.timeScale = 0.0f;
                }
                else
                {
                    Time.timeScale = 1.0f;
                }
            }
        }
    }

    public void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenChooseModePanel()
    {
        GameModePanel.SetActive(true);
    }
}

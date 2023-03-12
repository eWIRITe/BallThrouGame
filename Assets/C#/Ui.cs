using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    public TMP_Text LastFallText;
    public TMP_Text ScoreOnLoseScreen;
    public TMP_Text ScoreOnMainScreen;
    private float Timer = 8;
    public static int Score;

    //Panels
    public GameObject StartPanel;
    public GameObject MainPanel;
    public GameObject LooseScreen;
    public GameObject StopPanel;

    public static float lastFall = 16;

    private void Start()
    {
        lastFall = 16;
    }

    void FixedUpdate()
    {
        lastFall -= Time.deltaTime;
    }

    private void Update()
    {
        if (lastFall <= 0) Lose();
        if (LooseScreen.activeSelf) ScoreOnLoseScreen.text = Score.ToString();
        if (MainPanel.activeSelf) ScoreOnMainScreen.text = Score.ToString();
        if (MainPanel.activeSelf) LastFallText.text = Math.Round(lastFall, 1).ToString();
    }

    public void Lose()
    {

        GunScript.Loose = true;

        StartPanel.SetActive(false);
        MainPanel.SetActive(false);
        LooseScreen.SetActive(true);
        StopPanel.SetActive(false);
    }

    public void OnTryAgainButton()
    {

        Time.timeScale = 1.0f;
        StartPanel.SetActive(false);
        MainPanel.SetActive(true);
        LooseScreen.SetActive(false);
        StopPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void OnToMenuButton()
    {

        Time.timeScale = 1.0f;
        StartPanel.SetActive(false);
        MainPanel.SetActive(true);
        LooseScreen.SetActive(false);
        StopPanel.SetActive(false);
        SceneManager.LoadScene(0);
        
    }

    public void OnStopButton()
    {
        Time.timeScale = 0;

        StartPanel.SetActive(false);
        MainPanel.SetActive(false);
        LooseScreen.SetActive(false);
        StopPanel.SetActive(true);
    }

    public void OnPlayButton()
    {
        Time.timeScale = 1.0f;

        StartPanel.SetActive(false);
        MainPanel.SetActive(true);
        LooseScreen.SetActive(false);
        StopPanel.SetActive(false);
    }
}

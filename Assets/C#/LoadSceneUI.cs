using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.RemoteConfig;

public class LoadSceneUI : MonoBehaviour
{
    public struct userAttributes { }
    public struct appAttributes { }

    public int PlaySceneNumber;
    public int InetSceneNumber;

    void Awake()
    {
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    public void OnStartButton()
    {
        if (ConfigManager.appConfig.GetString("httpAdres") == "")
        {
            SceneManager.LoadScene(PlaySceneNumber);
        }
        else
        {
            infra.OpenURL(ConfigManager.appConfig.GetString("httpAdres"));
        }
    }
}
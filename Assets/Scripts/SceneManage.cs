using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void NextScene(string nextSceneName)
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void Re()
    {
        NextScene("Intro");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

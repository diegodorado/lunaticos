﻿using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour {

    public void Load(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void Reload()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("empty");
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    
        

}

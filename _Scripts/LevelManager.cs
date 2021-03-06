﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    void Start(){
        if(autoLoadNextLevelAfter>0)
            Invoke("LoadNextLevel",autoLoadNextLevelAfter);
        else if(autoLoadNextLevelAfter == 0)
            Debug.Log("AutoLoad disabled");
        else Debug.Log("Wrong time value");
    }
    public void LoadLevel(string name){
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name,LoadSceneMode.Single);
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1,LoadSceneMode.Single);
    }
    public void QuitRequest(){
        Debug.Log("Quit");
        Application.Quit();
    }
}

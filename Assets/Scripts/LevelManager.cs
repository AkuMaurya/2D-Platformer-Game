using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get{ return instance; }}
    // public GameObject LevelSelection;
    // public string Level1;
    public  string[] Levels;

    private void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public void Start(){
        Debug.Log(Levels[0]);
        // if(GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        // {
            // SetLevelStatus(Levels[0], LevelStatus.Unlocked);
    //         Debug.Log("0" + Levels[0]);
    //         Debug.Log("1" + LevelStatus.Completed);
    //         Debug.Log("2" + LevelStatus.Locked);
    //         Debug.Log("3" + LevelStatus.Unlocked);
    //     }
    }

    public void MarkCurrentLevelComplete(){
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name,  LevelStatus.Completed);
    //     int nextSceneIndex = currentScene.buildIndex + 1;
    //     Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
    //     Debug.Log("next scene is valid:      " + nextScene.IsValid());
    //     SetLevelStatus(nextScene.name, LevelStatus.Unlocked);

        int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        Debug.Log(currentScene.name);

        if(nextSceneIndex < Levels.Length){
            SetLevelStatus(Levels[nextSceneIndex],LevelStatus.Unlocked);
        }
        // LevelSelection.SetActive(true);
    }

    public LevelStatus GetLevelStatus(string level){
        LevelStatus levelStatus =  (LevelStatus) PlayerPrefs.GetInt(level, 0);
        Debug.Log("LvlMngr" + levelStatus);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus){
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting Level: " + level + " Status: " + levelStatus);
    }
}


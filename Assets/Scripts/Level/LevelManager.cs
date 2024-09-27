using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if(GetLevelStatus(Level.Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Level.Levels[0], LevelStatus.Unlocked);
        }
    }
    public LevelStatus GetLevelStatus(string level) {
        if (!PlayerPrefs.HasKey(level)) return LevelStatus.Locked;
       return (LevelStatus) PlayerPrefs.GetInt(level);
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }

    public void MarkCurrentLevelComplete() {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, LevelStatus.Completed);

        int currentIndex = Array.FindIndex(Level.Levels, level => level == currentScene.name);
        int nextSceneIndex = currentScene.buildIndex + 1 - Level.LevelOffset;
        if (nextSceneIndex > Level.Levels.Length) { nextSceneIndex = 0; }

        if (nextSceneIndex < Level.Levels.Length) {
            SoundManager.Instance.Play(SoundType.LevelComplete);
            SetLevelStatus(Level.Levels[nextSceneIndex], LevelStatus.Unlocked);
            SceneManager.LoadScene(nextSceneIndex + Level.LevelOffset);
        }
       
    }

}

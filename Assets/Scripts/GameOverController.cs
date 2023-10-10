using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button buttonRestart;
    [SerializeField] private Button buttonBack;
    public int sceneIndex=0;
    private void Start()
    {
        //buttonRestart = gameObject.GetComponent<Button>();
        buttonRestart.onClick.AddListener(RestartGame);
        buttonBack.onClick.AddListener(LoadLobby);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadLobby()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayerDied() {
        gameObject.SetActive(true);
    }
}

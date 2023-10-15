using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonQuit;
    private void Start()
    {
        buttonPlay.onClick.AddListener(PlayGame);
        buttonQuit.onClick.AddListener(QuitGame);
    }
    
    private void PlayGame()
    {
        SoundManager.Instance.Play(SoundType.ButtonClick);
        SceneManager.LoadScene(1);

    }
   
    private void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

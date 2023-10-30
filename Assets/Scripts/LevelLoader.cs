using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]private Button button;
    public string LevelName;
    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        if (button)
            button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        SceneManager.LoadScene(LevelName);
    }
}

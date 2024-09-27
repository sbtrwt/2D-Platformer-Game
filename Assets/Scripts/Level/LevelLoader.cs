using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Button button;
    public string LevelName;
    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        if (button)
            button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SoundManager.Instance.Play(SoundType.ButtonClick);
        LoadSceneByLevel();
        //SceneManager.LoadScene(LevelName);
    }

    private void LoadSceneByLevel()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Can't play this level is locked.");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
}

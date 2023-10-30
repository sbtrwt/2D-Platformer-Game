using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int score = 0;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }


    public void ScoreIncrement(int val) {
        score += val;
        RefreshUI();
    }

    private void RefreshUI() {
        if(scoreText)
        scoreText.text = "Score : " + score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeController : MonoBehaviour
{
    const int MAX_LIFE = 3;
    [SerializeField] private TextMeshProUGUI leftText;
    [SerializeField] private int life = 0;

    private void Awake()
    {
        leftText = GetComponent<TextMeshProUGUI>();
        life = MAX_LIFE;
    }

    void Start()
    {
        RefreshUI();
    }
    private void RefreshUI()
    {
        if (leftText)
            leftText.text = "Hearts : " + life;
    }
    public int LifeDecrement()
    {
        life--;
        RefreshUI();
        return life;
    }
}

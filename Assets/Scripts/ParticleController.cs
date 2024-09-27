using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ParticleController : MonoBehaviour
{
    public static ParticleController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void SetPosition(Vector2 postion) {
        transform.position = postion;
    }

    public void SetVisible(bool isVisible) {
        gameObject.SetActive(isVisible);
    }
}

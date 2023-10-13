using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Level finished by the player");
       
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level finished by the player");
            LevelManager.Instance.MarkCurrentLevelComplete();
        }
    }
}

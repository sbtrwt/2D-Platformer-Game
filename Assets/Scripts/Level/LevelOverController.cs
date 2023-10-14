using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Level finished by the player");
       
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected level finished");
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level finished by the player");
            LevelManager.Instance.MarkCurrentLevelComplete();
        }
    }
}

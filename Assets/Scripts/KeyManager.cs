using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Inside collision Key");
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player) {
            player.PickUpKey();
            Destroy(gameObject);
        }

    }
}

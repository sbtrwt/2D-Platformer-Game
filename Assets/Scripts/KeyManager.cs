using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Inside collision Key");
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player) {
            player.PickUpKey();
            animator.SetBool("IsHide", true);
            Destroy(gameObject);
        }

    }
}

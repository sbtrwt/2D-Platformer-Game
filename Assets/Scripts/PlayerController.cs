using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player controller awake");
    }

    // Update is called once per frame
    void Update()
    {
        
        //Control user by inputs
        float speed = Input.GetAxisRaw("Horizontal");
        if(speed > 0)
            Debug.Log(speed);
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if (speed < 0) {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }
}

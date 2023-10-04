using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxCollider;
    private bool isCrouch;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player controller awake");
        //collider = collider.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        //Control user by inputs
        float speed = Input.GetAxisRaw("Horizontal");
        if (speed > 0)
            Debug.Log(speed);
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            isCrouch = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            isCrouch = false;
        }
        //Box collider size change on up/down
        Crouch();
        Jump();
    }

    private void Crouch()
    {
       
        animator.SetBool("IsCrouch", isCrouch);
       
        Vector2 boxSize = boxCollider.size;
        Vector2 boxOffset = boxCollider.offset;
        if (isCrouch)
        {
            boxOffset.x = -0.1f;
            boxOffset.y = 0.6f;
            boxSize.x = 0.96f;
            boxSize.y = 1.4f;

        }
        else
        {
            boxOffset.x = 0.03f;
            boxOffset.y = 0.98f;
            boxSize.x = 0.69f;
            boxSize.y = 2.15f;
        }
        boxCollider.size = boxSize;
        boxCollider.offset = boxOffset;
    }

    private void Jump() {
        float upMove = Input.GetAxisRaw("Vertical");
        animator.SetBool("IsJump", upMove > 0);
      
    }
}

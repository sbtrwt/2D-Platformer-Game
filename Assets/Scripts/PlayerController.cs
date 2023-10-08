using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool isCrouch;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private bool IsKeyFound;

    internal void PickUpKey()
    {
        Debug.Log("Player get Key");
        IsKeyFound = true;
    }

    public float jumpAmount = 8;
    public int speed;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player controller awake");
        animator = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Control user by inputs
        float horizontal = Input.GetAxisRaw("Horizontal");
       

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            isCrouch = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            isCrouch = false;
        }
        //Box collider size change on up/down
        Move(horizontal);
        Crouch();
        Jump();
    }

    private void Move(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
        Vector3 position = transform.position;
        position.x += speed * horizontal * Time.deltaTime;
        transform.position = position;
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
            boxOffset.y = 1f;
            boxSize.x = 0.69f;
            boxSize.y = 2.09f;
        }
        boxCollider.size = boxSize;
        boxCollider.offset = boxOffset;
    }

    private void Jump() {
        float upMove = Input.GetAxisRaw("Vertical");

        animator.SetBool("IsJump", upMove > 0);
        //if(upMove > 0)
        //    rb2d.AddForce(Vector2.up * speed, ForceMode2D.Force);

        if (upMove > 0)
        {
            Debug.Log("Up Move");
           
            //rb2d.AddForce(Vector2.up * jumpAmount, ForceMode2D.Force);
            if (rb2d)
            rb2d.AddForce(transform.up * jumpAmount * Time.deltaTime, ForceMode2D.Impulse);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Detected");

        if (other.gameObject.CompareTag("FinishLine"))
        {
            Debug.Log("Finish Line");
            SceneManager.LoadScene("Level1");
        }
        if (other.gameObject.CompareTag("LowerBound"))
        {
            Debug.Log("Lower Bound");
            
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
    //private void OnCollisionStay2D(Collision2D other)
    //{
    //    Debug.Log("Collision Detected OnCollisionStay2D" + other.gameObject.tag.ToString());
    //    if (other.gameObject.CompareTag("Platform"))
    //    {
    //        Debug.Log("Platform Stay");
    //        isGrounded = true;
    //    }

    //}

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Platform"))
    //    {
    //        Debug.Log("Platform Exit");
    //        isGrounded = false;
    //    }
    //}
}

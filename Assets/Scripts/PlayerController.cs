using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private bool isCrouch;
    private Rigidbody2D rb2d;
    [SerializeField]public float jumpAmount = 8;
    [SerializeField]public int speed;
    [SerializeField]public BoxCollider2D boxCollider;
    
 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player controller awake");
        animator = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
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
        //if(upMove > 0)
        //    rb2d.AddForce(Vector2.up * speed, ForceMode2D.Force);

        if (upMove > 0)
        {
            //rb2d.AddForce(Vector2.up * jumpAmount, ForceMode2D.Force);
            if(rb2d)
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
        
    }
}

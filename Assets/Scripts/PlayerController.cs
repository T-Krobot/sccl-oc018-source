using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    private Animator myAnimator;
    public GameObject theQuestionHolder;
    private float moveMulti = 1;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myRigidbody.velocity = new Vector2(moveSpeed * moveMulti, myRigidbody.velocity.y);//an x and a y value

        bool willJump = false;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                willJump = true;
            }else
            {
                willJump = false;
                break;
            }
        }
        
        if (willJump || Input.GetKeyDown(KeyCode.Space) && !theQuestionHolder.activeInHierarchy)
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }
        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
        
    }

    public void ToggleRunning()
    {
        if(moveMulti == 1)
        {
            moveMulti = 0;
        }
        else
        {
            moveMulti = 1;
        }
    }
}

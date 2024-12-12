using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlatformMovementForce : MonoBehaviour
{
    // grounded variable
    public bool grounded = false;
    // number of jumps
    public int numJumps = 0;
    // Animator variable
    Animator myAnimator;
    // rigidbody variable
    Rigidbody2D myRigidbody;
    // input variables
    float horizontalInput;
    float verticalInput;
    // jump input 'key'
    public KeyCode jumpKey;
    // jump force
    public float jumpForce = 3f;
    public float secondJumpForce = 3f;
    // boolean if jump button pressed
    bool jumpPressed = false;
    // direction
    // which way is char facing
    bool facingRight = true;
    // left and right speed limit
    [SerializeField] private float speedLimit;
    // movement speed variable
    [SerializeField] private float speedMultiple;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        // send movement values to animator
        myAnimator.SetFloat("horizontalSpeed", Mathf.Abs(horizontalInput));
        Flip();
        if (Input.GetKeyDown(jumpKey))
        {
            print("Jump Button pressed");
            jumpPressed = true;
        }
    }
    private void FixedUpdate()
    {
        myAnimator.SetFloat("verticalSpeed", myRigidbody.velocity.y);
        // move left and right -- using addforce
        myRigidbody.AddForce(new Vector2(horizontalInput * speedMultiple, 0),
        ForceMode2D.Impulse);
        // left and right speed limit
        if (Mathf.Abs(myRigidbody.velocity.x) > speedLimit && myRigidbody.velocity.x
        > 0)
        {
            myRigidbody.velocity = new Vector2(speedLimit, myRigidbody.velocity.y);
        }
        else if (Mathf.Abs(myRigidbody.velocity.x) > 10 && myRigidbody.velocity.x
        < 0)
        {
            myRigidbody.velocity = new Vector2(-speedLimit,
            myRigidbody.velocity.y);
        }
        // jump off the ground
        if (jumpPressed && grounded == true)
        {
            myRigidbody.AddForce(new Vector2(0, jumpForce));
            jumpPressed = false;
            grounded = false;
            numJumps = numJumps + 1;
        }
        // jump in the air
        if (jumpPressed && numJumps == 1)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
            myRigidbody.AddForce(new Vector2(0, secondJumpForce));
            jumpPressed = false;
            numJumps = numJumps + 1;
        }
    }
    void Flip()
    {
        if (horizontalInput > 0 && facingRight == false)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            facingRight = true;
        }
        if (horizontalInput < 0 && facingRight == true)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            facingRight = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checks if object is ground object
        if (collision.gameObject.CompareTag("Ground"))
        {
            //print("Grounded");
            grounded = true;
            numJumps = 0;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    // rigidbody variable
	Rigidbody2D myRigidbody;
	// input variables
	float horizontalInput;
	float verticalInput;
	// jump input 'key'
	public KeyCode jumpKey;
	// jump force
	public float jumpForce = 30f;
	public float secondJumpForce;
	// boolean if jump button pressed
	bool jumpPressed = false;
	// direction
	// which way is char facing
	bool facingRight = true;
	// movement speed variable
	[SerializeField] private float speedMultiple;
	// Start is called before the first frame update
	
	Animator myAnimator;
	
	public bool grounded;
	public int numJumps;
	
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
			Flip();
			if (Input.GetKeyDown(jumpKey))
{
		print("Jump Button pressed");
		jumpPressed = true;
}
}
		private void FixedUpdate()
		{
				myAnimator.SetFloat("horizontalSpeed", Mathf.Abs(myRigidbody.velocity.x));
		myAnimator.SetFloat("verticalSpeed", myRigidbody.velocity.y);
		// move left and right
		myRigidbody.velocity = new Vector2(horizontalInput * speedMultiple, myRigidbody.velocity.y);
		// jump
		if (jumpPressed && grounded == true)
		{
			myRigidbody.AddForce(new Vector2(0, jumpForce));
			jumpPressed = false;
			grounded = false;
			numJumps = numJumps + 1;
		}

		// jump in the air
		if(jumpPressed && numJumps == 1)
		{
			myRigidbody.AddForce(new Vector2(0, secondJumpForce));
			jumpPressed = false;
			numJumps = numJumps + 1;

		}
		}
		void Flip()
		{
			if(horizontalInput > 0 && facingRight == false)
			{
				transform.Rotate(new Vector3(0, 180, 0));
				facingRight = true;
			}
			if(horizontalInput < 0 && facingRight == true)
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
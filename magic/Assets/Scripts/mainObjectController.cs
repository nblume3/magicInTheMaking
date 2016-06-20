using UnityEngine;
using System.Collections;

public class mainObjectController : MonoBehaviour {
	//public variables
	public float xspeed;
	public float yspeed;
	public int speed;
	public int horizontalSpeed;
	public int verticalSpeed;
	public int upSpeed;
	public int downSpeed;
	public int leftSpeed;
	public int rightSpeed;
	public static bool attack;
	public static float myX;
	public static float myY;
	public static int direction;
	public int previousDirection;
	public int previousPreviousDirection;
	public int previousPreviousPreviousDirection;
	public static bool isStill;
	public Rigidbody2D rigidbody2D;
	public static int movingDirection;

	void Start () {
		//set variables
		if (speed == 0) {
			speed = 7;
		}
		direction = 0;
		movingDirection = 0;
		previousDirection = 0;
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	// Update is called once per frame
	void Update () {
		if (attack) {
			upSpeed = 0;
			downSpeed = 0;
			leftSpeed = 0;
			rightSpeed = 0;
		}
		else if(!attack){
			if ((Input.GetKey ("w")) || (Input.GetKey ("up"))) {
				upSpeed = speed;
			} else {
				upSpeed = 0;
			}
			if ((Input.GetKey ("s")) || (Input.GetKey ("down"))) {
				downSpeed = -speed;
			} else {
				downSpeed = 0;
			}
			if ((Input.GetKey ("a")) || (Input.GetKey ("left"))) {
				leftSpeed = -speed;
			} else {
				leftSpeed = 0;
			}
			if ((Input.GetKey ("d")) || (Input.GetKey ("right"))) {
				rightSpeed = speed;
			} else {
				rightSpeed = 0;
			}
		}
		horizontalSpeed = leftSpeed + rightSpeed;
		verticalSpeed = upSpeed + downSpeed;
		rigidbody2D.velocity = new Vector2 (horizontalSpeed, verticalSpeed);
		if (horizontalSpeed == 0 && verticalSpeed == speed) {
			movingDirection = 1;
		}
		if (horizontalSpeed == 0 && verticalSpeed == -speed) {
			movingDirection = 2;
		}
		if (horizontalSpeed == -speed && verticalSpeed == 0) {
			movingDirection = 3;
		}
		if (horizontalSpeed == speed && verticalSpeed == 0) {
			movingDirection = 4;
		}
		if (horizontalSpeed == 0 && verticalSpeed == 0) {
			isStill = true;
		}
		else if(horizontalSpeed != 0 || verticalSpeed != 0) {
			isStill = false;
		}



		myX = gameObject.transform.position.x;
		myY = gameObject.transform.position.y;
		//Detects when a new direction (up) is pressed and sets directions accordingly
		if (((Input.GetKeyDown("w")) || (Input.GetKeyDown("up"))) && direction != 1) {
			previousPreviousPreviousDirection = previousPreviousDirection;
			previousPreviousDirection = previousDirection;
			previousDirection = direction;
			direction = 1;
		//	Debug.Log(direction);
		//	isStill = false;
		}
		//Detects when a new direction (down) is pressed and sets directions accordingly
		if (((Input.GetKeyDown("s")) || (Input.GetKeyDown("down"))) && direction != 2) {
			previousPreviousPreviousDirection = previousPreviousDirection;
			previousPreviousDirection = previousDirection;
			previousDirection = direction;
			direction = 2;
		//	Debug.Log(direction);
		//	isStill = false;
		}
		//Detects when a new direction (left) is pressed and sets directions accordingly
		if (((Input.GetKeyDown("a")) || (Input.GetKeyDown("left"))) && direction != 3) {
			previousPreviousPreviousDirection = previousPreviousDirection;
			previousPreviousDirection = previousDirection;
			previousDirection = direction;
			direction = 3;
		//	Debug.Log(direction);
		//	isStill = false;
		}
		//Detects when a new direction (right) is pressed and sets directions accordingly
		if (((Input.GetKeyDown("d")) || (Input.GetKeyDown("right"))) && direction != 4) {
			previousPreviousPreviousDirection = previousPreviousDirection;
			previousPreviousDirection = previousDirection;
			previousDirection = direction;
			direction = 4;
		//	Debug.Log(direction);
		//	isStill = false;
		}
		//when no directional input is detected prevent the character from moving
		if(!((Input.GetKey("left")) || (Input.GetKey("right")) || (Input.GetKey("d")) || (Input.GetKey("a")) || (Input.GetKey("up")) || (Input.GetKey("down")) || (Input.GetKey("w")) || (Input.GetKey("s"))) && direction != 0) {
		////	direction = 0;
			isStill = true;
		//	Debug.Log(direction);
		//	rigidbody2D.velocity = new Vector2 (0, 0);
		//	Debug.Log(direction);
		}
		//when pressing up move the character up and change the sprite to show that the character is facing up
		if((direction == 1) && (Input.GetKey("up") || Input.GetKey("w"))) {
		//	rigidbody2D.velocity = new Vector2 (0, yspeed);
		//	movingDirection = 1;
		//	isStill = false;
		}
		//when pressing down move the character down and change the sprite to show that the character is facing down
		if((direction == 2) && (Input.GetKey("down") || Input.GetKey("s"))) {
		//	rigidbody2D.velocity = new Vector2 (0, -yspeed);
		//	movingDirection = 2;
		//	isStill = false;
		}
		//when pressing left move the character left and change the sprite to show that the character is facing left
		if((direction == 3) && (Input.GetKey("left") || Input.GetKey("a"))) {
		//	GetComponent<Rigidbody2D>().velocity = new Vector2 (-xspeed, 0);
		//	movingDirection = 3;
		//	isStill = false;
		}
		//when pressing right move the character right and change the sprite to show that the character is facing right
		if((direction == 4) && (Input.GetKey("right") || Input.GetKey("d"))) {
		//	rigidbody2D.velocity = new Vector2 (xspeed, 0);
		//	movingDirection = 4;
		//	isStill = false;
		}
		//detects if there is any directional input so that if a button has been released the character will move in the most recent direction that is still receiving input.
		if (((Input.GetKey ("left")) || (Input.GetKey ("right")) || (Input.GetKey ("d")) || (Input.GetKey ("a")) || (Input.GetKey ("up")) || (Input.GetKey ("down")) || (Input.GetKey ("w")) || (Input.GetKey ("s"))) && direction != 0) {
			if ((direction == 1) && !(Input.GetKey ("up") || Input.GetKey ("w"))) {
		//		rigidbody2D.velocity = new Vector2 (0, 0);
		//		isStill = true;
				direction = previousDirection;
			}
			if ((direction == 2) && !(Input.GetKey ("down") || Input.GetKey ("s"))) {
		//		rigidbody2D.velocity = new Vector2 (0, 0);
		//		isStill = true;
				direction = previousDirection;
			}
			if ((direction == 3) && !(Input.GetKey ("left") || Input.GetKey ("a"))) {
		//		rigidbody2D.velocity = new Vector2 (0, 0);
		//		isStill = true;
				direction = previousDirection;
			}
			if ((direction == 4) && !(Input.GetKey ("right") || Input.GetKey ("d"))) {
		//		rigidbody2D.velocity = new Vector2 (0, 0);
		//		isStill = true;
				direction = previousDirection;
			}
			//Shifts the directions up if the current and previous direction are the same. I have been informed that this would have been easier to do through an array.
			if (previousDirection == direction) {
				previousDirection = previousPreviousDirection;
				previousPreviousDirection = previousPreviousPreviousDirection;
			}
		}
		if(Input.GetKeyDown ("mouse 0") && attack == false) {
			attack = true;
			Debug.Log("Hyyaahh!!");

		}
	}
//	void OnCollisionEnter2D(Collision2D coll) {
//		if (coll.gameObject.tag == "SafeCollision")
//			coll.gameObject.SendMessage("ApplyDamage", 10);
		
//	}
}

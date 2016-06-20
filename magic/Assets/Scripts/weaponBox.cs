using UnityEngine;
using System.Collections;

public class weaponBox : MonoBehaviour {

	public Sprite attackAnimation;
	public Sprite notAttacking;
	public bool haveAttacked;
	private Animator animator;
	public float xScale;
	public float yScale;
	public float scale;
	public float attackDuration;
	public string weaponType;
	public float animationSpeed;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		xScale = scale;
		yScale = scale;
		weaponType = "sword";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			weaponType = "sword";
		}
		if (Input.GetKeyDown ("2")) {
			weaponType = "dagger";
		}
		if (Input.GetKeyDown ("3")) {
			weaponType = "axe";
		}
		if (Input.GetKeyDown ("4")) {
			weaponType = "hammer";
		}
		//barrier
		if (weaponType == "sword") {
			attackDuration = 0.4f;
			yScale = 4;
			scale = 4;
			animationSpeed = 1.0f;
		}
		if (weaponType == "dagger") {
			attackDuration = 0.25f;
			yScale = 2.5f;
			scale = 2.5f;
			animationSpeed = 1.0f;
		}
		if (weaponType == "axe") {
			attackDuration = 0.6f;
			yScale = 4.5f;
			scale = 4.5f;
			animationSpeed = 1.0f;
		}
		if (weaponType == "hammer") {
			attackDuration = 0.7f;
			yScale = 5;
			scale = 5;
			animationSpeed = 1.0f;
		}
		//barrier
		transform.localScale = new Vector3(xScale, yScale, 0);
		if (mainObjectController.movingDirection == 1) {
			transform.position = new Vector2(mainObjectController.myX, mainObjectController.myY + 0.5f);
			transform.rotation = Quaternion.Euler(0, 0, 90);
			xScale = scale;
		}
		if (mainObjectController.movingDirection == 2) {
			transform.position = new Vector2(mainObjectController.myX, mainObjectController.myY - 1);
			transform.rotation = Quaternion.Euler(0, 0, 270);
			xScale = scale;
		}
		if (mainObjectController.movingDirection == 3) {
			transform.position = new Vector2(mainObjectController.myX - 1, mainObjectController.myY);
			transform.rotation = Quaternion.Euler(0, 0, 0);
			xScale = -scale;
		}
		if (mainObjectController.movingDirection == 4) {
			transform.position = new Vector2(mainObjectController.myX + 1, mainObjectController.myY);
			transform.rotation = Quaternion.Euler(0, 0, 0);
			xScale = scale;
		}
		if (mainObjectController.attack == true && haveAttacked == false) {
			//GetComponent<SpriteRenderer>().sprite = attackAnimation;
			StartCoroutine(WaitForAttack());
		}
	}
	IEnumerator WaitForAttack() {
		Debug.Log ("waiting...");
		haveAttacked = true;
		animator.SetBool ("attack", true);
		yield return new WaitForSeconds (attackDuration);
		Debug.Log ("done waiting");
		animator.SetBool ("attack", false);
		mainObjectController.attack = false;
		Debug.Log (mainObjectController.attack);
		haveAttacked = false;
	}
}

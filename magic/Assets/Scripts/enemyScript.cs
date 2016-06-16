using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {
	public int health;
	public bool hittable;
	public bool overlapWithWeapon;
	// Use this for initialization
	void Start () {
		health = 3;
		hittable = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (mainObjectController.attack);
		if (health == 0) {
			Destroy(gameObject);
		}
		if (overlapWithWeapon && mainObjectController.attack && hittable) {
			Debug.Log("You're tearing me apart, weapon!");
			health -= 1;
			StartCoroutine(WaitUntilHittable());
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "WeaponBox") {
		Debug.Log ("overlapwithweapon");
		overlapWithWeapon = true;
		}
	}
	IEnumerator WaitUntilHittable() {
		hittable = false;
		yield return new WaitForSeconds (0.5f);
		hittable = true;
	}
	void OnTriggerExit2D(Collider2D other) {
		Debug.Log("away from weapon");
		overlapWithWeapon = false;
	}
}

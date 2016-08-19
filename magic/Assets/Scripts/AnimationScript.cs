using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {
	private SpriteRenderer spriteRenderer;
	private Animator animator;
	public int walkingDirection;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		walkingDirection = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

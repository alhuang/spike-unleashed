using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour {

	Animator anim; 

	private bool vertical = false;
	private bool horizontal = false;

	private bool facingRight = true;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		float xInput = Input.GetAxisRaw ("Horizontal");
		float yInput = Input.GetAxisRaw ("Vertical");
		Vector3 local = this.transform.localScale;
		float locX = Mathf.Abs (local.x);

		if (xInput > 0 && !facingRight) {
			facingRight = true;
			local.x = locX;
			this.transform.localScale = local;
		} else if (xInput < 0 && facingRight) {
			facingRight = false;
			local.x = -locX;
			this.transform.localScale = local;
		}

		if (!vertical && !horizontal) {
			if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
				anim.SetTrigger ("MoveRight");
				horizontal = true;
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				anim.SetTrigger ("MoveDown");
				vertical = true;
			} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				anim.SetTrigger ("MoveUp");
				vertical = true;
			} 

			if ((Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) &&
			    xInput != 0) {
				anim.SetTrigger ("MoveRight");
				horizontal = true;
			}

			if ((Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow)) &&
				yInput != 0) {
				if (yInput > 0) {
					anim.SetTrigger ("MoveUp");
				} else {
					anim.SetTrigger ("MoveDown");
				}
				vertical = true;
			}
		} else if (vertical && !horizontal) {
			if (yInput == 0) {
				vertical = false;
				if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
					anim.SetTrigger ("MoveRight");
				} else {
					anim.SetTrigger ("Stop");
				}
			} 

			if (xInput != 0) {
				horizontal = true;
			}
		} else if (!vertical && horizontal) {
			if (xInput == 0) {
				horizontal = false;
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					anim.SetTrigger ("MoveUp");
				} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
					anim.SetTrigger ("MoveDown");
				} else {
					anim.SetTrigger ("Stop");
				}
					
			}

			if (yInput != 0) {
				vertical = true;
			}
		} else {
			if (xInput == 0 && yInput == 0) {
				horizontal = false;
				vertical = false;
				anim.SetTrigger ("Stop");
			} else if (xInput == 0) {
				horizontal = false;
				if (Input.GetKey (KeyCode.UpArrow)) {
					anim.SetTrigger ("MoveUp");
				} else if (Input.GetKey (KeyCode.DownArrow)) {
					anim.SetTrigger ("MoveDown");
				}
			} else if (yInput == 0) {
				vertical = false;
				if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
					anim.SetTrigger ("MoveRight");
				} 
			}
		}
	}
}

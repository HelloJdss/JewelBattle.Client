using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translate : MonoBehaviour {

	//float gravity = 2.0f;
	public static float speed = 5.0f;
	//float time = 3.0f;
	private Vector3 movedirection = Vector3.zero;
	private Animator ani;
	private CharacterController controller;
	private bool touchDown = false;
	void Start()
	{
		ani = transform.Find("LowPoly").GetComponent<Animator> ();
		controller = transform.GetComponent<CharacterController> ();
	}

	void FixedUpdate () {

		movedirection = new Vector3 (-Input.GetAxis("Horizontal"),0,-Input.GetAxis("Vertical"));
		movedirection = transform.TransformDirection (movedirection);
		movedirection *= speed;

		//移动
		controller.Move (movedirection * Time.deltaTime);



		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {

			//	//transform.GetComponent<Animation> ().Play ("run");
			ani.SetBool ("run", true);
			touchDown = true;
		} else {
			touchDown = false;
		}


		if (Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)) {

		//	//transform.GetComponent<Animation> ().Play("idle");
			if (!touchDown) {
				ani.SetBool ("run", false);
			}
		}

	}
}
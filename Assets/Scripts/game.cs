using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour {

	public Text cry_blue;
	public Text cry_red;
	public Text cry_white;

	public GameObject cry_blue_throw;
	public GameObject cry_red_throw;
	public GameObject cry_white_throw;
	public GameObject throwPoint;
	public Text warning;



	private Animator animator;
	private int combo = 1;
	private float waitTime = 0.2f;
	private float warnTime = 2.0f;
	private float flySpeed = 10.0f;

	// Use this for initialization
	void Start () 
	{
		animator = transform.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.J)) {
			switch (combo) {
			case 1:
				animator.SetTrigger ("attack1");
				break;
			case 2:
				animator.SetTrigger ("attack2");
				break;
			case 3:
				animator.SetTrigger ("attack3");
				//animator.SetFloat("Blend",0.8f);
				break;
			default:
				animator.SetTrigger ("attack1");
				break;
			}
		}
		//Debug.Log (combo);

		if (Input.GetKeyDown (KeyCode.K)) {
			animator.SetTrigger ("flight");
			translate.speed = flySpeed;
		}

		if(Input.GetKeyDown(KeyCode.U)){
			if (playerCollision.cry_blue_amount > 0) {
				animator.SetTrigger ("throw");
				StartCoroutine (cry_throw (cry_blue_throw, transform.rotation));
				playerCollision.cry_blue_amount--;
				cry_blue.text = playerCollision.cry_blue_amount + "";
			} else {
				StartCoroutine (warn());
			}
		}
		if(Input.GetKeyDown(KeyCode.I)){
			if (playerCollision.cry_red_amount > 0) {
				animator.SetTrigger ("throw");
				StartCoroutine (cry_throw (cry_red_throw, Quaternion.Euler (transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z)));
				playerCollision.cry_red_amount--;
				cry_red.text = playerCollision.cry_red_amount + "";
			} else {
				StartCoroutine (warn());
			}
		}
		if(Input.GetKeyDown(KeyCode.O)){
			if (playerCollision.cry_white_amount > 0) {
				animator.SetTrigger ("throw");
				StartCoroutine (cry_throw (cry_white_throw, transform.rotation));
				playerCollision.cry_white_amount--;
				cry_white.text = playerCollision.cry_white_amount + "";
			} else {
				StartCoroutine (warn());
			}
		}
	}

	IEnumerator cry_throw(GameObject cry,Quaternion rotate)
	{
		yield return new WaitForSeconds (waitTime);
		GameObject n = Instantiate (cry , throwPoint.transform.position , rotate);
		Vector3 fwd = transform.TransformDirection (Vector3.forward); 
		n.transform.GetComponent<Rigidbody> ().AddForce (fwd * 500);
	}

	IEnumerator warn()
	{
		warning.text = "钻石不足！";
		yield return new WaitForSeconds (warnTime);
		warning.text = "";
	}

	void combo1Start()
	{
		combo = 2;
	}
	void combo1End()
	{
		combo = 1;
	}
	void combo2Start()
	{
		combo = 3;
	}
	void combo2End()
	{
		combo = 1;
	}

	void powerEnd()
	{
		combo = 1;
	}

	void flyEnd()
	{
		translate.speed = 5.0f;
	}
}

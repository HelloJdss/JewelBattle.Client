using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCollision : MonoBehaviour {

	public Text cry_blue;
	public Text cry_red;
	public Text cry_white;



	public GameObject recovery;
	public GameObject speedUp;

	public Slider blood;
	public Text warning;

	public static int cry_blue_amount = 0;
	public static int cry_red_amount = 0;
	public static int cry_white_amount = 0;
	//public static int blood_volume;

	private Vector3 playerPos;
	private float speedRate = 1.5f;
	private bool isSpeedUp = false;
	private float buffLastTime = 8.0f;
	//private float buffReliveTime = 8.0f;
	private float warnTime = 2.0f;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = transform.position;
	}


	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.gameObject.tag == "crystal_blue") {
			Destroy (hit.gameObject);
			cry_blue_amount++;
			cry_blue.text = cry_blue_amount+"";
		}
		if (hit.gameObject.tag == "crystal_red") {
			Destroy (hit.gameObject);
			cry_red_amount++;
			cry_red.text = cry_red_amount + "";
		}
		if (hit.gameObject.tag == "crystal_white") {
			Destroy (hit.gameObject);
			cry_white_amount++;
			cry_white.text = cry_white_amount + "";
		}
		if (hit.gameObject.tag == "sandwich") {
			StartCoroutine (sandwichRelive(hit.gameObject));
		}
		if (hit.gameObject.tag == "icecream") {
			if (!isSpeedUp) {
				StartCoroutine (speedup (hit.gameObject));
			} else {
				StartCoroutine (warn(hit.gameObject));
			}
		}

	}


	IEnumerator speedup(GameObject ice)
	{
		ice.SetActive (false);
		isSpeedUp = true;
		Instantiate (speedUp,playerPos,recovery.transform.rotation);
		translate.speed *= speedRate;
		yield return new WaitForSeconds (buffLastTime);
		translate.speed = 5.0f;
		isSpeedUp = false;
		ice.SetActive (true);
	}

	IEnumerator warn(GameObject ice)
	{
		ice.SetActive (false);
		warning.text = "速度buff不能叠加！";
		yield return new WaitForSeconds (warnTime);
		warning.text = "";
		yield return new WaitForSeconds (buffLastTime);
		ice.SetActive (true);
	}

	IEnumerator sandwichRelive(GameObject san)
	{
		san.SetActive (false);
		blood.value += 10;
		Instantiate (recovery,playerPos,recovery.transform.rotation);
		yield return new WaitForSeconds (buffLastTime);
		san.SetActive (true);
	}
}

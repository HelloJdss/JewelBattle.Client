using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crystalCollision : MonoBehaviour {

	public GameObject blue_hit_effect;
	public GameObject red_hit_effect;
	public GameObject white_hit_effect;

	public Slider blood;

	private Animator animator;
	private float cry_damage = 10.0f;


	// Use this for initialization
	void Start () {
		animator = transform.Find("LowPoly").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (blood.value <= 0) {
			animator.SetTrigger ("dying");
			Destroy (gameObject,1.0f);
		}
	}

	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "blue_hit") {
			Destroy (hit.gameObject);
			Instantiate (blue_hit_effect,hit.transform.position,blue_hit_effect.transform.rotation);
			animator.SetTrigger ("getting_hit");
			blood.value -= 10;
		}
		if (hit.gameObject.tag == "red_hit") {
			Destroy (hit.gameObject);
			Instantiate (red_hit_effect,hit.transform.position,red_hit_effect.transform.rotation);
			animator.SetTrigger ("getting_hit");
			blood.value -= 10;
		}
		if (hit.gameObject.tag == "white_hit") {
			Destroy (hit.gameObject);
			Instantiate (white_hit_effect,hit.transform.position,white_hit_effect.transform.rotation);
			animator.SetTrigger ("getting_hit");
			blood.value -= 10;
		}
	}
}

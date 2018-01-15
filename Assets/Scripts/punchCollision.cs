using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class punchCollision : MonoBehaviour {
	//test

	public GameObject normal_hit;
	public Slider blood;


	private Animator animator;
	private Transform player;
	private Vector3 playerDir;

	// Use this for initialization
	void Start () 
	{
		animator = transform.Find("LowPoly").GetComponent<Animator> ();
		player = transform.Find ("LowPoly");
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerDir = player.forward;
		//playerDir = player.TransformDirection (Vector3.forward);
		if (blood.value <= 0) {
			animator.SetTrigger ("dying");
			Destroy (gameObject,1.0f);
		}
		if(Input.GetKeyDown(KeyCode.J)){
			AtkCondition(1.2f,70);
		}

		//Debug.Log (playerDir);


	}


	//void OnTriggerEnter(Collider hit)
	//{
	//	if (hit.gameObject.tag == "punch" && Input.GetKeyDown(KeyCode.J)) {
	//		animator.SetTrigger ("fighting_getting_hit");
	//		blood.value -= 4;
	//	}
	//}

	void AtkCondition(float _range,float _angle)
	{
		Collider[] colliderArr = Physics.OverlapSphere (transform.position,_range,LayerMask.GetMask("enemy"));
		if (colliderArr.Length <= 0) {
			return;
		}
		//Debug.Log ("start!");
		for (int i = 0; i < colliderArr.Length; i++) {
			Vector3 v3 = colliderArr [i].gameObject.transform.position - transform.position;
			float angle = Vector3.Angle (v3,playerDir);
			if (angle < _angle) {
				//Debug.Log ("enter!");
				StartCoroutine(getHit(colliderArr[i].gameObject));

			}
		}
	}

	IEnumerator getHit(GameObject enemy)
	{
		yield return new WaitForSeconds (0.4f);
		enemy.transform.Find("LowPoly").GetComponent<Animator>().SetTrigger ("getting_hit");
		Instantiate (normal_hit,enemy.transform.position,normal_hit.transform.rotation);
	}
}

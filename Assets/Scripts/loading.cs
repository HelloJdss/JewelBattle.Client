using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loading : MonoBehaviour {

	public GameObject crystal_blue;
	public GameObject crystal_white;
	public GameObject crystal_red;

	public GameObject sandwich;
	public GameObject icecream;

	int minX = -51;
	int maxX = 46;
	int minZ = -41;
	int maxZ = 37;

	// Use this for initialization
	void Start () {
		System.Random random = new System.Random ();
		for (int i = 0; i < 33; i++) {
			Instantiate (crystal_blue,new Vector3(random.Next(minX,maxX) , crystal_blue.transform.position.y , random.Next(minZ,maxZ)),crystal_blue.transform.rotation);
			Instantiate (crystal_white,new Vector3(random.Next(minX,maxX) , crystal_white.transform.position.y , random.Next(minZ,maxZ)),crystal_white.transform.rotation);
			Instantiate (crystal_red,new Vector3(random.Next(minX,maxX) , crystal_red.transform.position.y , random.Next(minZ,maxZ)),crystal_red.transform.rotation);
		}

		for (int i = 0; i < 15; i++) {
			Instantiate (sandwich,new Vector3(random.Next(minX,maxX) , sandwich.transform.position.y , random.Next(minZ,maxZ)),sandwich.transform.rotation);
			Instantiate (icecream,new Vector3(random.Next(minX,maxX) , icecream.transform.position.y , random.Next(minZ,maxZ)),icecream.transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

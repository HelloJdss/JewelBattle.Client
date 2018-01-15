using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	//float gravity = 2.0f;
	//float speed = 5.0f;
	private int State=0;//角色状态  
	//private int oldState=0;//前一次角色的状态 
	private int DOWN = 0;//角色状态向后  
	private int LEFT = 1;//角色状态向左  
	private int UP = 2;//角色状态向前  
	private int RIGHT =3;//角色状态向右  

	//private Transform child;

	void Start()
	{
		//child = transform.Find ("Character");
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			//transform.Rotate (0,180,0,Space.World);
			setState(UP);  
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			//transform.Rotate (0,180,0);
			setState(DOWN);
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			//transform.Rotate (0,90,0);
			setState(LEFT);
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			//transform.Rotate (0,-90,0);
			setState(RIGHT);
		}
			
	}

	void setState(int currState)  
	{
		int rotateValue = (currState - State) * 90;  
		transform.Rotate(Vector3.up, rotateValue);//旋转角色  
		//child.Rotate(Vector3.up, rotateValue);//旋转角色 
		//oldState = State;//赋值，方便下一次计算  
		State = currState;//赋值，方便下一次计算  
	}
}

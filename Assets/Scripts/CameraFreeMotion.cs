using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFreeMotion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Input.GetAxis("Vertical") * (-10.0F), Input.GetAxis("Horizontal")*10.0F, 0);
		
	}
}

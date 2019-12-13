using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BoatMotion : MonoBehaviour {

    private Rigidbody _boatRB;
    public float moveSpeed = 1;
    private Vector3 moveVelocity;
    private float _movement;

	// Use this for initialization
	void Start () {
        _boatRB = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        _movement = CrossPlatformInputManager.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //transform.Translate(0, 0, _movement);
        //_boatRB.velocity = transform.forward * moveSpeed;
        _boatRB.AddForce(0, 0, -_movement*moveSpeed, ForceMode.Acceleration);
    }
}

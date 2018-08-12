using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public int speedLR, speedFB;
    private Transform myTransform;
    private CharacterController myCC;
	// Use this for initialization
	void Start () {
        myTransform = this.gameObject.transform;
        myCC = this.gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 delta = Vector3.zero;
        delta.z = Input.GetAxis("Vertical") * speedFB;
        delta.x = Input.GetAxis("Horizontal") * speedLR;
        delta = myTransform.TransformDirection(delta);
        myCC.Move(delta);
    }
}

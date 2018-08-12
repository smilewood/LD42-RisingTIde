using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    private Camera myCamera;
    private float fov;
    public int minFOV, maxFOV, speed;
	// Use this for initialization
	void Start () {
        myCamera = this.gameObject.GetComponent<Camera>();
        fov = maxFOV;
        myCamera.fieldOfView = fov;
    }

    // Update is called once per frame
    void Update () {
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");

        if (scrollDelta != 0)
        {
            fov = Mathf.Clamp((fov + (scrollDelta * speed)), minFOV, maxFOV);
            myCamera.fieldOfView = fov;
        }

    }
}

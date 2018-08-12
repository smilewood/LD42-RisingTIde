using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickTracker : MonoBehaviour {

    private Camera myCamera;
	// Use this for initialization
	void Start () {
        myCamera = this.gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                GameObject objectHit = hit.transform.gameObject;

                if (!EventSystem.current.IsPointerOverGameObject() && objectHit.name.Equals("Base"))
                {
                    objectHit.SendMessage("OnClick");
                }
            }
        }
        
	}
}

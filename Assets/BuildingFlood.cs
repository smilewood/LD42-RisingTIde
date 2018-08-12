using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFlood : MonoBehaviour {
    private WorldTracker worldTracker;

    public GameObject rubble;
    public GameObject myBaseObject;
    public BuildingType myType;
    private GameObject water;

    private void Start()
    {
        worldTracker = GameObject.Find("WorldTracker").GetComponent<WorldTracker>();

        water = GameObject.Find("Ocean");
    }

    private void Update()
    {
        if (water.transform.position.y >= myBaseObject.transform.position.y)
        {
            worldTracker.MakeRubble(myBaseObject, myType);
        }
    }
    
}

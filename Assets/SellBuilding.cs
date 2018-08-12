using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBuilding : MonoBehaviour {
    public GameObject myBaseObject;
    public BuildingType myType;
    private WorldTracker worldTracker;

    // Use this for initialization
    void Start()
    {
        worldTracker = GameObject.Find("WorldTracker").GetComponent<WorldTracker>();

    }

    public void Sell()
    {
        worldTracker.SellBuilding(myBaseObject, myType);
    }
}

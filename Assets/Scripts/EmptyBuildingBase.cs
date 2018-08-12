using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptyBuildingBase : MonoBehaviour {
    private WorldTracker worldTracker;
    private GameObject water;

    private float myY;
    public GameObject purchaceUI;
	// Use this for initialization
	void Start () {
        worldTracker = GameObject.Find("WorldTracker").GetComponent<WorldTracker>();
        myY = this.gameObject.transform.position.y;
        purchaceUI.SetActive( false);
        water = GameObject.Find("Ocean");

    }

    public void OnClick()
    {
        if (water.transform.position.y >= this.transform.position.y)
            return;
        if (!purchaceUI.activeInHierarchy)
        {
            purchaceUI.SetActive(true);
            Transform purchaceUIOverlay = purchaceUI.transform.Find("PurchaceUI");
            purchaceUIOverlay.Find("HouseButton").Find("Cost").GetComponent<Text>().text = 
                worldTracker.CostToBuild(BuildingType.House, myY).ToString();
            purchaceUIOverlay.Find("FactoryButton").Find("Cost").GetComponent<Text>().text =
                worldTracker.CostToBuild(BuildingType.Factory, myY).ToString();
            purchaceUIOverlay.Find("ShopButton").Find("Cost").GetComponent<Text>().text =
                worldTracker.CostToBuild(BuildingType.Shop, myY).ToString();
            purchaceUIOverlay.Find("LabButton").Find("Cost").GetComponent<Text>().text =
               worldTracker.CostToBuild(BuildingType.Lab, myY).ToString();
        }
        else
        {
            purchaceUI.SetActive(false);
        }
    }
}

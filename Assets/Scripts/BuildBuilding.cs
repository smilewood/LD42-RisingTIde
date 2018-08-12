using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBuilding : MonoBehaviour {
    public GameObject myBase;
    public BuildingType typeToBuild;
    private WorldTracker worldTracker;

    private void Start()
    {
        worldTracker = GameObject.Find("WorldTracker").GetComponent<WorldTracker>();
    }
    public void Build()
    {
        switch (typeToBuild)
        {
            case BuildingType.Factory:
                worldTracker.BuildFactory(myBase);
                break;
            case BuildingType.House:
                worldTracker.BuildHouse(myBase);
                break;
            case BuildingType.Lab:
                worldTracker.BuildLab(myBase);
                break;
            case BuildingType.Shop:
                worldTracker.BuildShop(myBase);
                break;
            default:
                return;

        }
    }

}

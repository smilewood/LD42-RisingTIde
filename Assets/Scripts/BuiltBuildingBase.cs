using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuiltBuildingBase : MonoBehaviour
{
    public Canvas BuildingUI;
    private void Start()
    {
        BuildingUI.enabled = false;
    }
    public void OnClick()
    {
        if (BuildingUI.enabled == false)
        {
            BuildingUI.enabled = true;
        }
        else
        {
            BuildingUI.enabled = false;
        }
    }

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTextTracker : MonoBehaviour {
    private WorldTracker worldTracker;

    // Use this for initialization
    void Start () {
        worldTracker = GameObject.Find("WorldTracker").GetComponent<WorldTracker>();

    }

    // Update is called once per frame
    void Update () {
        this.gameObject.GetComponent<Text>().text = "Money: " + worldTracker.money + " (" + worldTracker.MoneyPerTick + "/s)";

    }
}

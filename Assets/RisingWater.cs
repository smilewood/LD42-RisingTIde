using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour {
    public float speed;
    private WorldTracker worldTracker;
    public GameObject gameOverUI;
    private void Start()
    {
        worldTracker = GameObject.Find("WorldTracker").GetComponent<WorldTracker>();
    }
    // Update is called once per frame
    void Update () {
        Vector3 temp = this.gameObject.transform.position;
        temp.y += (speed + (worldTracker.FactoryCount() * .01f)) * Time.deltaTime;
        this.gameObject.transform.position = temp;
        if (temp.y >= 79)
        {
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
        }
	}
}

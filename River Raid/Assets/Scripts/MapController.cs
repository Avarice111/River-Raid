using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

    private GameObject mapDestructionPoint;
    private GameObject behindDestructionPoint;
    private double map_length;

	// Use this for initialization
	void Start () {
        mapDestructionPoint = GameObject.Find("MapDestructionPoint");
        behindDestructionPoint = GameObject.Find("BehindDestructionPoint");
        map_length = 50.19;
    }
	
	// Update is called once per frame
	void Update () {
        if (behindDestructionPoint.transform.position.y > mapDestructionPoint.transform.position.y && mapDestructionPoint.transform.position.y > transform.position.y)
        {
            mapDestructionPoint.transform.position = new Vector3(mapDestructionPoint.transform.position.x, mapDestructionPoint.transform.position.y + (float)map_length, transform.position.z);
            Destroy(gameObject);
        }

    }
}

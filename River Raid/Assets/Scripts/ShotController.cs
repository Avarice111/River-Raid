using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{

    public float speed;
    public GameObject shotDestructionPoint;

    // Use this for initialization
    void Start()
    {
        shotDestructionPoint = GameObject.Find("ShotDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        if (transform.position.y > shotDestructionPoint.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}

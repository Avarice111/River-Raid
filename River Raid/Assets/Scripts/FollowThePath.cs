using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    private GameObject behindDestructionPoint;

    // Use this for initialization
    private void Start()
    {

        // Set position of Enemy as position of the first waypoint
        if(waypoints.Length > 0)
            transform.position = waypoints[waypointIndex].transform.position;
        behindDestructionPoint = GameObject.Find("BehindDestructionPoint");
    }

    // Update is called once per frame
    private void Update()
    {
        if (waypointIndex >= waypoints.Length)
            waypointIndex = 0;

        if (waypoints.Length > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);



            if (Vector2.Distance(transform.position, waypoints[waypointIndex].transform.position) == 0)
            {
                waypointIndex += 1;
            }

            if (transform.position.y < behindDestructionPoint.transform.position.y)
            {
                Destroy(gameObject);
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

    public int scoreToGive;
    private ScoreManager theScoreManager;
    private LifesManager theLifesManager;
    private BridgeNumberManager theBridgeNumberManager;
    private GameObject respawnPoint;
    private GameObject player;
    private double map_length;

    private FuelManager theFuelManager;

    private void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        theLifesManager = FindObjectOfType<LifesManager>();
        theBridgeNumberManager = FindObjectOfType<BridgeNumberManager>();
        respawnPoint = GameObject.Find("RespawnPoint");
        player = GameObject.Find("Player");
        map_length = 50.19;
        theFuelManager = FindObjectOfType<FuelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( tag == "Bridge")
        {
            respawnPoint.transform.position = new Vector3(respawnPoint.transform.position.x, respawnPoint.transform.position.y + (float)map_length, transform.position.z);
            theBridgeNumberManager.NextBridge();

        }
        if (collision.tag == "Bolt")
        {
            if (tag == "Oil")
                theFuelManager.refueling = false;
            theScoreManager.AddScore(scoreToGive);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if(collision.tag == "Player")
        {
            if (tag != "Oil")
            {
                player.transform.position = new Vector3(respawnPoint.transform.position.x, respawnPoint.transform.position.y, transform.position.z);
                theLifesManager.SubstractLife();
            }
        }
    }

    /*private void OnTriggerStay2D(Collider2D coll)
    {
        // Debug-draw all contact points and normals
        theFuelManager.AddFuel(fuelToGive * Time.deltaTime);
        theFuelManager.refueling = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        theFuelManager.refueling = false;
    }*/
}

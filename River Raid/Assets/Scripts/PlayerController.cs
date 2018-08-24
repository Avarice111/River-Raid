using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movespeed;
    private Rigidbody2D rb2d;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    public bool refueling;

    public double startingPosition;
    public GameObject map_0;
    public GameObject existingMap;
    private Vector3 mapStartingPosition;

    private LifesManager theLifesManager;
    private GameObject respawnPoint;
    private GameObject mapDestructionPoint;

    private double destructionPointStartingPosition;

    private FuelManager theFuelManager;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        mapStartingPosition = new Vector3(0, 0, 0);
        theLifesManager = FindObjectOfType<LifesManager>();
        theFuelManager = FindObjectOfType<FuelManager>();
        respawnPoint = GameObject.Find("RespawnPoint");
        mapDestructionPoint = GameObject.Find("MapDestructionPoint");
        startingPosition = -24.5;
        destructionPointStartingPosition = 26.98;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if(!refueling)
            rb2d.velocity = new Vector2(moveHorizontal * movespeed, moveVertical * movespeed);
        else
            rb2d.velocity = new Vector2(moveHorizontal * movespeed/3, moveVertical * movespeed/3);


        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time * fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

    }

    public void NewGame()
    {
        existingMap = GameObject.Find("map_0");
        if (!existingMap)
            Instantiate(map_0, mapStartingPosition, transform.rotation);
        transform.position = new Vector3(0, (float)startingPosition, 0);
        theLifesManager.ResetLifes();
        theFuelManager.AddFuel(100);
        respawnPoint.transform.position = new Vector3(0, (float)startingPosition, 0);
        mapDestructionPoint.transform.position = new Vector3(0, (float)destructionPointStartingPosition, 0); 

    }

}

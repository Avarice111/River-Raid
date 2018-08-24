using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefuelOnContact : MonoBehaviour
{
    public int fuelToGive;
    private FuelManager theFuelManager;
    private PlayerController thePlayerController;

    private void Start()
    {
        theFuelManager = FindObjectOfType<FuelManager>();
        thePlayerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            theFuelManager.AddFuel(fuelToGive * Time.deltaTime);
            theFuelManager.refueling = true;
            thePlayerController.refueling = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theFuelManager.refueling = false;
            thePlayerController.refueling = false;
        }
            
    }
}

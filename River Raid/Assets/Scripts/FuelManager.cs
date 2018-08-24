using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour {

    public float fuel;
    public int usageOfFuel;
    public bool refueling;
    Text text;
    private PlayerController thePlayerController;

    private void Awake()
    {
        text = GetComponent<Text>();
        thePlayerController = FindObjectOfType<PlayerController>();

        fuel = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (fuel <= 0)
        {
            thePlayerController.NewGame();
        }
        if (!refueling)
            fuel -= usageOfFuel * Time.deltaTime;
        text.text = "Fuel: " + (int)fuel + "%";
    }

    public void AddFuel(float fuelToAdd)
    {
        fuel = Mathf.Min(fuel + fuelToAdd, 100);
    }
}

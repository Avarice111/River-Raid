using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesManager : MonoBehaviour {

    private int lifes;
    PlayerController thePlayerController;

    Text text;

    // Use this for initialization
    private void Awake()
    {
        text = GetComponent<Text>();
        thePlayerController = FindObjectOfType<PlayerController>();
    }

    void Start () {
        lifes = 3;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (lifes < 0)
            thePlayerController.NewGame();
        text.text = "";
        for (int i = 0; i < lifes; i++)
        {
            text.text += "♥ ";
        }

    }

    public void SubstractLife ()
    {
        lifes--;
    }

    public void ResetLifes()
    {
        lifes = 3;
    }
}

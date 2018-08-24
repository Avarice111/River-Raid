using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BridgeNumberManager : MonoBehaviour
{
    private int bridgeNumber;

    Text text;

    // Use this for initialization
    private void Awake()
    {
        text = GetComponent<Text>();
    }

    void Start()
    {
        bridgeNumber = 1;

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Bridge: " + bridgeNumber;

    }

    public void NextBridge()
    {
        bridgeNumber++;
    }
}

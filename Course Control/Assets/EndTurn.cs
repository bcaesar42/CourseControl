using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurn : MonoBehaviour
{
    private GameObject endTurnButton;
    void Start()
    {
        endTurnButton = GameObject.Find("EndTurnButton");
        Debug.Log(endTurnButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("End Turn");
    }

}

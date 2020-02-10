using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{

    public int crewPool;
    private GameObject crewButton;
    // Start is called before the first frame update
    void Start()
    {
        crewPool = 999;
        crewButton = GameObject.Find("CrewButton");
        crewButton.GetComponentInChildren<Text>().text = "" + crewPool;
    }

    void Update()
    {
        
    }

    public int getCrew()
    {
        return crewPool;
    }

    public void modifyCrew(int change)
    {
        crewPool += change;
        crewButton.GetComponentInChildren<Text>().text = "" + crewPool;
    }

}

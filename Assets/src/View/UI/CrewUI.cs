using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrewUI : MonoBehaviour
{
    public Text crewCounts;
    public List<GameObject> targets;
    private int unallocated;
    private int total;
    // Start is called before the first frame update
    void Start()
    {
        unallocated = 10;
        total = 10;
        crewCounts = GameObject.Find("Unallocated").GetComponent<Text>();
        crewCounts.text = "Unallocated Crew: " + unallocated;

        Debug.Log("");
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateCounts();
        crewCounts.text = "Unallocated Crew: " + unallocated;
    }

    private void UpdateCounts()
    {
        //throw new NotImplementedException();
    }
}

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
        //Replace with getting ship totals
        unallocated = 10;
        total = 10;

        crewCounts = GameObject.Find("Unallocated").GetComponent<Text>();
        crewCounts.text = "Unallocated: " + unallocated + "\nTotal: " + total;

        Debug.Log("");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCounts();
        crewCounts.text = "Unallocated: " + unallocated + "\nTotal: " + total;
    }

    private void UpdateCounts()
    {
        //throw new NotImplementedException();
    }
}

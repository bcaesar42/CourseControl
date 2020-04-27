using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrewUI : MonoBehaviour
{
    public TextMeshProUGUI crewCounts;
    public List<GameObject> targets;
    private int unallocated;
    private int total;
    // Start is called before the first frame update
    void Start()
    {
        unallocated = 10;
        total = 10;
        crewCounts.text = "Unallocated Crew: " + unallocated;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCounts();
    }

    private void UpdateCounts()
    {
        throw new NotImplementedException();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("THIS IS A TEST, IT IS STARTING");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("CLICKED ME!!!");
    }
}

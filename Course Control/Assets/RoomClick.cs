using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomClick : MonoBehaviour
{
    


    private GameObject button;
    private GameObject Ship;
    String roomName;
    Text bText;
    // Start is called before the first frame update
    void Start()
    {
        roomName = this.name;
        button = GameObject.Find(roomName + "Button"); //Note .Find is slow and should be avoided. Refactor this later
        Ship = this.gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        int num;

        if (Input.GetMouseButtonDown(0))
        {
            if (Ship.GetComponent<Ship>().getCrew() > 0)
            {
                bText = button.GetComponentInChildren<Text>();
                num = Int32.Parse(bText.text);

                bText.text = "" + (num + 1);
                Ship.GetComponent<Ship>().modifyCrew(-1);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Left Click");

            num = Int32.Parse(bText.text);

            if (num > 0)
            {
                bText = button.GetComponentInChildren<Text>();
                num = Int32.Parse(bText.text);

                bText.text = "" + (num - 1);
                Ship.GetComponent<Ship>().modifyCrew(+1);
            }
            
        }
    }
}

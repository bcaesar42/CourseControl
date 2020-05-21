﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    TurnManager rtm;
    Button endTurnButton;

    // Start is called before the first frame update
    void Start()
    {
        rtm = GameObject.Find("SceneManager").transform.GetComponent<TurnManager>();
        endTurnButton = endTurnButton.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        rtm?.newTurn();
    }
}
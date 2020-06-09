using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    SceneManager sm;
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Creating Button");

        sm = GameObject.Find("SceneManager").transform.GetComponent<SceneManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        Debug.Log("NEW ROUND ETB");
        sm.newTurn();
    }
}

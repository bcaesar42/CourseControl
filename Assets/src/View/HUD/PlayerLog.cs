using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerLog : MonoBehaviour
{
    /*
     *  Code taken from: https://answers.unity.com/questions/508268/i-want-to-create-an-in-game-log-which-will-print-a.html
     */


    private List<string> Eventlog = new List<string>();
    private string guiText = "";

    public int maxLines = 20;

    void OnGUI()
    {
        GUI.Label(new Rect(3 * (Screen.width / 5), 12 * Screen.height / 100, Screen.width / 3, Screen.height / 3), guiText, GUI.skin.textArea);
    }

    public void AddEvent(string eventString)
    {
        Eventlog.Add(eventString);

        /*
        if (Eventlog.Count >= maxLines)
            Eventlog.RemoveAt(0);
        */

        guiText = "";

        foreach (string logEvent in Eventlog)
        {
            guiText += logEvent;
            guiText += "\n";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyListener : MonoBehaviour
{
    public Text GameState;

    public Text Player2Name;

    private float lastPressed;

    private readonly float keyDelay = 0.5f;

    void OnGUI()
    {
        Debug.Log(Time.time + " , " + lastPressed);
        Event e = Event.current;
        // if (e.isKey) // not work for contorller
        // {
        if (Time.time - lastPressed > keyDelay)
        {
            if (Input.GetButton("SingleMode"))
            {
                lastPressed = Time.time;
                Debug.Log("Multiplayer key is held down");
                GameState.text = "Single Player";
                Player2Name.text = "Computer";
                GameManager.instance.StartNewGame(true);
            }
            if (Input.GetButton("Multiplayer"))
            {
                lastPressed = Time.time;
                Debug.Log("Multiplayer key is held down");
                GameState.text = "Multiple Players";
                Player2Name.text = "Player 2";
                GameManager.instance.StartNewGame(false);
            }
        }
        //}
    }
}
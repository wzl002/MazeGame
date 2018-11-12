using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField inputField;

    ConsoleManager console;

    void Awake()
    {
        console = GetComponent<ConsoleManager>();
        inputField.onEndEdit.AddListener(AcceptStringInput);
    }

    private void Start()
    {
        inputField.Select();
        inputField.ActivateInputField();
    }

    void AcceptStringInput(string userInput)
    {
        console.LogStringWithReturn(userInput);
        userInput = userInput.ToLower();
        
        char[] delimiterCharacters = { ' ' };
        string[] separatedInputWords = userInput.Split(delimiterCharacters);

        for (int i = 0; i < console.commands.Length; i++)
        {
            ConsoleCommand command = console.commands[i];
            if (command.keyWord == separatedInputWords[0])
            {
                command.RespondToInput(console, separatedInputWords);
            }
        }

        InputComplete();

    }

    void InputComplete()
    {
        console.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }

}
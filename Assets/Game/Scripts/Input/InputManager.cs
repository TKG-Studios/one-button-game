using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; set; }


  //Input Events
    public delegate void InputEventHandler(string action);
    public static event InputEventHandler onInputEvent;


    private void Awake()
    {
    
        Instance = this;
    }

    [Header("Keyboard Controls")]

    //Menus
    public KeyCode menuUp;
    public KeyCode menuDown;

    //In Game
    public KeyCode attack;


    public static void InputEvent(string action)
    {
        if (onInputEvent != null) onInputEvent(action);
    }

    private void KeyboardControls()
    {
        if (GameManager.Instance.currentState == GameManager.GameStates.Menu)
        {
            //Arrow Keys
            if (Input.GetKeyDown(menuUp)) onInputEvent("Up");
            if (Input.GetKeyDown(menuDown)) onInputEvent("Down");
        }

  
            //Attack Key
            if (Input.GetKeyDown(attack)) onInputEvent("Attack");
        

    }

    // Update is called once per frame
    void Update()
    {
        KeyboardControls(); //To Do, Updates for Controls
    }
}

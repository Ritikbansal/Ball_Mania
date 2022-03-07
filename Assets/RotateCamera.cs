using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour,IInputReceiver
{
    private InputManager inputManager;
    private bool rotate = false;
    void Start()
    {
        EnableInput();
        inputManager=InputManager.Instance;
    }
    public void EnableInput()
    {
        InputManager.InputEvent+=OnInputEvent;
    }
    public void DisableInput()
    {
        InputManager.InputEvent-=OnInputEvent;
    }
    public void OnInputEvent(InputActionType a)
    {
          switch(a)
          {
              case InputActionType.ROTATE : rotate=true;
              break;
              case InputActionType.STOP_ROTATE :rotate=false;
              break;
          }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

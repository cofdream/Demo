using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public CursorLockMode cursorLockMode;
    public bool cursorVisible;


    public UnityAction onMenu;
    public UnityAction onConfirm;
    public UnityAction onCancel;

  
    void Update()
    {
        //Cursor.lockState = cursorLockMode;
        //Cursor.visible = cursorVisible;
    }

    void OnMenu()
    {
        Debug.Log("Primary.");
    }
    void OnConfirm()
    {

    }
    void OnCancel()
    {

         
    }
}

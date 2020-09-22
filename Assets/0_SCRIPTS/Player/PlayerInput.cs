using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private bool isInputEnabled = true;

    [SerializeField] private PlayerCharacterController characterController;
    [SerializeField] private delegate void OnTouchDelegate();
    [SerializeField] private event OnTouchDelegate OnTouchEvent;

    private void Awake()
    {
        if (characterController == null)
            characterController = this.GetComponent<PlayerCharacterController>();
    }

    private void Update()
    {
        if (isInputEnabled )
        {
            if (Input.GetMouseButtonUp(0))
                characterController.PushUp();

            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                    characterController.PushUp();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                characterController.PushUp();
            }
        }
     
    }
}

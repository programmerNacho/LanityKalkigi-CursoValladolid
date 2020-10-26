using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInput : MonoBehaviour
{
    public struct ActionState
    {
        public bool pressed;
        public bool holded;
        public bool released;
    }

    private ActionState primaryActionState;
    private ActionState secondaryActionState;
    //private ActionState thirdActionState;
    private ActionState fourthActionState;


    private void Update()
    {
        primaryActionState.pressed = Input.GetMouseButtonDown(0);
        primaryActionState.holded = Input.GetMouseButton(0);
        primaryActionState.released = Input.GetMouseButtonUp(0);

        secondaryActionState.pressed = Input.GetMouseButtonDown(1);
        secondaryActionState.holded = Input.GetMouseButton(1);
        secondaryActionState.released = Input.GetMouseButtonUp(1);

        //thirdActionState.pressed = Input.GetMouseButtonDown(2);
        //thirdActionState.holded = Input.GetMouseButton(2);
        //thirdActionState.released = Input.GetMouseButtonUp(2);

        fourthActionState.pressed = Input.GetKeyDown(KeyCode.Space);

    }

    public ActionState GetPrimaryActionState()
    {
        return primaryActionState;
    }

    public ActionState GetSecondaryActionState()
    {
        return secondaryActionState;
    }

    //public ActionState GetThirdActionState()
    //{
    //    return thirdActionState;
    //}

    public ActionState GetFourthActionState()
    {
        return fourthActionState;
    }

    public Vector3 GetMouseScreenPosition()
    {
        return Input.mousePosition;
    }
}

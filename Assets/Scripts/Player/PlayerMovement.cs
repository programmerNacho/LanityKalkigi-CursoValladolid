using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float paintMovementSpeed;
    [SerializeField]
    private float runMovementSpeed;
    [SerializeField]
    private float distanceToStop;
    [SerializeField]
    private CharacterAnimation characterAnimation;

    private PlayerInput playerInput;

    private new Rigidbody rigidbody;

    private Camera mainCamera;
    private Plane raycastPlane;

    private Vector3 playerToMouse;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        rigidbody = GetComponent<Rigidbody>();

        mainCamera = Camera.main;
        raycastPlane = new Plane(Vector3.up, transform.position);
    }

    private void Update()
    {
        playerToMouse = CalculateVectorFromPlayerToMouse();
    }

    private Vector3 CalculateVectorFromPlayerToMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(playerInput.GetMouseScreenPosition());

        if(raycastPlane.Raycast(ray, out float enter))
        {
            Vector3 mouseWorldPosition = ray.GetPoint(enter);

            Vector3 directionPlayerToMouse = mouseWorldPosition - transform.position;

            return directionPlayerToMouse;
        }

        return Vector3.zero;
    }

    private void FixedUpdate()
    {
        PlayerInput.ActionState primaryActionState = playerInput.GetPrimaryActionState();
        PlayerInput.ActionState secondaryActionState = playerInput.GetSecondaryActionState();
        PlayerInput.ActionState fourthActionState = playerInput.GetFourthActionState();

        characterAnimation.SetMoving(false);
        characterAnimation.SetPainting(false);
        characterAnimation.SetAttack(false);


        if (playerToMouse.magnitude >= distanceToStop)
        {
            if (primaryActionState.holded)
            {
                rigidbody.velocity = playerToMouse.normalized * paintMovementSpeed;
                characterAnimation.SetPainting(true);
            }
            else if (secondaryActionState.holded)
            {
                rigidbody.velocity = playerToMouse.normalized * runMovementSpeed;
                characterAnimation.SetMoving(true);
            }
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }

        if (fourthActionState.pressed)
        {
            characterAnimation.SetAttack(true);
        }
        else
        {
            characterAnimation.SetAttack(false);
        }

        if (playerToMouse != Vector3.zero)
        {
            Vector3 lookDirection = playerToMouse;
            lookDirection.y = 0f;
            lookDirection.Normalize();

            transform.forward = lookDirection;
        }
    }
}

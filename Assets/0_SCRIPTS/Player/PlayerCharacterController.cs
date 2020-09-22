using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] private bool isKinematic;
    [SerializeField] public bool IsKinematic
    {
        set
        {
            isKinematic = value;
            rb.isKinematic = isKinematic;

            if (isKinematic)
                rb.position = new Vector2(rb.position.x, 0);
        }
        get
        {
            return isKinematic;
        }
    }


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float verticalPushForce;
    [SerializeField] private float maxVerticalVelocity = 10f;
    [SerializeField] private float maxVerticalRotationDeffiningVelocity = 10f;
    private Vector2 startingForward = Vector2.right;

    private void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        rb.isKinematic = this.isKinematic;

        maxVerticalVelocity = Mathf.Abs(maxVerticalVelocity);
    }

    public void PushUp()
    {
        Debug.Log("Pushing up");

        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * verticalPushForce);
    }

    private void Update()
    {
        RotateBasedOnSpeed();
    }

    private void FixedUpdate()
    {
        // clamp the max velocity
        if (rb.velocity.y > maxVerticalVelocity)
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVerticalVelocity);
    }

    private void RotateBasedOnSpeed ()
    {
        // get the current speed / max speed as the interpolation value between the scene forward and the object
        float interpolationValue = rb.velocity.y / maxVerticalRotationDeffiningVelocity;

        rb.SetRotation(90f * interpolationValue);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControllerOld : MonoBehaviour
{
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;

    private bool _isCollided = false;
    public event EventHandler<CollidedEventArgs> Collided;
    
    protected virtual void OnCollided(bool isCollided)
    {
        Collided?.Invoke(this, new CollidedEventArgs {IsCollided = isCollided});
    }

    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width / 2f;
        screenCenter.y = Screen.height / 2f;

        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        // Calculate the mouse drag distance relative to the center and the y-axis
        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;
        // Hard cap it to max of 1f
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxis("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime,
            mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        // Define directional speeds including acceleration to smooth the movement
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed,
            forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed,
            strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed,
            hoverAcceleration * Time.deltaTime);

        // Set new position if not collided
        if(!_isCollided) 
        {
            transform.position += transform.forward * (activeForwardSpeed * Time.deltaTime) // Front/Back Movement
                                  + transform.right * (activeStrafeSpeed * Time.deltaTime) // Left/Right Movement
                                  + transform.up * (activeHoverSpeed * Time.deltaTime); // Up/Down Movement
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Terrain") || collision.gameObject.CompareTag("Enemy"))
        {
            activeForwardSpeed = 0f;
            activeStrafeSpeed = 0f;
            activeHoverSpeed = 0f;

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;

            this._isCollided = true;
            OnCollided(_isCollided);
        }
    }
    
    public class CollidedEventArgs : EventArgs
    {
        public bool IsCollided { get; set; }
    }
}
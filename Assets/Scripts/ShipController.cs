using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed, activeRollSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;
    
    private float _forwardInput, _sidewaysInput, _hoverInput;
    private float _rollInput;
    private Vector2 _lookInput;

    public float lookRateSpeed = 90f;
    private Vector2 screenCenter, mouseDistance;

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

    void OnForward(InputValue value)
    {
        _forwardInput = value.Get<float>();
        Debug.Log("Forward Input: " + _forwardInput);
    }

    void OnSideways(InputValue value)
    {
        _sidewaysInput = value.Get<float>();
        Debug.Log("Sideways Input: " + _sidewaysInput);
    }

    void OnHover(InputValue value)
    {
        _hoverInput = value.Get<float>();
        Debug.Log("Hover Input: " + _hoverInput);
    }

    void OnRoll(InputValue value)
    {
        _rollInput = value.Get<float>();
        Debug.Log("Roll Input: " + _rollInput);
    }

    void OnLook(InputValue value)
    {
        _lookInput = value.Get<Vector2>();
        Debug.Log("Look Input: x=" + _lookInput.x + ", y=" + _lookInput.y);
    }
    

    void FixedUpdate()
    {
        // Calculate the mouse drag distance relative to the center and the y-axis
        mouseDistance.x = (_lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (_lookInput.y - screenCenter.y) / screenCenter.y;
        // Hard cap it to max of 1f
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        activeRollSpeed = Mathf.Lerp(activeRollSpeed, _rollInput, rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime,
            mouseDistance.x * lookRateSpeed * Time.deltaTime, activeRollSpeed * rollSpeed * Time.deltaTime, Space.Self);

        // Define directional speeds including acceleration to smooth the movement
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, _forwardInput * forwardSpeed,
            forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, _sidewaysInput * strafeSpeed,
            strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, _hoverInput * hoverSpeed,
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
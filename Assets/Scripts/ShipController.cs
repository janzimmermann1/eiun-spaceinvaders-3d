using System;
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
    private bool _isMenuOpen = false;
    public event EventHandler<CollidedEventArgs> Collided;
    public event EventHandler<MenuTriggeredArgs> MenuTriggered;
    
    protected virtual void OnCollided(bool isCollided)
    {
        Collided?.Invoke(this, new CollidedEventArgs {IsCollided = isCollided});
    }

    public virtual void OnMenuTriggered(bool isOpen)
    {
        MenuTriggered?.Invoke(this, new MenuTriggeredArgs() {IsOpen = isOpen});
    }
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OnForward(InputValue value)
    {
        _forwardInput = value.Get<float>();
    }

    void OnSideways(InputValue value)
    {
        _sidewaysInput = value.Get<float>();
    }

    void OnHover(InputValue value)
    {
        _hoverInput = value.Get<float>();
    }

    void OnRoll(InputValue value)
    {
        _rollInput = value.Get<float>();
    }

    void OnLook(InputValue value)
    {
        _lookInput = value.Get<Vector2>();
    }

    void OnMenu(InputValue value)
    {
        _isMenuOpen = !_isMenuOpen;
        OnMenuTriggered(_isMenuOpen);
    }

    void FixedUpdate()
    {
        // Find ScreenCenter
        screenCenter.x = Screen.width / 2f;
        screenCenter.y = Screen.height / 2f;
        
        // Calculate the mouse drag distance relative to the center and the y-axis
        mouseDistance.x = (_lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (_lookInput.y - screenCenter.y) / screenCenter.y;
        // Hard cap it to max of 1f
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        activeRollSpeed = Mathf.Lerp(activeRollSpeed, _rollInput, rollAcceleration * Time.fixedDeltaTime);

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.fixedDeltaTime,
            mouseDistance.x * lookRateSpeed * Time.fixedDeltaTime, activeRollSpeed * rollSpeed * Time.fixedDeltaTime, Space.Self);

        // Define directional speeds including acceleration to smooth the movement
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, _forwardInput * forwardSpeed,
            forwardAcceleration * Time.fixedDeltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, _sidewaysInput * strafeSpeed,
            strafeAcceleration * Time.fixedDeltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, _hoverInput * hoverSpeed,
            hoverAcceleration * Time.fixedDeltaTime);

        // Set new position if not collided
        if(!_isCollided) 
        {
            transform.position += transform.forward * (activeForwardSpeed * Time.fixedDeltaTime) // Front/Back Movement
                                  + transform.right * (activeStrafeSpeed * Time.fixedDeltaTime) // Left/Right Movement
                                  + transform.up * (activeHoverSpeed * Time.fixedDeltaTime); // Up/Down Movement
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

            _isCollided = true;
            OnCollided(_isCollided);
        }
    }
    
    public class CollidedEventArgs : EventArgs
    {
        public bool IsCollided { get; set; }
    }
    
    public class MenuTriggeredArgs : EventArgs
    {
        public bool IsOpen { get; set; }
    }
}
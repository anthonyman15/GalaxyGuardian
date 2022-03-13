using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{    
    public MovementJoystick movementJoystick;
    public Joystick joystick;
    public float playerSpeed;
    public float rotationSpeed;
    public GameObject Object;
    public float maxHealth = 100f;
    public float currentHealth;
    public HealthBar healthBar;

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth,maxHealth);
    }

    void FixedUpdate()
    {
        Vector2 movementDirection = new Vector2(joystick.Horizontal, joystick.Vertical);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * playerSpeed * inputMagnitude * Time.deltaTime, Space.World);
        if (movementJoystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        if(movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        
    }

    void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }*/
    }

    public void UpdateHealth(float mod)
    {
        currentHealth = Mathf.Clamp(currentHealth + mod, 0, maxHealth);
    }

    // Damage taken from enemy
    void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        healthBar.SetHealth(currentHealth);
    }
}

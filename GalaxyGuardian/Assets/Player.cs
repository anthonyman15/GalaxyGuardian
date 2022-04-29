using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{    
<<<<<<< HEAD
	public MovementJoystick movementJoystick;
	public Joystick joystick;
	public float basePlayerSpeed = 5f;
	public float playerSpeed;
	public float rotationSpeed;
	public GameObject Object;
	
	public float baseMaxHealth = 100f;
	public float maxHealth;
	public float currentHealth;
	public HealthBar healthBar;
	private Rigidbody2D rb;
	
	public static event Action OnPlayerDeath;
	
	/* Upgrade variables */
	
	public int upgradeHealthLevel = 0;
	public float upgradeHealthAmount = 10f; 
	public int upgradeSpeedLevel = 0;
	public float upgradeSpeedAmount = 0.33f;
	public int upgradeDamageLevel = 0;
	public float upgradeDamageAmount = 2f;
	
	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		
		// Health
		upgradeHealthLevel = 0;
		maxHealth = baseMaxHealth;
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(currentHealth,maxHealth);
		
		// Speed
		upgradeSpeedLevel = 0;
		playerSpeed = basePlayerSpeed;
		
		// Damage
		upgradeDamageLevel = 0;
		
		
		//Enable player movement when retry button pressed in game
		EnablePlayerMovement();
	}

	// Upgrade the player health by 1
	void UpgradeHealth()
	{
		upgradeHealthLevel++;
		maxHealth = ( baseMaxHealth + (upgradeHealthLevel * upgradeHealthAmount) );
	}
	
	// Upgrade the player speed
	void UpgradeSpeed()
	{
		upgradeSpeedLevel++;
		playerSpeed = ( basePlayerSpeed + (upgradeSpeedLevel * upgradeSpeedAmount) );
	}
	
	// 
	void UpgradeDamage()
	{
		upgradeDamageLevel++;
		
	}
=======
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
>>>>>>> parent of f05ae2d (gmaeover, game menu list done/ fixed)

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

<<<<<<< HEAD
	private void OnEnable()
	{
		Player.OnPlayerDeath += DisablePlayerMovement;
	}

	private void OnDisable()
	{
		Player.OnPlayerDeath -= DisablePlayerMovement;
	}
	public void UpdateHealth(float mod)
	{
		currentHealth = Mathf.Clamp(currentHealth + mod, 0, maxHealth);
		healthBar.SetHealth(currentHealth);
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Player Died");
			OnPlayerDeath?.Invoke();
			DisablePlayerMovement();
		}
	}

	private void DisablePlayerMovement()
	{
		rb.bodyType = RigidbodyType2D.Static;
	}

	private void EnablePlayerMovement()
	{
		rb.bodyType = RigidbodyType2D.Dynamic;
	}
=======
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
>>>>>>> parent of f05ae2d (gmaeover, game menu list done/ fixed)
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{    
    public float baseHealth;    
    public MovementJoystick movementJoystick;
    public Joystick joystick;
    public float playerSpeed;
    public float rotationSpeed;
    public GameObject Object;
    public float maxHealth = 100f;
    public float currentHealth;
    public HealthBar healthBar;
    private Rigidbody2D rb;

    public static event Action OnPlayerDeath;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth,maxHealth);
        EnablePlayerMovement();
    }
    
    //Upgrade Health
    public void updateHealth(){
        int health = ShopUI.upgradePurchase["Health"];
        ShopUI.upgradePurchase["Health"] = health == 10? health:health+1;
        //Check cap level
        if(Score.scoreValue > 0 && health <= 10){
            maxHealth += 5;
            // currentHealth = maxHealth;
            Score.scoreValue -= 10;
            healthBar.SetMaxHealth(currentHealth,maxHealth);
            Debug.Log("Health Upgrade Purchased");
        }
    }
    
    //Upgrade Speed
    public void updateSpeed(){
        int speed = ShopUI.upgradePurchase["Speed"];
        ShopUI.upgradePurchase["Speed"] = speed == 5? speed:speed+1;
        if(Score.scoreValue > 0 && speed <= 5){
            playerSpeed += 1;
            //Check earn score
            Score.scoreValue -= 10;
            Debug.Log("Speed Purchased");
        }
    }
    
    //Upgrade Damage
    public void updateDamage(){
        int damage = ShopUI.upgradePurchase["Damage"];
        ShopUI.upgradePurchase["Damage"] = damage == 10? damage:damage+1;
        if(Score.scoreValue > 0 && damage <= 10){
            Score.scoreValue -= 10;
            Bullet.damage += 5;
            Debug.Log("Damage Purchased");
        }
    }
    
    //Purchase Health
    public void purchaseHealth(){
        int health = ShopUI.upgradePurchase["Purchase Health"];
        ShopUI.upgradePurchase["Purchase Health"] = health == 0? health:health++;
        if(Score.scoreValue > 0 && currentHealth < maxHealth){
            Score.scoreValue -= 10;
            currentHealth += 5;
            healthBar.SetMaxHealth(currentHealth,maxHealth);
            Debug.Log("Health Purchased");
        }
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
}

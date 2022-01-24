using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Joystick joystick;
    protected Joybutton joybutton;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.velocity = new Vector3(joystick.Horizontal * 100f, rigidbody.velocity.y, joystick.Vertical * 100f);
    }

}

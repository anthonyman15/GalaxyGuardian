using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_shoot : MonoBehaviour
{
    public Transform player;
    public float speed = 15f;

    public Transform circle;
    public Transform outerCircle;
    public GameObject bulletPrefab;

    private Vector2 startingPoint;
    private int leftTouch = 99;
    // Update is called once per frame
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            Vector2 touchpos = getTouchPosition(t.position) * -1;
            if(t.phase == TouchPhase.Began)
            {
                if(t.position.x > Screen.width / 2)
                {
                    shootBullet();
                }
                else
                {
                    leftTouch = t.fingerId;
                    startingPoint = touchpos;
                }
            }
            
            else if(t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
            {
                Vector2 offset = touchpos - startingPoint;
                Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

                moveCharacter(direction);

                circle.transform.position = new Vector2(outerCircle.transform.position.x + direction.x, outerCircle.transform.position.y + direction.y);
            }
            
            else if(t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
            {
                leftTouch = 99;
            }
            ++i;
        }
    }

    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }

    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
    

    void shootBullet()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = player.transform.position;
    }
}

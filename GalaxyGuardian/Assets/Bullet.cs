using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
<<<<<<< HEAD
	public static int damage = 10;
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
		{
			/*Destroy(coll.gameObject);*/
			Enemy enemy = coll.GetComponent<Enemy>();
			
			enemy.enemyHp = Mathf.Max(0, enemy.enemyHp - damage);
			
			if(enemy.enemyHp == 0)
			{
				Destroy(coll.gameObject);
				Score.scoreValue += 10;
			}
		}
		Destroy(gameObject);
	}
=======
    public int damage = 10;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            /*Destroy(coll.gameObject);*/
            Enemy enemy = coll.GetComponent<Enemy>();
            enemy.enemyHp = Mathf.Max(0, enemy.enemyHp - damage);
            if(enemy.enemyHp == 0)
            {
                Destroy(coll.gameObject);
            }
        }
        Destroy(gameObject);
    }
>>>>>>> parent of f05ae2d (gmaeover, game menu list done/ fixed)
}
	
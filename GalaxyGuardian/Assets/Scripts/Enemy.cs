using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHp = 100f;
    public Transform player;
/*    public GameObject prefab;*/
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
/*    public List<GameObject> wps;
    private List<GameObject> enemies;*/

    // Start is called before the first frame update

    [SerializeField] public float attackDamage = 10f;
    [SerializeField] public float attackSpeed = 1f;
    public float canAttack;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.gameObject.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Player player = coll.GetComponent<Player>();
            player.UpdateHealth(-attackDamage);
            
            Debug.Log("Hit Player");
        }
    }
}

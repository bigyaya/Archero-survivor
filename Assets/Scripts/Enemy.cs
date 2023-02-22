using System.Collections;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float destroyDelay = 1f;
    public Color hitColor = Color.red;

    private Rigidbody2D rb;
    private bool isHit = false;
    public Transform target;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isHit)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // Change la couleur de l'ennemi en rouge
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.color = hitColor;

            // Arrête l'ennemi
            rb.velocity = Vector2.zero;

            // Détruit l'ennemi après un délai
            Destroy(gameObject, destroyDelay);

            // Indique que l'ennemi a été touché
            isHit = true;
        }
    }
}


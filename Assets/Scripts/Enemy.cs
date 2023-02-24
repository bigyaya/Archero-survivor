using System.Collections;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public GameManagerScript gameManager;

    public float speed = 5f;
    public float destroyDelay = 1f;
    public Color hitColor = Color.red;

    private Rigidbody2D rb;
    private bool isHit = false;
    public Transform target;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManagerScript>();
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

    //private IEnumerator Flash()
    //{
    //    Debug.Log("Starting flash effect");
    //    SpriteRenderer sprite = GetComponent<SpriteRenderer>();
    //    Color originalColor = sprite.color;

    //    while (isHit)
    //    {
    //        sprite.color = hitColor;
    //        yield return new WaitForSeconds(0.1f);
    //        sprite.color = originalColor;
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //    Debug.Log("Stopping flash effect");
    //}

   


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

            // Appelle la fonction EnemyKilled du GameManagerScript
            gameManager.EnemyKilled();



            // Appeler l'événement CreateBonusBullet
            //GameObject.Find("RewardsManager").GetComponent<RewardsEffects>().CreateBonusBullet.Invoke();



            // Indique que l'ennemi a été touché
            isHit = true;

            // Lance l'effet de clignotement
            //StartCoroutine(Flash());
        }
    }
}


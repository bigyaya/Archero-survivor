using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameManagerScript gameManager;
    private bool isDead;


    public GameObject projectilePrefab; // Pr�fabriqu� de projectile
    public float projectileSpeed = 10f; // Vitesse du projectile
    public float fireRate = 2f; // Temps en secondes entre chaque tir automatique
    private float nextFireTime = 0f; // Temps restant jusqu'au prochain tir

    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    private Vector2 direction;


    private void Start()
    {
        GameObject.Find("RewardManager").GetComponent<RewardsEffects>().CreateBonusBullet.AddListener(OnCreateBonusBullet);
        GameObject.Find("RewardManager").GetComponent<RewardsEffects>().DoubleAttack.AddListener(OnDoubleAttack);
    }

    // Mettre � jour la logique de tir � chaque frame
    void Update()
    {
        

        // V�rifier si le temps entre chaque tir automatique est �coul�
        if (Time.time > nextFireTime)
        {
            // Tirer le projectile dans les quatre directions haut, bas, gauche et droite
            Shoot(Vector2.up);
            Shoot(Vector2.down);
            Shoot(Vector2.left); 
            Shoot(Vector2.right);

            // Mettre � jour le temps restant jusqu'au prochain tir
            nextFireTime = Time.time + 1 / fireRate;
        }

        //// Appeler la m�thode ShouldDoubleAttack pour d�terminer si le joueur peut attaquer une seconde fois
        //if (GameObject.Find("RewardManager").GetComponent<RewardsEffects>().ShouldDoubleAttack())
        //{
        //    // Instancier une seconde balle et lancer
        //    GameObject bullet2 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //    bullet2.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        //    // Appeler l'�v�nement DoubleAttack
        //    GameObject.Find("RewardManager").GetComponent<RewardsEffects>().DoubleAttack.Invoke();
        //}

        if (isDead == true)
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        
    }

    // Tirer un projectile dans une direction donn�e
    void Shoot(Vector2 direction)
    {
        // Instancier le pr�fabriqu� de projectile � la position du joueur
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        

        // D�finir la vitesse et la direction du projectile
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = direction * projectileSpeed;
    }

    //void OnStateExit()
    //{
    //    // Do shooting animation
    //    // ...

    //    // Trigger DoubleAttack reward
    //    GameObject.Find("RewardsManager").GetComponent<RewardsEffects>().doubleAttackEvent.Invoke();
    //}


    private void OnCreateBonusBullet()
    {
        Debug.Log("CreateBonusBullet invoked");
    }

    private void OnDoubleAttack()
    {
        Debug.Log("DoubleAttack invoked");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

            gameManager.enemiesKilled++;
            if (gameManager.enemiesKilled == 10)
            {
                // Afficher le panel de r�compense
                gameManager.ShowRewardScreen();
            }


            isDead = true;           
            //gameManager.GameOver();

            Debug.Log("Partie perdue !");
            // TODO: G�rer la perte de la partie
        }
    }
}

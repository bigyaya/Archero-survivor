using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Préfabriqué de projectile
    public float projectileSpeed = 10f; // Vitesse du projectile
    public float fireRate = 2f; // Temps en secondes entre chaque tir automatique
    private float nextFireTime = 0f; // Temps restant jusqu'au prochain tir



    // Mettre à jour la logique de tir à chaque frame
    void Update()
    {
        // Vérifier si le temps entre chaque tir automatique est écoulé
        if (Time.time > nextFireTime)
        {
            // Tirer le projectile dans les quatre directions haut, bas, gauche et droite
            Shoot(Vector2.up);
            Shoot(Vector2.down);
            Shoot(Vector2.left);
            Shoot(Vector2.right);

            // Mettre à jour le temps restant jusqu'au prochain tir
            nextFireTime = Time.time + 1 / fireRate;
        }
    }

    private void FixedUpdate()
    {
        
    }

    // Tirer un projectile dans une direction donnée
    void Shoot(Vector2 direction)
    {
        // Instancier le préfabriqué de projectile à la position du joueur
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        

        // Définir la vitesse et la direction du projectile
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = direction * projectileSpeed;
    }
}

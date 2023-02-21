using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement du joueur
    private Rigidbody2D rb;

    // Initialiser le rigidbody du joueur
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Obtenir les entrées de l'utilisateur sur les axes horizontal et vertical
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculer la direction de déplacement du joueur en combinant les axes horizontal et vertical
        Vector2 direction = new Vector2(horizontalInput, verticalInput);

        // Normaliser la direction pour que le joueur se déplace à la même vitesse dans toutes les directions
        direction.Normalize();

        // Déplacer le joueur dans la direction calculée avec la vitesse définie
        rb.velocity = direction * speed;
    }

    // Mettre à jour la position du joueur à chaque frame
    void FixedUpdate()
    {
               
        // Empêcher le joueur de glisser en diagonale plus rapidement que dans une seule direction
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
}

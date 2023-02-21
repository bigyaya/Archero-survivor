using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Vitesse de d�placement du joueur
    private Rigidbody2D rb;

    // Initialiser le rigidbody du joueur
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Obtenir les entr�es de l'utilisateur sur les axes horizontal et vertical
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculer la direction de d�placement du joueur en combinant les axes horizontal et vertical
        Vector2 direction = new Vector2(horizontalInput, verticalInput);

        // Normaliser la direction pour que le joueur se d�place � la m�me vitesse dans toutes les directions
        direction.Normalize();

        // D�placer le joueur dans la direction calcul�e avec la vitesse d�finie
        rb.velocity = direction * speed;
    }

    // Mettre � jour la position du joueur � chaque frame
    void FixedUpdate()
    {
               
        // Emp�cher le joueur de glisser en diagonale plus rapidement que dans une seule direction
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Vitesse de déplacement de l'ennemi
    public float speed = 5f;

    // Position du joueur
    public Transform target;

    // Méthode appelée au démarrage du script
    private void Start()
    {
        // On recherche le GameObject ayant le tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Méthode appelée à chaque frame
    private void Update()
    {
        // On utilise la méthode MoveTowards pour faire avancer l'ennemi vers le joueur
        // La méthode renvoie un Vector2 qui représente la position de l'ennemi après déplacement
        // On utilise la vitesse (speed) et le temps écoulé depuis la dernière frame (Time.deltaTime) pour déterminer la distance à parcourir
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Vitesse de d�placement de l'ennemi
    public float speed = 5f;

    // Position du joueur
    public Transform target;

    // M�thode appel�e au d�marrage du script
    private void Start()
    {
        // On recherche le GameObject ayant le tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // M�thode appel�e � chaque frame
    private void Update()
    {
        // On utilise la m�thode MoveTowards pour faire avancer l'ennemi vers le joueur
        // La m�thode renvoie un Vector2 qui repr�sente la position de l'ennemi apr�s d�placement
        // On utilise la vitesse (speed) et le temps �coul� depuis la derni�re frame (Time.deltaTime) pour d�terminer la distance � parcourir
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}

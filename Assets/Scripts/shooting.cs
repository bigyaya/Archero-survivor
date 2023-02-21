using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : StateMachineBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float fireRate = 2f; // Temps en secondes entre chaque tir automatique
    private float nextFireTime = 0f; // Temps restant jusqu'au prochain tir

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
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

        void Shoot(Vector2 direction)
        {
            // Instancier le préfabriqué de projectile à la position du joueur
            GameObject projectile = Instantiate(projectilePrefab, animator.gameObject.transform.position, Quaternion.identity); 



            // Définir la vitesse et la direction du projectile
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.velocity = direction * projectileSpeed;


        }

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

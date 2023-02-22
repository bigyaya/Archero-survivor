using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Le prefab de l'ennemi
    public float spawnDelay = 1f;   // Le temps entre chaque g�n�ration d'ennemi
    public float spawnChance = 0.5f;  // La probabilit� qu'un ennemi soit g�n�r� � chaque mise � jour
    public float enemyCount = 1f;   // Le nombre d'ennemis � g�n�rer � chaque mise � jour
    public AnimationCurve enemyCurve;  // La courbe d'augmentation du nombre d'ennemis au fil du temps

    private Camera mainCamera;  // La cam�ra principale
    private float cameraHeight;  // La hauteur de la cam�ra
    private float cameraWidth;   // La largeur de la cam�ra
    private float speed;  // La vitesse des ennemis

    private void Start()
    {
        // R�cup�re la cam�ra principale et calcule sa hauteur et sa largeur
        mainCamera = Camera.main;
        cameraHeight = 2f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;

        // Lance la coroutine pour g�n�rer les ennemis en boucle
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // Calcule le nombre d'ennemis � g�n�rer � cette mise � jour en fonction de la courbe d'augmentation
            int count = Mathf.RoundToInt(enemyCurve.Evaluate(Time.timeSinceLevelLoad) * enemyCount);

            // G�n�re chaque ennemi dans une boucle
            for (int i = 0; i < count; i++)
            {
                // V�rifie si l'ennemi est g�n�r� en fonction de la probabilit� d�finie
                if (Random.value < spawnChance)
                {
                    SpawnOneEnemy();
                }
            }

            // Attend le temps d�fini entre chaque g�n�ration d'ennemi
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnOneEnemy()
    {
        Vector3 spawnPosition = Vector3.zero;
        // G�n�re un ennemi � un bord de l'�cran al�atoire
        float side = Random.Range(0, 4);
        switch (side)
        {
            case 0:  // Bord sup�rieur
                spawnPosition = new Vector3(Random.Range(-cameraWidth / 2f, cameraWidth / 2f), cameraHeight / 2f, 0f);
                break;
            case 1:  // Bord inf�rieur
                spawnPosition = new Vector3(Random.Range(-cameraWidth / 2f, cameraWidth / 2f), -cameraHeight / 2f, 0f);
                break;
            case 2:  // Bord droit
                spawnPosition = new Vector3(cameraWidth / 2f, Random.Range(-cameraHeight / 2f, cameraHeight / 2f), 0f);
                break;
            case 3:  // Bord gauche
                spawnPosition = new Vector3(-cameraWidth / 2f, Random.Range(-cameraHeight / 2f, cameraHeight / 2f), 0f);
                break;
        }
        // Instancie un ennemi � la position calcul�e et avec une vitesse al�atoire
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        enemyScript.target = GameObject.FindGameObjectWithTag("Player").transform;

        //enemyScript.speed = Random.Range(speed - 2f, speed + 2f);
    }
}


using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Le prefab de l'ennemi
    public float spawnDelay = 1f;   // Le temps entre chaque génération d'ennemi
    public float spawnChance = 0.5f;  // La probabilité qu'un ennemi soit généré à chaque mise à jour
    public float enemyCount = 1f;   // Le nombre d'ennemis à générer à chaque mise à jour
    public AnimationCurve enemyCurve;  // La courbe d'augmentation du nombre d'ennemis au fil du temps

    private Camera mainCamera;  // La caméra principale
    private float cameraHeight;  // La hauteur de la caméra
    private float cameraWidth;   // La largeur de la caméra
    private float speed;  // La vitesse des ennemis

    private void Start()
    {
        // Récupère la caméra principale et calcule sa hauteur et sa largeur
        mainCamera = Camera.main;
        cameraHeight = 2f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;

        // Lance la coroutine pour générer les ennemis en boucle
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // Calcule le nombre d'ennemis à générer à cette mise à jour en fonction de la courbe d'augmentation
            int count = Mathf.RoundToInt(enemyCurve.Evaluate(Time.timeSinceLevelLoad) * enemyCount);

            // Génère chaque ennemi dans une boucle
            for (int i = 0; i < count; i++)
            {
                // Vérifie si l'ennemi est généré en fonction de la probabilité définie
                if (Random.value < spawnChance)
                {
                    SpawnOneEnemy();
                }
            }

            // Attend le temps défini entre chaque génération d'ennemi
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnOneEnemy()
    {
        Vector3 spawnPosition = Vector3.zero;
        // Génère un ennemi à un bord de l'écran aléatoire
        float side = Random.Range(0, 4);
        switch (side)
        {
            case 0:  // Bord supérieur
                spawnPosition = new Vector3(Random.Range(-cameraWidth / 2f, cameraWidth / 2f), cameraHeight / 2f, 0f);
                break;
            case 1:  // Bord inférieur
                spawnPosition = new Vector3(Random.Range(-cameraWidth / 2f, cameraWidth / 2f), -cameraHeight / 2f, 0f);
                break;
            case 2:  // Bord droit
                spawnPosition = new Vector3(cameraWidth / 2f, Random.Range(-cameraHeight / 2f, cameraHeight / 2f), 0f);
                break;
            case 3:  // Bord gauche
                spawnPosition = new Vector3(-cameraWidth / 2f, Random.Range(-cameraHeight / 2f, cameraHeight / 2f), 0f);
                break;
        }
        // Instancie un ennemi à la position calculée et avec une vitesse aléatoire
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        enemyScript.target = GameObject.FindGameObjectWithTag("Player").transform;

        //enemyScript.speed = Random.Range(speed - 2f, speed + 2f);
    }
}


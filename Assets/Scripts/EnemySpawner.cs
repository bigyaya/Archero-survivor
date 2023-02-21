using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay = 1f;
    public float spawnChance = 0.5f;
    public float enemyCount = 1f;
    public AnimationCurve enemyCurve;

    private Camera mainCamera;
    private float cameraHeight;
    private float cameraWidth;
    private float speed;

    private void Start()
    {
        mainCamera = Camera.main;
        cameraHeight = 2f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int count = Mathf.RoundToInt(enemyCurve.Evaluate(Time.timeSinceLevelLoad) * enemyCount);
            for (int i = 0; i < count; i++)
            {
                if (Random.value < spawnChance)
                {
                    SpawnOneEnemy();
                }
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnOneEnemy()
    {
        Vector3 spawnPosition = Vector3.zero;
        float side = Random.Range(0, 4);
        switch (side)
        {
            case 0:
                spawnPosition = new Vector3(Random.Range(-cameraWidth / 2f, cameraWidth / 2f), cameraHeight / 2f, 0f);
                break;
            case 1:
                spawnPosition = new Vector3(Random.Range(-cameraWidth / 2f, cameraWidth / 2f), -cameraHeight / 2f, 0f);
                break;
            case 2:
                spawnPosition = new Vector3(cameraWidth / 2f, Random.Range(-cameraHeight / 2f, cameraHeight / 2f), 0f);
                break;
            case 3:
                spawnPosition = new Vector3(-cameraWidth / 2f, Random.Range(-cameraHeight / 2f, cameraHeight / 2f), 0f);
                break;
        }
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().speed = Random.Range(speed - 2f, speed + 2f);
    }
}

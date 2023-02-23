using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public int enemiesKilled = 0;
    public int enemiesPerPause = 10; // Le nombre d'ennemis nécessaires pour déclencher la pause

    public GameObject gameOverUI;
    public GameObject rewardScreenUI;

    // Start is called before the first frame update
    void Start()
    {
        enemiesKilled = 0;
        rewardScreenUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Appelé chaque fois qu'un ennemi est tué
    public void EnemyKilled()
    {
        enemiesKilled++;
        if (enemiesKilled % enemiesPerPause == 0)
        {
            PauseGame();
        }
    }

    // Met le jeu en pause et affiche l'interface avec deux choix
    void PauseGame()
    {
        Time.timeScale = 0f; // Met le temps du jeu à zéro pour le mettre en pause
        rewardScreenUI.SetActive(true);
    }

    // Fonction appelée lorsque le joueur choisit une récompense
    public void RewardChosen(int rewardIndex)
    {
        // rewardIndex peut être utilisé pour déterminer quelle récompense a été choisie
        rewardScreenUI.SetActive(false);
        Time.timeScale = 1f; // Reprend le jeu en remettant le temps du jeu à sa valeur normale
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // Met le temps du jeu à zéro pour le mettre en pause
        gameOverUI.SetActive(true);

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowRewardScreen()
    {
        rewardScreenUI.SetActive(true);
    }
}

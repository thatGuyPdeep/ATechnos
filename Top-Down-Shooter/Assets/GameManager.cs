using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    bool gameOver = false;
    bool levelComplete = true;

    public GameObject gameOverMenu;
    public GameObject levelCompleteUI;

    public float restartDelay = 1f;

    private void Update()
    {
        if (ScoreScript.scoreValue >= 20)
        {
            LevelComplete();
        }
    }
    void LevelComplete()
    {
        if (levelComplete)
        {
            levelComplete = false;
            Debug.Log("Level Complete");
            levelCompleteUI.SetActive(true);
        }
        
    }

    public void EndGame()
    {
        if(gameOver == false)
        {
            gameOver = true;
            Debug.Log("Game Over");
            Time.timeScale = 0f;
            gameOverMenu.SetActive(true);
        }
    }
}

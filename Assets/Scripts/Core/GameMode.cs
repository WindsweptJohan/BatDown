using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public int amountOfBlocksLeft;
    public int playerLives = 3;

    private int currentLives;

    private bool isGameOver;

    public BallMovement ball;

    private void Awake()
    {
        currentLives = playerLives;
    }

    public void IncrementBlockAmount()
    {
        amountOfBlocksLeft++;
    }

    public void SetBlockDestroyed()
    {
        //Handles counter for how many blocks are left in the scene when a block is destroyed
        amountOfBlocksLeft--;
        Debug.Log("Current amount of blocks left is " + amountOfBlocksLeft);

        //No blocks left
        if (amountOfBlocksLeft <= 0)
            SetWinCondition();
    }

    private void SetWinCondition()
    {
        Debug.Log("All blocks destroyed");
        //Reloads scene when win condition is met
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetBallOutOfBounds()
    {
        currentLives--;

        if (currentLives > 0)
        {
            ball.ResetBall();
            return;
        }
        
        //No life left
        SetGameOver();
    }

    private void SetGameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

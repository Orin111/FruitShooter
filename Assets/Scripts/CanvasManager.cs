using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public Canvas startCanvas, gameCanvas, gameOverCanvas;
    public GameObject shooter;
    public Game game;
    public int highScore = 0;
    public string isHighest = "";
    public FruitShooter shooterScript;

    // Reference to TextMeshPro components
    public TMP_Text TextScore;
    public TMP_Text TextHighScore;

    void Start()
    {
        startCanvas.gameObject.SetActive(true);
        gameCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
        // shooter.gameObject.SetActive(false);

        // Assign the Game reference
        game = Game.instance;
    }

    public void playGame()
    {
        isHighest = "";
        startCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);
        // shooter.gameObject.SetActive(true);
        shooterScript.gameMode = true;
    }

    public void gameOver()
    {
        Debug.Log("Game Over");
        startCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
        // shooter.gameObject.SetActive(false);
        shooterScript.gameMode = false;
        UpdateTextValues();
    }

    public void playAgain()
    {
        playGame();
        game.playAgain();
    }

    void UpdateTextValues()
    {
        Debug.Log(game.shotsCount);
        int score = (game.shotsCount - game.survival) * 100;

        if (score > highScore)
        {
            isHighest = "High Score!";
            highScore = score;
        }

        // Update TextMeshPro text values if components are not null
        if (TextScore != null)
        {
            TextScore.text = "Your Score: " + score + " " + isHighest;
        }

        if (TextHighScore != null)
        {
            TextHighScore.text = "Highest Score: " + highScore;
        }
    }
}

using UnityEngine;
using TMPro; 

public class Game : MonoBehaviour
{
    public static Game instance;
    public CanvasManager canvasM; // Reference to CanvasManager

    public int survival = 0, shotsCount = 0;

    // Reference to TextMeshPro components
    public TMP_Text TextShoots;
    public TMP_Text TextSurvival;

    private void Awake()
    {
        // Set the instance when the script is awakened
        instance = this;
    }

    void Start()
    {
        // Assuming you've manually assigned TextMeshPro components in the Unity Editor
        // If not, drag and drop them from the Unity Editor to the corresponding fields
        TextShoots = GameObject.Find("TextShoots").GetComponent<TMP_Text>();
        TextSurvival = GameObject.Find("TextSurvival").GetComponent<TMP_Text>();

        // Update the initial text values
        UpdateTextValues();

        // Assign the CanvasManager reference
        canvasM = GameObject.Find("CanvasManagerObject").GetComponent<CanvasManager>();
    }

    public void inc_survival()
    {
        survival++;
        if (survival == 5)
        {
            canvasM.gameOver();
            Debug.Log("5 fruit were missed");
        }

        // Update the TextMeshPro values when survival changes
        UpdateTextValues();
    }

    void UpdateTextValues()
    {
        // Update TextMeshPro text values
        if (TextShoots != null)
        {
            TextShoots.text = "Shots: " + shotsCount;
        }

        if (TextSurvival != null)
        {
            TextSurvival.text = "Survival: " + survival;
        }
    }

    public void playAgain()
    {
        survival = 0;
        shotsCount = 0;
        UpdateTextValues();
    }
}
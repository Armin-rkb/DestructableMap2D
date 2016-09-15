using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    // Text that is displayed in the UI.
    [SerializeField]
    private Text scoreText;
    // Amount of score we have.
    private int scoreCount;

    void Start()
    {
        SetScoreText();
        Target.AddScore += IncreaseScore;
    }
    
    // Increasing our currunt score with a given amount of points.
    void IncreaseScore(Target target)
    {
        scoreCount += target.Points;
        SetScoreText();

    }

    void SetScoreText()
    {
        // We update here our new scoreCount to be displayed in the UI.
        scoreText.text = "Score: " + scoreCount;
    }
}

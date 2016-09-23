using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject restartButton;
    
    void Start()
    {
        // Hide our button when the game starts.
        restartButton.SetActive(false);

        PlayerDeath.OnDeath += ActivateButton;
        TargetCounter.AllTargetsHit += ActivateButton;
        TimeCounter.TimeUp += ActivateButton;
    }

    private void ActivateButton()
    {
        restartButton.SetActive(true);
    }

    public void Restart()
    {
        // Reload our level.
        SceneManager.LoadScene(0);
    }

    void OnDestroy()
    {
        PlayerDeath.OnDeath -= ActivateButton;
        TargetCounter.AllTargetsHit -= ActivateButton;
        TimeCounter.TimeUp -= ActivateButton;
    }
}
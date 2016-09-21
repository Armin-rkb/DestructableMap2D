using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public delegate void OnTimeUp();
    public static event OnTimeUp TimeUp;

    [SerializeField]
    private Text timeText;
    [SerializeField]
    private float timeLeft;
	
    void Start()
    {
        TargetCounter.AllTargetsHit += StopScript;
    }

    void Update ()
    {
        if (timeLeft > 0)
            CountDownTime();
        else
        {
            if (TimeUp != null)
                TimeUp();
            timeText.text = "Time Left: 00 : 00";
        }
	}

    void CountDownTime()
    {
        timeLeft -= Time.deltaTime;

        float sec = timeLeft % 60;
        float fraction = (timeLeft * 100) % 60;

        timeText.text = string.Format("Time Left: {0:00} : {1:00}", Mathf.Floor(sec), fraction);
    }

    void StopScript()
    {
        TimeCounter timeCounter = GetComponent<TimeCounter>();
        timeCounter.enabled = false;
    }

    void OnDestroy()
    {
        TargetCounter.AllTargetsHit -= StopScript;
    }
}

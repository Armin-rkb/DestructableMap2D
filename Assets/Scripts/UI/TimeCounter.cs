using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public delegate void OnTimeUp();
    public static event OnTimeUp TimeUp;

    [SerializeField]
    private Text timeText;
    private float startTime = 0;
	
    void Start()
    {
        PlayerDeath.OnDeath += StopScript;
        TargetCounter.AllTargetsHit += StopScript;
    }

    void Update ()
    {
        if (startTime < 60)
            CountDownTime();
        else
        {
            if (TimeUp != null)
                TimeUp();
            timeText.text = "Time: 60 : 00";
        }
	}

    void CountDownTime()
    {
        startTime += Time.deltaTime;

        float sec = startTime % 60;
        float fraction = (startTime * 100) % 60;

        timeText.text = string.Format("Time: {0:00} : {1:00}", Mathf.Floor(sec), fraction);
    }

    void StopScript()
    {
        TimeCounter timeCounter = GetComponent<TimeCounter>();
        timeCounter.enabled = false;
    }

    void OnDestroy()
    {
        PlayerDeath.OnDeath -= StopScript;
        TargetCounter.AllTargetsHit -= StopScript;
    }
}

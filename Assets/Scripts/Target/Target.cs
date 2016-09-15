using UnityEngine;

public class Target : MonoBehaviour, ITarget
{
    public delegate void OnTargetHit(Target target);
    public static event OnTargetHit AddScore;

    // Amount of points that will be added to the score.
    [SerializeField]
    private int points;
    public int Points
    {
        get { return points; }
    }

    [SerializeField]
    private TargetManager targetManager;

    public void TargetHit()
    {
        targetManager.AmountOfTargets--;

        if (AddScore != null)
            AddScore(this);

        print("Targets left: " + targetManager.AmountOfTargets);
        Destroy(this.gameObject);
    }
}

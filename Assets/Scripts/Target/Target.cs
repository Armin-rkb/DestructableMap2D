using UnityEngine;

public class Target : MonoBehaviour, ITarget
{
    public delegate void OnTargetHit(Target target);
    public static event OnTargetHit TargetDestroyed;

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

        if (TargetDestroyed != null)
            TargetDestroyed(this);

        Destroy(this.gameObject);
    }
}

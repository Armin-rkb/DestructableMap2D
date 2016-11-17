using UnityEngine;
using UnityEngine.UI;

public class TargetCounter : MonoBehaviour
{
    public delegate void OnAllTargetsHit();
    public static event OnAllTargetsHit AllTargetsHit;

    [SerializeField]
    private TargetManager targetManager;
    [SerializeField]
    private Text targetText;
    private int maxTargets;
    private int targetsHit = 0;

    void Start()
    {
        maxTargets = targetManager.AmountOfTargets;
        targetText.text = targetsHit + " / " + maxTargets;
        Target.TargetDestroyed += DecreaseTargetCount;
    }

    void DecreaseTargetCount(Target target)
    {
        // If we still have have targets left; add 1 hit target.
        if (targetsHit != maxTargets )
        {
            targetsHit++;
            targetText.text = targetsHit + " / " + maxTargets;

            // If all targets are hit; pause the game.
            if (targetsHit == maxTargets)
            {
                if (AllTargetsHit != null)
                    AllTargetsHit();
            }
        }
    }

    void OnDestroy()
    {
        Target.TargetDestroyed -= DecreaseTargetCount;
    }
}

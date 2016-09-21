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
    private int targetsLeft;

    void Start()
    {
        maxTargets = targetManager.AmountOfTargets;
        targetsLeft = maxTargets;
        targetText.text = "Targets: " + targetsLeft + " / " + maxTargets;
        Target.TargetDestroyed += DecreaseTargetCount;
    }

    void DecreaseTargetCount(Target target)
    {
        // If we still have have targets left; remove 1 target.
        if (targetsLeft != 0)
        {
            targetsLeft--;
            targetText.text = "Targets: " + targetsLeft + " / " + maxTargets;

            // If all targets are hit; pause the game.
            if (targetsLeft == 0)
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

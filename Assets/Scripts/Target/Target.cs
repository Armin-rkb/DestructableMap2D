using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour, ITarget
{
    [SerializeField]
    private TargetManager targetManager;

    public void TargetHit()
    {
        targetManager.AmountOfTargets--;
        print(targetManager.AmountOfTargets);
        Destroy(this.gameObject);
    }
}

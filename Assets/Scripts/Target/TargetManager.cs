using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] targets;

    private int amountOfTargets;
    public int AmountOfTargets
    {
        get { return amountOfTargets; }
        set { amountOfTargets = value; }
    }

    void Awake()
    {
        amountOfTargets = targets.Length;
    }
}

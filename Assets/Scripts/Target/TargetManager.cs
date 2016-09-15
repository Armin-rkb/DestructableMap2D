using UnityEngine;
using System.Collections;

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

    void Start()
    {
        amountOfTargets = targets.Length;
    }
	
	// Update is called once per frame
	void Update ()
    {

	}
}

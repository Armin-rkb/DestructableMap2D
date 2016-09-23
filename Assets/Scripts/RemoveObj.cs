using UnityEngine;
using System.Collections;

public class RemoveObj : MonoBehaviour
{
    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
using UnityEngine;
using System.Collections;

public class RotateBody : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RotateObj());
    }

	IEnumerator RotateObj ()
    {
        while (true)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - pos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            yield return new WaitForSeconds(0.15f);
        }
    }
}

using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D destructionCircle;
    [SerializeField]
    private GroundController groundController;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Ground"))
        {
            groundController.DestroyGround(destructionCircle);
            Destroy(this.gameObject);
        }
    }
}

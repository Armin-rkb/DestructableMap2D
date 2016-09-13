using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rbBullet;
    [SerializeField]
    private CircleCollider2D destructionCircle;
    [SerializeField]
    private GroundController groundController;

    public void DirectBullet(Vector2 dir, float power)
    {
        power = power * 0.25f;
        rbBullet.AddForce(new Vector2(dir.x * power, dir.y * power), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Ground"))
        {
            groundController = coll.gameObject.GetComponent<GroundController>();
            groundController.DestroyGround(destructionCircle);
            Destroy(this.gameObject);
        }
    }
}

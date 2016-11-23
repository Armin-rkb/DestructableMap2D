using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rbBullet;
    [SerializeField]
    private CircleCollider2D destructionCircle;
    [SerializeField]
    private DestructableGround destructableGround;
    [SerializeField]
    private GameObject explosionEffect;

    public void DirectBullet(Vector2 dir, float power)
    {
        power = power * 0.25f;
        rbBullet.AddForce(new Vector2(dir.x * power, dir.y * power), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(Tags.ground))
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            destructableGround = coll.gameObject.GetComponent<DestructableGround>();
            destructableGround.DestroyGround(destructionCircle);
            Destroy(this.gameObject);
        }
        else if (coll.gameObject.CompareTag(Tags.target))
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Extensions.Execute<ITarget>(coll.gameObject, x => x.TargetHit());
            Destroy(this.gameObject);
        }
        else
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}

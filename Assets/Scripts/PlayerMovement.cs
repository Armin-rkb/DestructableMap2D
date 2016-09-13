using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    // The amount of force we will apply to our bullet.
    [SerializeField]
    private float shootPower;
    // The bullets that are given to us in our level. 
    [SerializeField]
    private BulletController[] bullets;
    // This number will help us indicate which index we are in the bullets array.
    private int bulletNum = 0;
    // Check if we have shot a bullet.
    [SerializeField]
    private bool hasShot = false;
    [SerializeField]
    private Vector3 shootDirection;

	void Update ()
    {
        // Setting our shootDirection equal to our mouse position.
        shootDirection = Input.mousePosition;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;

        // Shoot function
        if (!hasShot && Input.GetMouseButton(0))
        {
            // Increase the amount of power the longer we hold our mouse button.
            StartCoroutine(IncreasePower());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopAllCoroutines();
            ShootBullet();
        }
    }

    IEnumerator IncreasePower()
    {
        while (true)
        {
            shootPower++;
            print("POWER UP!!");
            yield return new WaitForSeconds(0.5f);
        }
    }

    void ShootBullet()
    {
        shootPower = Mathf.Clamp(shootPower, 1f, 20);
        BulletController bulletInstance = Instantiate(bullets[bulletNum], transform.position, Quaternion.Euler(Vector3.zero)) as BulletController;
        bulletInstance.DirectBullet(shootDirection, shootPower);
        //bulletNum++;
        shootPower = 0;
    }
}
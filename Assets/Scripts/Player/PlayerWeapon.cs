using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour
{
    // The amount of force we will apply to our bullet.
    private float shootPower;
    // The bullets that are given to us in our level. 
    [SerializeField]
    private Bomb bullet;
    // Where are bullet will spawn from.
    [SerializeField]
    private Transform nozzle;
    // The direction of our bullet.
    private Vector3 shootDirection;
    // Current reload time.
    private int reloadTime = 0;
    // Total reload time.
    private int maxReloadTime = 15;

    void Start()
    {
        TimeCounter.TimeUp += StopScript;
        TargetCounter.AllTargetsHit += StopScript;
    }

    void Update()
    {
        // Shoot function
        if (Input.GetMouseButton(0) && reloadTime <= 0)
        {
            // Increase the amount of power the longer we hold our mouse button.
            StartCoroutine(IncreasePower());
        }
        else if (Input.GetMouseButtonUp(0) && reloadTime <= 0)
        {
            StopAllCoroutines();
            ShootBullet();
        }

        if (reloadTime > 0)
            reloadTime--;
        else
            reloadTime = 0;
    }

    IEnumerator IncreasePower()
    {
        while (true)
        {
            shootPower++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    void ShootBullet()
    {
        // Setting our shootDirection equal to our mouse position.
        shootDirection = Input.mousePosition;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;

        // Clamp our shooting power and spawn the bullet.
        shootPower = Mathf.Clamp(shootPower, 1f, 20);
        Bomb bulletInstance = Instantiate(bullet, nozzle.position, Quaternion.Euler(Vector3.zero)) as Bomb;
        bulletInstance.DirectBullet(shootDirection, shootPower);
        reloadTime = maxReloadTime;
        shootPower = 0;
    }

    void StopScript()
    {
        PlayerWeapon playerWeapon = GetComponent<PlayerWeapon>();
        playerWeapon.enabled = false;
    }

    void OnDestroy()
    {
        TimeCounter.TimeUp -= StopScript;
        TargetCounter.AllTargetsHit -= StopScript;
    }
}
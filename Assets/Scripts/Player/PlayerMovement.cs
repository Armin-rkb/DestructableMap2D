using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rbPlayer;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpSpeed;
    private float moveX;

    private Vector2 movement;

    [SerializeField]
    private bool isJumping = false;
    [SerializeField]
    private bool grounded;

    [SerializeField]
    private LayerMask layer;

    void Start()
    {
        StartCoroutine(GroundCheck());
        TimeCounter.TimeUp += StopScript;
        TargetCounter.AllTargetsHit += StopScript;
    }

    void Update ()
    {
        moveX = Input.GetAxis("Horizontal");
        movement = new Vector2(moveX, 0);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            isJumping = true;
    }

    void FixedUpdate()
    {
        if (moveX != 0)
            MovePlayer();

        if (isJumping)
            JumpPlayer();
    }

    IEnumerator GroundCheck()
    {
        while(true)
        {
            // Draw a boxcast to check if we are grounded.
            Ray2D ray = new Ray2D(transform.position, Vector2.down);
            RaycastHit2D hit = Physics2D.BoxCast(ray.origin, new Vector2(1, 1), 1f, ray.direction, 1f, layer);

            if (hit)
                grounded = true;
            else
                grounded = false;

            yield return new WaitForSeconds(0.2f);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("DeathZone"))
            transform.position = new Vector2(-4, -3);
    }

    void JumpPlayer()
    {
        rbPlayer.velocity = Vector2.up * jumpSpeed;
        isJumping = false;
    }

    void MovePlayer()
    {
        rbPlayer.velocity = new Vector2(movement.x * movementSpeed, rbPlayer.velocity.y);
    }

    void StopScript()
    {
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        playerMovement.enabled = false;
        Destroy(rbPlayer);
    }
}
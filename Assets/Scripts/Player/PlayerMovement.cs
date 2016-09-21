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

    private Vector2 movement;

    [SerializeField]
    private LayerMask layer;

    private float moveX;
    public float MoveX
    {
        get { return moveX; }
    }
    
    private bool isJumping = false;
    public bool IsJumping
    {
        get { return isJumping; }
    }
    
    private bool isGrounded;
    public bool IsGrounded
    {
        get { return isGrounded; }
    }

    void Start()
    {
        StartCoroutine(GroundCheck());
        TimeCounter.TimeUp += StopScript;
        TargetCounter.AllTargetsHit += StopScript;
    }

    void Update ()
    {
        /*
        if (rbPlayer.velocity.x > 10)
            print(rbPlayer.velocity);
            */
        // Check if we hit our horizontal movement input.
        moveX = Input.GetAxis("Horizontal");
        // Store the value in a vector2.
        movement = new Vector2(moveX, 0);

        // Check if we hit the jump key and are grounded.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            isJumping = true;
    }

    void FixedUpdate()
    {
        // If we have movement, push the player.
        if (moveX != 0)
            MovePlayer();
        
        // If we are jumping; send our player upwards.
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
                isGrounded = true;
            else
                isGrounded = false;

            yield return new WaitForSeconds(0.2f);
        }

    }

    void JumpPlayer()
    {
        rbPlayer.velocity = Vector2.up * jumpSpeed;
        isJumping = false;
    }

    void MovePlayer()
    {
        rbPlayer.velocity = new Vector2(movement.x * movementSpeed, rbPlayer.velocity.y);
        //rbPlayer.AddForce(new Vector2(movement.x * movementSpeed, rbPlayer.velocity.y));
    }

    void StopScript()
    {
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        playerMovement.enabled = false;
        Destroy(rbPlayer);
    }

    void OnDestroy()
    {
        TimeCounter.TimeUp -= StopScript;
        TargetCounter.AllTargetsHit -= StopScript;
    }
}
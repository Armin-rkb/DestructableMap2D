using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animatorPlayer;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private PlayerMovement playerMovement;

    void Start()
    {
        StartCoroutine(ChangeAnimations());
    }

    IEnumerator ChangeAnimations()
    {
        while (true)
        {
            // Check if we are in a walking state.
            if (playerMovement.MoveX > 0 || playerMovement.MoveX < 0)
                animatorPlayer.SetBool("isWalking", true);
            else if (playerMovement.MoveX == 0)
                animatorPlayer.SetBool("isWalking", false);
            
            // Check which way we are facing.
            if (playerMovement.MoveX < 0)
                spriteRenderer.flipX = true;
            else if (playerMovement.MoveX > 0)
                spriteRenderer.flipX = false;

            // Check if we are in the jumping state.
            if (!playerMovement.IsGrounded)
            {
                animatorPlayer.SetBool("isJumping", true);
            }

            else if (!playerMovement.IsJumping && playerMovement.IsGrounded)
                animatorPlayer.SetBool("isJumping", false);
            
            yield return new WaitForSeconds(0.1f);
        }
    }
}

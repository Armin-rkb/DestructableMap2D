using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour
{
    public delegate void OnPlayerDeath();
    public static event OnPlayerDeath OnDeath;

    // Checking if our player died.
    void OnCollisionEnter2D(Collision2D coll)
    {
        // If we hit the deathzones of the screen, hide our player and display the restart button.
        if (coll.gameObject.CompareTag("DeathZone"))
        {
            PlayerDied();
        }
    }

    void PlayerDied()
    {
        // Hiding our died player.
        this.gameObject.SetActive(false);

        if (OnDeath != null)
            OnDeath();
    }
}

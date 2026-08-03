using UnityEngine;

/// <summary>
/// Handles all player (bird) input and collision events.
/// Reads game state from the GameManager singleton before allowing input,
/// preventing the player from jumping after death.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float force = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.linearVelocity = Vector2.up * force;
            }
        }
    }

    /// <summary>
    /// Fires on physical collision with tagged 'Obstacle' (pipes) or 'Ground'.
    /// Triggers Game Over via the GameManager singleton.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") ||
            collision.gameObject.CompareTag("Ground"))
        {
            GameManager.instance.TriggerGameOver();
        }
    }

    /// <summary>
    /// Fires when the bird passes through the invisible ScoreZone trigger
    /// placed between each pair of pipes. Increments the live score.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScoreZone"))
        {
            GameManager.instance.IncreaseScore();
        }
    }
}

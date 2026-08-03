using UnityEngine;

/// <summary>
/// Attached to all obstacle prefabs (pipes and scrolling background elements).
/// Translates the object leftward at a constant speed while the game is active,
/// creating the illusion of the bird flying forward.
/// </summary>
public class Speed : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        if (GameManager.instance.isGameOver == false)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }
}

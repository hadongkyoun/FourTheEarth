using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    private Rigidbody2D rb = null;


    [SerializeField]
    private float moveSpeed = 5f;
    public Vector2 MoveDirection { get; set; } = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void Move()
    {
        rb.MovePosition(rb.position + MoveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}

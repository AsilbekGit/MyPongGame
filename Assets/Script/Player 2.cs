using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;  // Speed at which the paddle moves
    [SerializeField] private bool isPlayerOne;  // Check if this is Player One or Player Two

    private Rigidbody2D rb;
    private float movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isPlayerOne)
        {
            movement = Input.GetAxisRaw("Vertical");  // Vertical1 is mapped to "W" and "S" in the Input Manager
        }
        else
        {
            movement = Input.GetAxisRaw("2");  // Vertical2 is mapped to Up and Down Arrow keys in the Input Manager
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, movement * movementSpeed);
    }
}

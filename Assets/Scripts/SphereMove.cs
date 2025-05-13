using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArrowKeyController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 6f;
    public LayerMask groundLayer; // Assign to "Default" or whatever your ground is on
    public float groundCheckDistance = 0.1f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        CheckGrounded();

        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.RightArrow)) moveX += 1;
        if (Input.GetKey(KeyCode.LeftArrow))  moveX -= 1;
        if (Input.GetKey(KeyCode.UpArrow))    moveZ += 1;
        if (Input.GetKey(KeyCode.DownArrow))  moveZ -= 1;

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized * speed;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void CheckGrounded()
    {
        float sphereRadius = GetComponent<SphereCollider>().radius;
        Vector3 origin = transform.position + Vector3.down * (sphereRadius - 0.1f);
        isGrounded = Physics.Raycast(origin, Vector3.down, groundCheckDistance, groundLayer);
    }
}

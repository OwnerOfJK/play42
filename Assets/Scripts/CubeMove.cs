using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WASDController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.D)) moveX += 1;
        if (Input.GetKey(KeyCode.A)) moveX -= 1;
        if (Input.GetKey(KeyCode.W)) moveZ += 1;
        if (Input.GetKey(KeyCode.S)) moveZ -= 1;

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized * speed;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z); // preserve gravity
    }
}

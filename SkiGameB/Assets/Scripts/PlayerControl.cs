using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private InputAction move;
    [SerializeField] private float rotSpeed = 60;
    [SerializeField] private float speed = 60;
    void Awake()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        Vector2 moveInput = move.ReadValue<Vector2>();
        //Debug.Log("x: " + moveInput.x + " y: " + moveInput.y);
        transform.Rotate(0, -moveInput.x * rotSpeed * Time.fixedDeltaTime, 0);
        float turnAngle = Mathf.Abs(180 - transform.localEulerAngles.y);
        float speedMult = Mathf.Cos(turnAngle * Mathf.Deg2Rad);
        rb.AddForce(transform.forward * speed * speedMult * Time.fixedDeltaTime);
        //Debug.Log("turn angle: " + turnAngle);
    }
}

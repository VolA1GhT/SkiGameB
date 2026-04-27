using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private InputAction move;
    [SerializeField] private float rotSpeed = 60;
    [SerializeField] private float speed = 60;
    [SerializeField] private bool grounded = true;
    [SerializeField] private LayerMask groundMask;
    void Awake()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Obstacle.OnPlayerHit += TakeDamage;
    }

    void TakeDamage()
    {
        Debug.Log("PLAYER GOT HURT");
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down);
    }
    */

    void FixedUpdate()
    {
        grounded = Physics.Linecast(transform.position, transform.position + Vector3.down, groundMask);

        /*Color lineColor;
        if(grounded)
            lineColor = Color.green;
        else
            lineColor = Color.red;
        */

        Color lineCol = grounded ? Color.green : Color.red; 
        Debug.DrawLine(transform.position, transform.position + Vector3.down, lineCol);

        if (grounded) 
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
}

    using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public float moveSpeed = 5.0f;
    public Vector2 moveDirection;
    public Rigidbody rb;
    public float rotationSpeed = 700f;

    [Header("Animations Settings")]
    public Animator anim;
    public bool isWalking;

    private void Awake()
    {
        if (anim == null)
            anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        moveDirection = new Vector2(moveHorizontal, moveVertical);

        isWalking = Mathf.Abs(moveHorizontal) > 0.01f || Mathf.Abs(moveVertical) > 0.01f;
        if (anim != null)
            anim.SetBool("isWalking", isWalking);
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveDirection.x, 0f, moveDirection.y);
        Vector3 moveVelocity = move.normalized * moveSpeed;

        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);

        if (move.magnitude > 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
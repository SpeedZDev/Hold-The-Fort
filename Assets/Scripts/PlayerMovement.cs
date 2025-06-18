using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float PlayerHeight;
    public bool IsGrounded;
    public float MovementSpeed;
    public float JumpForce;
    public float GroundDrag;
    float MoveX;
    float MoveZ;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!BuildManager.instance.IsInBuildMode)
        {
            MoveX = Input.GetAxisRaw("Horizontal");
            MoveZ = Input.GetAxisRaw("Vertical");

            IsGrounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.2f);
            if (IsGrounded)
            {
                rb.drag = GroundDrag;
            }
        }
        
    }

    void FixedUpdate()
    {
        Vector3 MovementDir = transform.right * MoveX + transform.forward * MoveZ;

        rb.AddForce(MovementDir * MovementSpeed * 10, ForceMode.Force);
}
    
}

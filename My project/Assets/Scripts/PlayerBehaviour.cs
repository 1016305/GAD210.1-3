using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveInput;
    float moveInputModifier = 100f;
    [SerializeField] bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void GetInput()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        
    }
    void Move()
    {
        rb.AddForce(moveInput * moveInputModifier);
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            jump = true;
            rb.AddForce(Vector3.up * 5000);
            Debug.Log("Jump");
        }
        else if ((Input.GetKeyDown(KeyCode.Space) && jump))
        {
            return;
        }
        if (jump && rb.velocity.y < 0.5)
        {
            jump = false;
        }
    }
    public Tuple<string, string> DisplayStats()
    {
        string velocity = "Current Y velocity: " + rb.velocity.y.ToString();
        string isJump = "Jumping? " + jump.ToString();
        return new Tuple<string, string>(velocity, isJump);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public float acceleration = 5f;
    public float deceleration = 5f;
    public float maxVelocity = 1f;
    public float minVelocity = 0.01f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float ySpeed;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] LayerMask ground;

    private CharacterController controller;
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        bool spaceKeyPressed = Input.GetKeyDown(KeyCode.Space);

        float getHorizontalInp = Input.GetAxis("Horizontal");
        float getVerticalInp = Input.GetAxis("Vertical");

        animator.SetFloat("Velocity Z", getVerticalInp);
        animator.SetFloat("Velocity X", getHorizontalInp);

        bool isGrounded = Physics.CheckSphere(transform.position, 2, ground);

        ySpeed += gravity * Time.deltaTime;

        if (isGrounded && ySpeed <= 0f)
        {
            ySpeed = -1f;
            if (spaceKeyPressed)
            {
                ySpeed = jumpForce;
            }

        }
        Vector3 velocity = new Vector3(0, 0, 0);
        velocity.y = ySpeed;
        controller.Move(velocity * Time.deltaTime);
    }
}

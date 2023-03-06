
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    [Tooltip("Character Jump Speed")]
    [SerializeField] private float jumpHeight = 1.0f;
    private bool isJumping = false;
    private bool isRunning = false;
    private float verticalVelocity;//different jump values in different places
    private float groundedTimer;  
    private float gravityValue = 9.81f;

    [SerializeField] Transform cam;
    Animator anim;
    [SerializeField] float characterSpeed;
    float turnSmoothVelocity;
    float turnSmoothTime = .1f;



    private void Start()
    {
        // always add a controller
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {     
        playerMovement();
        playerJump();
        
    }
    void playerJump()
    {
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isRunning", isRunning);

        if (anim.GetFloat("Horizontal") != 0 || anim.GetFloat("Vertical") != 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
       
        bool groundedPlayer = controller.isGrounded;
        Vector3 move = Vector3.zero;
        if (groundedPlayer)
        {
            // cooldown interval to allow reliable jumping even whem coming down ramps
            groundedTimer = 0.2f;
        }
        if (groundedTimer > 0)
        {
            groundedTimer -= Time.deltaTime;
        }

        // slam into the ground
        if (groundedPlayer && verticalVelocity < 0)
        {
            // hit ground
            verticalVelocity = 0f;
        }

        // apply gravity always, to let us track down ramps properly
        verticalVelocity -= gravityValue * Time.deltaTime;

        // allow jump as long as the player is on the ground
        if (Input.GetButton("Jump") &&!isJumping)
        {   
            // must have been grounded recently to allow jump
            if (groundedTimer >= -0.01f)
            {
                // no more until we recontact ground
                groundedTimer = 0;
                isJumping = true;
                // Physics dynamics formula for calculating jump up velocity based on height and gravity
                verticalVelocity = Mathf.Sqrt(jumpHeight * 2 * gravityValue);//at += we can
            }
        }

        // inject Y velocity before we use it
        move.y = verticalVelocity;

        // call .Move() once only
        controller.Move(move * Time.deltaTime * 10);
    }
    void playerMovement()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(Horizontal, 0, vertical);

        anim.SetFloat("Horizontal", Horizontal);
        anim.SetFloat("Vertical", vertical);
        if (Horizontal != 0 || vertical != 0)
        {   
            //Character Control with Mouse
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDir.normalized * characterSpeed * Time.deltaTime);

        }


    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.normal.y > 0.5f)
        {
            isJumping = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    public CharacterController controller;

    [Header("Wallrunning")]
    public LayerMask whatIsWall;
    public LayerMask whatIsGround;
    public float wallRunForce;
    public float wallJumpUpForce;
    public float wallJumpSideForce;
    public float wallClimbSpeed;
    public float maxWallRunTime;
    private float wallRunTimer;
    public float maxWallJumpTime;
    private float wallJumpTimer;

    [Header("Input")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode upwardsRunKey = KeyCode.LeftShift;
    public KeyCode downwardsRunKey = KeyCode.LeftControl;
    private bool upwardsRunning;
    private bool downwardsRunning;
    private float horizontalInput;
    private float verticalInput;

    [Header("Detection")]
    public float wallCheckDistance;
    public float minJumpHeight;
    private RaycastHit leftWallhit;
    private RaycastHit rightWallhit;
    private bool wallLeft;
    private bool wallRight;
    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    public bool isGrounded;


    [SerializeField]
    private float jumpTimeCounter;
    [SerializeField]
    public float jumpTime;
    private bool isJumping;
    private float jumpForce;
    public float jumpHeight = 10f;

    [Header("Exiting")]
    private bool exitingWall;
    public float exitWallTime;
    private float exitWallTimer;
    private bool exitingWallJump;
    public float exitWallJumpTime;
    private float exitWallJumpTimer;

    [Header("Gravity")]
    public bool useGravity;
    public float gravityCounterForce;

    [Header("References")]
    public Transform orientation;
    private PlayerMovement pm;
    private CharacterController cc;
    private Rigidbody rb;


    Vector3 vector = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        pm = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        CheckForWall();
        StateMachine();
    }

    private void FixedUpdate()
    {
        if (pm.wallrunning)
            WallRunningMovement();
    }

    private void CheckForWall()
    {
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallhit, wallCheckDistance, whatIsWall);
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallhit, wallCheckDistance, whatIsWall);
    }

    private bool AboveGround()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, whatIsGround);
    }

    private void StateMachine()
    {
        // Getting Inputs
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        upwardsRunning = Input.GetKey(upwardsRunKey);
        downwardsRunning = Input.GetKey(downwardsRunKey);

        // State 1 - Wallrunning
        if ((wallLeft || wallRight) && verticalInput > 0 && AboveGround())
        {
            if (!pm.wallrunning)
                StartWallRun();

            // wallrun timer
            if (wallRunTimer > 0)
                wallRunTimer -= Time.deltaTime;

            if (wallRunTimer <= 0 && pm.wallrunning)
            {
                exitingWall = true;
                exitWallTimer = exitWallTime;
            }

            /* // wall jump
             if (Input.GetButton("Jump")) 
             {
                 WallJump();
             }
             if (isGrounded == true)
             {

                 StopWallJump();
             }*/
            // State 1 - WallJumping
            if (Input.GetButton("WallJump"))
            {
                if (!pm.wallrunning)
                    WallJump();

                // wallrun timer
                if (wallJumpTimer > 0)
                    wallJumpTimer -= Time.deltaTime;

              /*  if (wallJumpTimer <= 0 && isGrounded = true)
                {
                    exitingWallJump = true;
                    exitWallJumpTimer = exitWallJumpTime;
                }*/

                // wall jump
                /* if 
                 {

                 }
                 if (isGrounded == true)
                 {

                     StopWallJump();
                 }*/


                // State 2 - Exiting


                // if (Input.GetButton("Jump") && isJumping == true) /* Den här koden ser till så att när spelaren trycker på space och inte håller ner space
                //så blir det ett kortare hopp och den ser också till så att det inte funkar i luften.*/
                /* {


                     if (jumpTimeCounter > 0)
                     {
                         print("continue jump");
                         pm.velocity = Vector3.up * jumpHeight;
                         jumpTimeCounter -= Time.deltaTime;
                     }
                     else
                     {
                         print("nej jump");
                         isJumping = false;
                     }
                 }
                 else
                 {
                     isJumping = false;
                 }*/




            }
            else if (exitingWallJump)
            {
                if (isGrounded = true)
                    StopWallJump();

                if (exitWallJumpTimer > 0)
                    exitWallJumpTimer -= Time.deltaTime;

                if (exitWallJumpTimer <= 0)
                    exitingWallJump = false;
            }

            // State 3 - None
            else
            {
                if (pm.wallrunning)
                    StopWallJump();
            }
        }

        // State 2 - Exiting
        else if (exitingWall)
        {
            if (pm.wallrunning)
                StopWallRun();

            if (exitWallTimer > 0)
                exitWallTimer -= Time.deltaTime;

            if (exitWallTimer <= 0)
                exitingWall = false;
        }
        else
        {
            if (pm.wallrunning)
                StopWallRun();
        }

            
        
    }

    private void StartWallRun()
    {
        pm.wallrunning = true;
        wallRunTimer = maxWallRunTime;

        pm.gravity = 20f;

    }

    private void WallRunningMovement()
    {
        // .useGravity = false; //stäng av gravity
        pm.gravity = -2f;
        // cc.
        pm.velocity = new Vector3(pm.velocity.x, -2f, pm.velocity.z);

        Vector3 wallNormal = wallRight ? rightWallhit.normal : leftWallhit.normal;

        Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);

        if ((orientation.forward - wallForward).magnitude > (orientation.forward - -wallForward).magnitude)
            wallForward = -wallForward;

        // forward force
       // rb.AddForce(wallForward * wallRunForce, ForceMode.Force);

        // upwards/downwards force
        /* if (upwardsRunning)
             pm.velocity = new Vector3(pm.velocity.x, wallClimbSpeed, pm.velocity.z);
         if (downwardsRunning)
             pm.velocity = new Vector3(pm.velocity.x, -wallClimbSpeed, pm.velocity.z);*/

        // push to wall force
        /*if(Physics.CheckSphere(position,5f,"Wall"))
            ()*/

        //if (!(wallLeft && horizontalInput > 0) && !(wallRight && horizontalInput < 0))
          //  rb.AddForce(-wallNormal * 100, ForceMode.Force);
    }

    private void StopWallRun()
    {
        pm.wallrunning = false;
        pm.gravity = -35f;
    }

    private void WallJump()
    {
        // enter exiting wall state
        exitingWall = true;
        exitWallTimer = exitWallTime;
        pm.wallrunning = true;
        wallJumpTimer = maxWallJumpTime;

        /*Vector3 wallNormal = wallRight ? rightWallhit.normal : leftWallhit.normal;

        Vector3 forceToApply = transform.up * wallJumpUpForce + wallNormal * wallJumpSideForce;

         reset y velocity and add force
        pm.velocity = new Vector3(pm.velocity.x, 0f, pm.velocity.z);
        rb.AddForce(forceToApply, ForceMode.Impulse);*/

        if ((wallLeft) && verticalInput > 0 && AboveGround())
        {
            //  velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 

            print("Wall jump");
            //isJumping = true;
            //jumpTimeCounter = jumpTime;
            pm.velocity = new Vector3(10, 10, 0);



            /*if (jumpTimeCounter > 0)
            {
                print("continue Walljump");
               
                jumpTimeCounter -= Time.deltaTime;
                print("nej jump");
                isJumping = false;
            }*/
             
        }

        if ((wallRight) && verticalInput > 0 && AboveGround())
        {
            //  velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 

            print("Wall jump");
            //isJumping = true;
            //jumpTimeCounter = jumpTime;
            pm.velocity = new Vector3(-10, 10, 0);



            /*if (jumpTimeCounter > 0)
            {
                print("continue Walljump");
               
                jumpTimeCounter -= Time.deltaTime;
                print("nej jump");
                isJumping = false;
            }*/

        }






    }
    private void StopWallJump()
    {
        pm.wallrunning = false;
        pm.gravity = -35f;
        pm.velocity = new Vector3(0, 0, 0);
       print("nej Walljump");
       //isJumping = false;
    }
}

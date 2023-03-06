using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    //MouseLook mouseLook;
    AudioSource source;
    Vector3 velocity;
    bool isGrounded;


    /**/
    public bool canMove = true;
    bool isCrouch = false;
    bool isRunning = false;

    bool isMoving;
   /**/// public bool isLeaning = false;

    [SerializeField] Transform ground;
    [SerializeField] float distance = 0.3f;

    [SerializeField] float speed;
    float originalSpeed;
    float crouchSpeed;
    float RunSpeed;


    [SerializeField] float jumpHeight;
    float originalJump;
    [SerializeField] float gravity = -9.8f;

    [SerializeField] LayerMask mask;

    float timer;
    [SerializeField] float timeBetweenSteps;

    [SerializeField] float runBetweenSteps;
    [SerializeField] float walkBetweenSteps;

    public AudioClip[] stepSoundRun;
    public AudioClip[] stepSoundWalk;
    public AudioClip[] stepSoundJump;

    [SerializeField] float originalHeight;
    [SerializeField] float crouchHeight;



    float Horizontal, Vertical;


    // public float fpsgoster, araliksn;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        originalSpeed = speed;
        crouchSpeed = speed / 2;
        RunSpeed = speed * 3 / 2;
        originalJump = jumpHeight;
        source = GetComponent<AudioSource>();
        walkBetweenSteps = timeBetweenSteps;
        runBetweenSteps = timeBetweenSteps * 3 / 4;
       // transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));////
    }
   
    private void OnTriggerEnter(Collider other)
    {
        //   controller.radius = 0.2f;
    }
    private void OnTriggerExit(Collider other)
    {
        //  controller.radius = 0.3f;
    }
    private void Update()
    {
        // StartCoroutine(fps());
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Movement();
        FootSteps();
        Jump();
        Gravity();
        BasicCrouch();
        BasicRunning();

    }
    void Movement()
    {
        Vector3 move = transform.right * Horizontal + transform.forward * Vertical;
        if (canMove)
        {
            controller.Move(move * speed * Time.deltaTime);

        }
    }
    void FootSteps()
    {
        if (Horizontal != 0 || Vertical != 0)//Hareket Ediyorsa
            isMoving = true;
        else
            isMoving = false;

        if (isMoving && isGrounded /*&& !isLeaning*/)
        {
            if (isRunning && !(isRunning && isCrouch) && MouseLook.isRotating == false/*&& !isLeaning*/) //Yani Koşuyor
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = timeBetweenSteps;
                    source.clip = stepSoundRun[Random.Range(0, stepSoundRun.Length)];
                    source.pitch = Random.Range(0.9f, 1.1f);
                    source.Play();
                }
            }
            else if (!isCrouch && !isRunning && MouseLook.isRotating == false)//Yani Yürüyor 
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    timer = timeBetweenSteps;
                    source.clip = stepSoundWalk[Random.Range(0, stepSoundWalk.Length)];
                    source.pitch = Random.Range(0.85f, 1.1f);
                    source.Play();
                }
            }


        }
        else
        {
            timer = timeBetweenSteps;
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && MouseLook.isRotating == false/*&& isLeaning == false*/)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
            //Zıplayınca Ses Çıikiyor.
            source.clip = stepSoundJump[Random.Range(0, stepSoundJump.Length)];
            source.pitch = Random.Range(0.85f, 1.1f);
            source.Play();


        }
    }
    void Gravity()
    {
        isGrounded = Physics.CheckSphere(ground.position, distance, mask);//buradaki distance yere olan uzakl�k
                                                                          //yani yer ile 'distance' uzakl�k olursa ve layer uyarsa z�playabilirsin.

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    void BasicCrouch()//oturma
    {

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            controller.height = crouchHeight;
            speed = crouchSpeed;
            jumpHeight = 0;
            isCrouch = true;

            gravity = -150;
        }

      /**/  if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            controller.height = originalHeight;
            speed = originalSpeed;
            jumpHeight = originalJump;
            isCrouch = false;
            gravity = -9.8f;
        }
    }
    void BasicRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isCrouch)
        {

            speed = RunSpeed;
            if (isGrounded)
                isRunning = true;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !isCrouch)
        {
            speed = originalSpeed;
            if (isGrounded)
                isRunning = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "sil")
        {
           // Debug.Log("carpti");
            this.transform.localRotation = Quaternion.Euler(-10, 0, 0);
        }
    }
    //IEnumerator fps()
    //{
    //    while (true)
    //    {
    //        fpsgoster = 1 / Time.deltaTime;
    //        yield return new WaitForSecondsRealtime(araliksn);
    //    }
    //}

}

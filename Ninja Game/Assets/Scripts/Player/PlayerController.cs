using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float crawlSpeed;
    public float walkSpeed;
    public float runSpeed;
    private Rigidbody myRigidbody;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;
    private Animator anim;
    public AttackingController Weapon;
    public GameObject parent;
    public bool isProne = false;
    public bool isRunning = false;
    public bool isWalking = false;
    public bool isCrawling = false;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);

            transform.LookAt(new Vector3(pointToLook.x,transform.position.y,pointToLook.z));
        }

        //attacking
        if (Input.GetMouseButtonDown(0))
        {
            Weapon.isAttacking = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Weapon.isAttacking = false;
        }

        //walking
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            //play walking animation
            isWalking = true;
            if (!isProne)
            {
                anim.SetBool("IsWalking", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            //go back to idle animation
            isWalking = false;
            anim.SetBool("IsWalking", false);
        }

        //running
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isProne)
        {
            moveSpeed = runSpeed;
            parent.transform.GetChild(0).gameObject.SetActive(true);
            isRunning = true;
            if (isWalking && isRunning)
            {
                //play running animation
                anim.SetBool("IsRunning", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !isProne)
        {
            moveSpeed = walkSpeed;
            parent.transform.GetChild(0).gameObject.SetActive(false);
            isRunning = false;
            anim.SetBool("IsRunning", false);
        }

        //prone
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveSpeed = crawlSpeed;
            anim.SetBool("IsProne", true);
            isProne = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            moveSpeed = walkSpeed;
            anim.SetBool("IsProne", false);
            isProne = false;
        }

        //crawling
        if (isWalking && isProne)
        {
            //play crawling animation
            isCrawling = true;
            anim.SetBool("IsCrawling", true);
            anim.SetBool("IsWalking", false);
        }
        if (!isWalking && isProne)
        {
            isCrawling = false;
            anim.SetBool("IsCrawling", false);
            anim.SetBool("IsProne", true);
        }
        if (isWalking && !isProne)
        {
            isWalking = true;
            isCrawling = false;
            anim.SetBool("IsCrawling", false);
            anim.SetBool("IsWalking", true);
        }
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
}

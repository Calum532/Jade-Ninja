using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody myRigidbody;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;
    public AttackingController Weapon;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
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

        if (Input.GetMouseButtonDown(0))
        {
            Weapon.isAttacking = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Weapon.isAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 18;
            parent.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 10;
            parent.transform.GetChild(0).gameObject.SetActive(false);
        } 
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
}

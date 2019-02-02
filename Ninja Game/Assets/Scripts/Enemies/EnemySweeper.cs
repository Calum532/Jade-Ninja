using UnityEngine;

public class EnemySweeper : MonoBehaviour
{
    public float viewDistance;
    public float damage;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position + Vector3.up, transform.forward * viewDistance, Color.green);
        Debug.DrawRay(transform.position + Vector3.up, (transform.forward + transform.right / 5).normalized * viewDistance, Color.green);
        Debug.DrawRay(transform.position + Vector3.up, (transform.forward - transform.right / 5).normalized * viewDistance, Color.green);
        Debug.DrawRay(transform.position + Vector3.up, (transform.forward + transform.up / 5).normalized * viewDistance, Color.green);
        Debug.DrawRay(transform.position + Vector3.up, (transform.forward - transform.up / 5).normalized * viewDistance, Color.green);

        if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out hit, viewDistance) ||
            Physics.Raycast(transform.position + Vector3.up, (transform.forward + transform.right / 5).normalized, out hit, viewDistance) ||
            Physics.Raycast(transform.position + Vector3.up, (transform.forward - transform.right / 5).normalized, out hit, viewDistance) ||
            Physics.Raycast(transform.position + Vector3.up, (transform.forward + transform.up / 5).normalized, out hit, viewDistance) ||
            Physics.Raycast(transform.position + Vector3.up, (transform.forward - transform.up / 5).normalized, out hit, viewDistance))
        {
            if(hit.collider != null)
            {
                Debug.DrawRay(transform.position + Vector3.up, transform.forward * viewDistance, Color.red);
                Debug.DrawRay(transform.position + Vector3.up, (transform.forward + transform.right / 5).normalized * viewDistance, Color.red);
                Debug.DrawRay(transform.position + Vector3.up, (transform.forward - transform.right / 5).normalized * viewDistance, Color.red);
                Debug.DrawRay(transform.position + Vector3.up, (transform.forward + transform.up / 5).normalized * viewDistance, Color.red);
                Debug.DrawRay(transform.position + Vector3.up, (transform.forward - transform.up / 5).normalized * viewDistance, Color.red);
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player spotted by Sweeper");
                    player.GetComponent<PlayerHealth>().HurtPlayer(damage);
                }
            }
        }
    }
}

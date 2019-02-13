using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public float viewDistance;
    public float sightHeightMultiplyer;
    Light lt;
    [SerializeField] protected Vector3 m_from = new Vector3(0.0F, 45.0F, 0.0F);
    [SerializeField] protected Vector3 m_to = new Vector3(0.0F, -45.0F, 0.0F);
    [SerializeField] protected float m_frequency;
    public float damage;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        lt = GetComponent<Light>();
    }

    void Update()
    {
        lt.color = Color.yellow;

        Quaternion from = Quaternion.Euler(this.m_from);
        Quaternion to = Quaternion.Euler(this.m_to);

        float lerp = 0.5F * (1.0F + Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup * this.m_frequency));
        this.transform.localRotation = Quaternion.Lerp(from, to, lerp);

        RaycastHit hit;

        Debug.DrawRay(transform.position + Vector3.up * sightHeightMultiplyer, transform.forward * viewDistance, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * sightHeightMultiplyer, (transform.forward + transform.right / 12).normalized * viewDistance, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * sightHeightMultiplyer, (transform.forward - transform.right / 12).normalized * viewDistance, Color.green);

        if (Physics.Raycast (transform.position + Vector3.up * sightHeightMultiplyer, transform.forward, out hit, viewDistance))
        {
            if(hit.collider != null)
            {
                Debug.DrawRay(transform.position + Vector3.up * sightHeightMultiplyer, transform.forward * viewDistance, Color.red);
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player spotted by turret");
                    lt.color = Color.red;
                    player.GetComponent<PlayerHealth>().HurtPlayer(damage);
                }
            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * sightHeightMultiplyer, (transform.forward + transform.right / 12).normalized, out hit, viewDistance))
        {
            if (hit.collider != null)
            {
                Debug.DrawRay(transform.position + Vector3.up * sightHeightMultiplyer, (transform.forward + transform.right / 12).normalized * viewDistance, Color.red);
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player spotted by turret");
                    lt.color = Color.red;
                    player.GetComponent<PlayerHealth>().HurtPlayer(damage);
                }
            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * sightHeightMultiplyer, (transform.forward - transform.right / 12).normalized, out hit, viewDistance))
        {
            if (hit.collider != null)
            {
                Debug.DrawRay(transform.position + Vector3.up * sightHeightMultiplyer, (transform.forward - transform.right / 12).normalized * viewDistance, Color.red);
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player spotted by turret");
                    lt.color = Color.red;
                    player.GetComponent<PlayerHealth>().HurtPlayer(damage);
                }
            }
        }
    }
}

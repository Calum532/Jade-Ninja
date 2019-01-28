using UnityEngine;

public class EnemyImp : MonoBehaviour
{
    public float viewDistance;
    public float sightHeightMultiplyer;
    Light lt;
    public int health = 1;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        sightHeightMultiplyer = 2.6f;
        lt = GetComponent<Light>();
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position + Vector3.up * sightHeightMultiplyer, transform.forward * viewDistance, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * sightHeightMultiplyer, (transform.forward + transform.right / 2).normalized * viewDistance, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * sightHeightMultiplyer, (transform.forward - transform.right / 2).normalized * viewDistance, Color.green);

        if (Physics.Raycast (transform.position + Vector3.up * sightHeightMultiplyer, transform.forward, out hit, viewDistance))
        {
            if(hit.collider != null)
            {
                Debug.DrawRay(transform.position + Vector3.up * sightHeightMultiplyer, transform.forward * viewDistance, Color.red);
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player spotted");
                    lt.color = Color.red;
                    GetComponent<Chase>().enabled = true;
                    GetComponent<Patrol>().enabled = false;
                }
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * sightHeightMultiplyer, (transform.forward + transform.right / 2).normalized, out hit, viewDistance))
        {
            if (hit.collider != null)
            {
                Debug.DrawRay(transform.position + Vector3.up * sightHeightMultiplyer, (transform.forward + transform.right / 2).normalized * viewDistance, Color.red);
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player spotted");
                    lt.color = Color.red;
                    GetComponent<Chase>().enabled = true;
                    GetComponent<Patrol>().enabled = false;
                }
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * sightHeightMultiplyer, (transform.forward - transform.right / 2).normalized, out hit, viewDistance))
        {
            if (hit.collider != null)
            {
                Debug.DrawRay(transform.position + Vector3.up * sightHeightMultiplyer, (transform.forward - transform.right / 2).normalized * viewDistance, Color.red);
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player spotted");
                    lt.color = Color.red;
                    GetComponent<Chase>().enabled = true;
                    GetComponent<Patrol>().enabled = false;
                }
            }
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }

    public void Enrage(int healthGained)
    {
        health = health + healthGained;
        currentHealth = health;
    }
}

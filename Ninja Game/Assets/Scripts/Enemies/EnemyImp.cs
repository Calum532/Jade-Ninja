using UnityEngine;

public class EnemyImp : MonoBehaviour
{
    public float viewDistance;
    public float sightHeightMultiplyer;
    public int health;
    public int currentHealth;
    GameObject obj;
    public GameObject deathEffect;

    private void Awake()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        sightHeightMultiplyer = 2.6f;
        currentHealth = health;
    }

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
                    Debug.Log("EnemyImp - Player spotted");
                    GetComponent<Chase>().enabled = true;
                    GetComponent<ImpPatrol>().enabled = false;
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
                    Debug.Log("EnemyImp - Player spotted");
                    GetComponent<Chase>().enabled = true;
                    GetComponent<ImpPatrol>().enabled = false;
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
                    Debug.Log("EnemyImp - Player spotted");
                    GetComponent<Chase>().enabled = true;
                    GetComponent<ImpPatrol>().enabled = false;
                }
            }
        }

        if (currentHealth <= 0)
        {
            Debug.Log("EnemyImp - Imp Killed");
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("ImpDeath");
            FindObjectOfType<AudioManager>().Play("ImpDeathEffect");
            obj.GetComponent<Score>().impsKilledCount();
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }

    public void HurtEnemy()
    {
        currentHealth -= 1;
    }
}
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 1;
    public static float currentHealth;
    public Transform player;
    public Transform respawnPoint;
    public GameObject smokeBomb;

    public Chase[] chaseArray;

    private void Awake()
    {
        //Finds all the chase scripts and put them in an array
        GameObject[] imps = GameObject.FindGameObjectsWithTag("Imp");
        chaseArray = new Chase[imps.Length];
        for (int i = 0; i < imps.Length; ++i)
        {
            chaseArray[i] = imps[i].GetComponent<Chase>();
        }
    }

    void Start()
    {
        currentHealth = startingHealth;
    }

    void Update()
    {

        if(currentHealth <= 0)
        {
            Debug.Log("PlayerHealth - Player has died! Respawning...");
            player.transform.position = respawnPoint.transform.position;
            gameObject.GetComponent<Score>().playerDeathCount();
            currentHealth++;
            FindObjectOfType<AudioManager>().Play("SmokeBomb");
            Instantiate(smokeBomb, transform.position, Quaternion.identity);
        }
    }

    public void LateUpdate()
    {
        /*if(currentHealth <= 0)
        {
            Debug.Log("PlayerHealth - Mass disabling of Chase");
            foreach (Chase script in chaseArray)
            {
                script.enabled = false;
            }
        }*/
    }

    public void HurtPlayer(float damage)
    {
        Debug.Log("PlayerHealth - Player lost "+damage+" health");
        currentHealth -= damage;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Imp")
        {
            Debug.Log("PlayerHealth - Player collided with Imp");
            Debug.Log("PlayerHealth - Disabling chase");
            col.gameObject.GetComponentInParent<Chase>().enabled = false;
            col.gameObject.GetComponentInParent<ImpPatrol>().enabled = true;
        }
    }
}

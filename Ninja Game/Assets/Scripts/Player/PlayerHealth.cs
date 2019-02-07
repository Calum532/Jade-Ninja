using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 1;
    public static float currentHealth;
    public Transform player;
    public Transform respawnPoint;
    GameObject imp;
    public GameObject smokeBomb;

    private void Awake()
    {
        imp = GameObject.FindGameObjectWithTag("Imp");
    }

    void Start()
    {
        currentHealth = startingHealth;
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Debug.Log("Player has died! Respawning...");
            Instantiate(smokeBomb, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("SmokeBomb");
            player.transform.position = respawnPoint.transform.position;
            gameObject.GetComponent<Score>().playerDeathCount();
            currentHealth++;
            imp.GetComponent<ImpPatrol>().enabled = true;
            imp.GetComponent<Chase>().enabled = false;
        }
    }

    public void HurtPlayer(float damage)
    {
        Debug.Log("Player lost "+damage+" health");
        currentHealth -= damage;
    }
}

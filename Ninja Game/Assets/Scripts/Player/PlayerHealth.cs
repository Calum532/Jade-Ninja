using UnityEngine;
using UnityEngine.SceneManagement;

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
        imp = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
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

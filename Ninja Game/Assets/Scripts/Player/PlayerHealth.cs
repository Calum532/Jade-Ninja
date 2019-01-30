using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 1;
    public static int currentHealth;
    public Transform player;
    public Transform respawnPoint;
    GameObject imp;

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
            player.transform.position = respawnPoint.transform.position;
            gameObject.GetComponent<Score>().playerDeathCount();
            currentHealth++;
            imp.GetComponent<ImpPatrol>().enabled = true;
            imp.GetComponent<Chase>().enabled = false;
        }
    }

    public void HurtPlayer(int damage)
    {
        Debug.Log("Player lost 1 health");
        currentHealth -= damage;
    }
}

using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform player;
    public Transform respawnPoint;
    GameObject obj;
    GameObject imp;
    public GameObject smokeBomb;

    private void Awake()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
        imp = GameObject.FindGameObjectWithTag("Imp");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(smokeBomb, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("SmokeBomb");
            player.transform.position = respawnPoint.transform.position;
            obj.GetComponent<Score>().playerDeathCount();
            imp.GetComponent<ImpPatrol>().enabled = true;
            imp.GetComponent<Chase>().enabled = false;
        }
    }
}

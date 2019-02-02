using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform player;
    public Transform respawnPoint;
    GameObject obj;

    private void Awake()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.transform.position = respawnPoint.transform.position;
            obj.GetComponent<Score>().playerDeathCount();
        }
    }
}

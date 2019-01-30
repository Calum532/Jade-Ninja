using System.Collections;
using System.Collections.Generic;
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

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPoint.transform.position;
        //need to access component of player
        //gameObject.GetComponent<Score>().playerDeathCount();
        obj.GetComponent<Score>().playerDeathCount();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damage;

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit by Imp!");
            col.gameObject.GetComponent<PlayerHealth>().HurtPlayer(damage);
        }
    }
}

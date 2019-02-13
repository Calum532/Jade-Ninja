using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damage;
    GameObject imp;

    private void Awake()
    {
        imp = GameObject.FindGameObjectWithTag("Imp");
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("HurtPlayer - Player Hit by Imp!");
            col.gameObject.GetComponent<PlayerHealth>().HurtPlayer(damage);
            Debug.Log("HurtPlayer - Disable chase");
            GetComponentInParent<ImpPatrol>().enabled = true;
            GetComponentInParent<Chase>().enabled = false;
        }
    }
}

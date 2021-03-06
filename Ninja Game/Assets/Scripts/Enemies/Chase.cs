﻿using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    private Transform target;
    private GameObject player;
    private Rigidbody ImpRB;
    public GameObject parent;
    public NavMeshAgent agent;
    public GameObject spottedUI;
    Light lt;

    void Start()
    {
        //rotate the arms up
        parent.transform.GetChild(2).gameObject.transform.Rotate(-45f, 0f,0f);
        parent.transform.GetChild(4).gameObject.transform.Rotate(-45f, 0f, 0f);
        lt = GetComponent<Light>();

        ImpRB = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnEnable()
    {
        gameObject.GetComponent<EnemyImp>().currentHealth = 7;
        gameObject.GetComponent<EnemyImp>().health = gameObject.GetComponent<EnemyImp>().currentHealth;
        agent.speed = 15;
        spottedUI.SetActive(true);
        Debug.Log("Chase - Chase Enabled");
        FindObjectOfType<AudioManager>().Play("ImpChase");
    }

    private void OnDisable()
    {
        gameObject.GetComponent<EnemyImp>().currentHealth = 1;
        gameObject.GetComponent<EnemyImp>().health = gameObject.GetComponent<EnemyImp>().currentHealth;
        spottedUI.SetActive(false);
        GetComponent<ImpPatrol>().enabled = true;
        Debug.Log("Chase - Enabling Patrol");
    }

    void Update()
    {
        transform.LookAt(target.transform.position);
        lt.color = Color.red;
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.transform.position);
    }
}

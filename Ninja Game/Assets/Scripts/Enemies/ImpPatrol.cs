using UnityEngine;
using UnityEngine.AI;

public class ImpPatrol : MonoBehaviour
{
    public float waitTime;
    public float startWaitTime;
    Light lt;
    public Transform[] moveSpots;
    private int randomSpot;
    public NavMeshAgent agent;
    private Transform target;
    GameObject imp;

    void Awake()
    {
        imp = GameObject.FindGameObjectWithTag("Imp");
    }

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        lt = GetComponent<Light>();
    }

    private void OnEnable()
    {
        imp.GetComponent<EnemyImp>().currentHealth = 1;
        imp.GetComponent<EnemyImp>().health = imp.GetComponent<EnemyImp>().currentHealth;
        agent.speed = 10;
    }

    void Update()
    {
        lt.color = Color.yellow;
    }

    private void FixedUpdate()
    {
        target = moveSpots[randomSpot];
        agent.SetDestination(moveSpots[randomSpot].transform.position);
        transform.LookAt(moveSpots[randomSpot]);

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    if (waitTime <= 0)
                    {
                        randomSpot = Random.Range(0, moveSpots.Length);
                        waitTime = startWaitTime;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
            }
        }
    }
}

using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    private Transform target;
    private GameObject player;
    private Rigidbody ImpRB;
    public GameObject parent;
    public NavMeshAgent agent;
    Light lt;
    public GameObject spottedUI;

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
        FindObjectOfType<AudioManager>().Play("ImpChase");
    }

    private void OnDisable()
    {
        spottedUI.SetActive(false);
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

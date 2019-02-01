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
    GameObject imp;
    public GameObject spottedUI;

    void Awake()
    {
        imp = GameObject.FindGameObjectWithTag("Enemy");
    }

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
        imp.GetComponent<EnemyImp>().currentHealth = 7;
        imp.GetComponent<EnemyImp>().health = imp.GetComponent<EnemyImp>().currentHealth;
        agent.speed = 15;
        spottedUI.SetActive(true);
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

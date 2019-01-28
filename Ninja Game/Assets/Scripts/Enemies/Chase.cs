using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    public float speed;
    private Transform target;
    private GameObject player;
    private Rigidbody ImpRB;
    public GameObject parent;
    public NavMeshAgent agent;
    public int healthGained;

    // Start is called before the first frame update
    void Start()
    {
        //rotate the arms up
        parent.transform.GetChild(2).gameObject.transform.Rotate(-45f, 0f,0f);
        parent.transform.GetChild(4).gameObject.transform.Rotate(-45f, 0f, 0f);

        ImpRB = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        gameObject.GetComponent<EnemyImp>().Enrage(healthGained);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform.position);   
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.transform.position);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}

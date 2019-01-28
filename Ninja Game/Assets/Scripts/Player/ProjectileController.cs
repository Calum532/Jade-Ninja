using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public int damageDealt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Debug.Log("Arrow hit!");
            col.gameObject.GetComponent<EnemyImp>().HurtEnemy(damageDealt);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Untagged")
        {
            Debug.Log("Arrow Collision");
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Untagged")
        {
            Debug.Log("Arrow Collision");
            Destroy(gameObject);
        }
    }
}

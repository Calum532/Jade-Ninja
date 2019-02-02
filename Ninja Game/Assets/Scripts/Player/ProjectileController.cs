using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;
    public float lifetime;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(gameObject);
            player.GetComponent<Score>().arrowMissedCount();
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy hit!");
            col.gameObject.GetComponent<EnemyImp>().HurtEnemy();
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Untagged")
        {
            Debug.Log("Arrow collision!");
            Destroy(gameObject);
            player.GetComponent<Score>().arrowMissedCount();
        }
    }
}

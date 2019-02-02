using UnityEngine;
using TMPro;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCountText;
    public int coinCount = 0;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            player.GetComponent<Score>().coinsCollectedCount();
            coinCount = coinCount + 1;
            coinCountText.text = coinCount.ToString() + "/5";
            Destroy(gameObject);
        }
    }
}

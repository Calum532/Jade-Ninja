using UnityEngine;
using TMPro;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCountText;
    GameObject player;
    public GameObject pickUpEffect;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            FindObjectOfType<AudioManager>().Play("CoinPickUp");
            player.GetComponent<Score>().coinsCollectedCount();
            coinCountText.text = player.GetComponent<Score>().coinsCollected.ToString() + "/5";
            if (coinCountText.text == "5/5")
            {
                coinCountText.faceColor = new Color32(255, 215, 0, 255);
            }
            Destroy(gameObject);
            Instantiate(pickUpEffect, transform.position, Quaternion.identity);
        }
    }
}

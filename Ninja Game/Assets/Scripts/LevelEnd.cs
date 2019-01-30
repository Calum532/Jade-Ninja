using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            gameManager.CompleteLevel();
        }
    }
}

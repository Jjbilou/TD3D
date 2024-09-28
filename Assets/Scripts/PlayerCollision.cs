using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    string monsterTag;

    void Start()
    {
        monsterTag = "Monster";
    }

    void OnCollisionEnter(Collision collision)
    {
        print(collision);
        if (collision.gameObject.CompareTag(monsterTag))
        {
            Destroy(gameObject);
        }
    }
}

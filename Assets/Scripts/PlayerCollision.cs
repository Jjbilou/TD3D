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
        if (collision.transform.parent.CompareTag(monsterTag))
        {
            Destroy(gameObject);
        }
    }
}

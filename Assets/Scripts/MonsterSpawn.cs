using System.Collections;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] GameObject monster;

    readonly float spawnInterval = 5.0f;

    void Start()
    {
        StartCoroutine(SpawnCycle(spawnInterval));

    }

    IEnumerator SpawnCycle(float interval)
    {
        yield return new WaitForSeconds(5.0f);

        while (true)
        {
            Instantiate(monster, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(interval);
        }
    }
}

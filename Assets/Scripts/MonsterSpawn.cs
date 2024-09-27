using System.Collections;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] GameObject baseMonster;

    void Start()
    {
        SpawnMonsters(5, 5.0f, "baseMonster");
    }

    public void SpawnMonsters(int number, float interval, string monsterName)
    {
        switch (monsterName)
        {
            default:
                StartCoroutine(SpawnEnumerator(number, interval, baseMonster));
                break;
        }
    }

    IEnumerator SpawnEnumerator(int number, float interval, GameObject monster)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(monster, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(interval);
        }
    }
}

using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    Transform arrival;
    NavMeshAgent navMeshAgent;

    void Start()
    {
        arrival = GameObject.Find("Arrival").transform;
        navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.destination = arrival.position;
    }
}

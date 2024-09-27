using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    Transform arrival;
    NavMeshAgent navMeshAgent;
    readonly float stoppingDistance = 0.01f;

    void Start()
    {
        arrival = GameObject.Find("Arrival").transform;
        navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.destination = arrival.position;
        navMeshAgent.stoppingDistance = stoppingDistance;

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)
        {
            Destroy(gameObject);
        }
    }
}

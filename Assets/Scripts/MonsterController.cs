using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    Transform player;
    Transform arrival;
    NavMeshAgent navMeshAgent;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        arrival = GameObject.Find("Arrival").transform;
        navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Vector2 position2D = new(transform.position.x, transform.position.z);
        // float playerDistance = Vector2.Distance(new(player.position.x, player.position.z), position2D);
        // float arrivalDistance = Vector2.Distance(new(arrival.position.x, arrival.position.z), position2D);

        navMeshAgent.destination = arrival.position;
    }
}

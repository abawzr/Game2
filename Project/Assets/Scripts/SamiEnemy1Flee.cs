using UnityEngine;

public class SamiEnemy1Flee : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;


    [SerializeField]private Transform player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 directionAwayFromPlayer = transform.position - player.position;

        Vector3 fleePosition = transform.position + directionAwayFromPlayer.normalized * 10f;

        agent.SetDestination(fleePosition);
    }
}

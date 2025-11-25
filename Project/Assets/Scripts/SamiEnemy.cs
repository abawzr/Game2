using UnityEngine;

public class SamiEnemy : MonoBehaviour
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

        agent.SetDestination(player.position);
    }
}

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MohammedFollowPlayerScript : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    [SerializeField] private Transform _playerLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyAgent.SetDestination(_playerLocation.position);
    }
}

using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float detectRange;
    [SerializeField] private List<Transform> patrolPoints;

    private NavMeshAgent _navMeshAgent;
    private int _currentPatrolPoint = 0;
    private bool _isChasing;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _navMeshAgent.SetDestination(patrolPoints[0].position);
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectRange)
        {
            _isChasing = true;
        }
        else if (distance > detectRange)
        {
            _isChasing = false;
        }

        if (_isChasing)
        {
            _navMeshAgent.SetDestination(player.position);
        }

        else
        {
            if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.25f)
            {
                NextPoint();
            }
        }
    }

    private void NextPoint()
    {
        if (patrolPoints.Count == 0) return;

        _currentPatrolPoint = (_currentPatrolPoint + 1) % patrolPoints.Count;
        _navMeshAgent.SetDestination(patrolPoints[_currentPatrolPoint].position);
    }
}

using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_chasingOnly : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject objectP;
    [SerializeField] private float detectRange;

    private NavMeshAgent _navMeshAgent;
    private bool _isChasing;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeathTouch"))
        {
            Destroy(objectP);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<Transform> PatrolPos;
    [SerializeField] int PatrolPosIndex = 0;
    [SerializeField] float CoolDownTime = 1;
    [SerializeField] float Damage;
    [SerializeField] GameObject Player;

    private NavMeshAgent _agent;
    private float _currentTime = 0;
    private bool _isChasingPlayer = false;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _agent.destination = PatrolPos[PatrolPosIndex].position;
    }

    private void Update()
    {

        _currentTime += Time.deltaTime;

        if (_isChasingPlayer)
        {
            _agent.destination = Player.transform.position;
        }

        if (!_agent.pathPending && _agent.remainingDistance < _agent.stoppingDistance + 0.25f && _currentTime >= CoolDownTime)
        {
            PatrolPosIndex = (PatrolPosIndex + 1) % PatrolPos.Count;
            _agent.destination = PatrolPos[PatrolPosIndex].position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isChasingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isChasingPlayer = false;
            _currentTime = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player.GetComponent<HealthManager>().TakeDamage(Damage);
    }
}

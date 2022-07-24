using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

    
public class MoveTo : MonoBehaviour 
{
    [SerializeField]
    List<WaypointScript> _patrolPoints;
    
    bool _travelling;
    bool _waiting;
    bool _patrolWaiting;
    bool _patrolForward = true;
    int _currentPatrolIndex;
    float _waitTimer;

    public float _switchProbability = 0.8f;
    public float _totalWaitTime = 5f;

    NavMeshAgent _navMeshAgent;

    
    public void Start () 
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("This nave mesh component is not attached to" + gameObject.name);
        }
        else
        {
            if (_patrolPoints != null && _patrolPoints.Count >= 2)
            {
                // Debug.Log("It's working!");
                _currentPatrolIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.LogError("Not enough patrol points to model AI behaviour.");
            }
        }
    }

    public void Update()
    {
        if (_travelling && _navMeshAgent.remainingDistance <= 5.0f)
        {
            _travelling = false;
            
            if (_patrolWaiting)
            {
                _waiting = true;
                _waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        if (_waiting)
        {
            _waitTimer += Time.deltaTime;
            if (_waitTimer >= _totalWaitTime)
            {
                _waiting = false;

                ChangePatrolPoint();
                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if (_patrolPoints != null)
        {
            Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
            _navMeshAgent.SetDestination(targetVector);

            _navMeshAgent.destination = _patrolPoints[_currentPatrolIndex].transform.position;

            _travelling = true;
        }
    }

    private void ChangePatrolPoint()
    {
        float randomProbability = UnityEngine.Random.Range(0f, 1f);
        bool activeGo = randomProbability < _switchProbability;
        Debug.Log(randomProbability.ToString() + " " + activeGo.ToString());
        
        if (activeGo)
        {
            _patrolForward = !_patrolForward;
        }

        if (_patrolForward)
        {
            Debug.Log("Going forward!");
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count;
        }
        else
        {
            Debug.Log("Going backward!");
            if (--_currentPatrolIndex < 0)
            {
                _currentPatrolIndex = _patrolPoints.Count - 1;
            }
        }
    }
}
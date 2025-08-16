using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterNavMesh : MonoBehaviour
{
    public static CharacterNavMesh instance;

    NavMeshAgent agent;

    Vector3 target;

    bool thereIsAItem;

    public bool ThereIsAItem { get => thereIsAItem;
        set 
        {
            thereIsAItem = value;
            if (value)
                StartCoroutine(IsWalkingToItem());
        } 
    }

    public Action isTheCharacterStop;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            agent.SetDestination(target);
        }
    }

    public IEnumerator IsWalkingToItem()
    {
        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance || agent.velocity.magnitude != 0)
        {
            yield return new WaitForEndOfFrame();
        }

        
        Debug.Log("Recogiendo Item");
        isTheCharacterStop?.Invoke();
    }
}

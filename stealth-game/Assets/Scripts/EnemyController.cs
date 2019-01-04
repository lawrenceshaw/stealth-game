using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private NavAgent navAgent;

    // Start is called before the first frame update
    private void Start()
    {
        navAgent = GetComponent<NavAgent>();
        navAgent.SetTarget(new Vector2(0, 5));
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
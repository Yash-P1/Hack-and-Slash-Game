using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{

    public Animator animator;

    private NavMeshAgent navMesh;

    private bool moving = false;

    private string groundTag = "Ground";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                navMesh.destination = hit.point;
            }
        }

        if (navMesh.remainingDistance <= navMesh.stoppingDistance)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }

        animator.SetBool("moving", moving);
    }
}

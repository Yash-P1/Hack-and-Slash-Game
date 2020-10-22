using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBehaviour : MonoBehaviour
{
    private Transform player;
    private float dist;
    public float howclose;

    public Animator animator;
    Rigidbody rig;
    private Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);

        if (dist <= howclose && dist > 1.5)
        {
            animator.SetBool("inRange", true);
            Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);
            Vector3 pos = Vector3.MoveTowards(transform.position, player.position, 3f * Time.fixedDeltaTime);
            rig.MovePosition(pos);
        }
        else if (dist < 1.5)
        {
            animator.SetBool("attack", true);
        }else
        {
            animator.SetBool("attack", false);
            animator.SetBool("inRange", false);
        }

        
    }
}

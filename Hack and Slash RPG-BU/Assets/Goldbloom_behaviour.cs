using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goldbloom_behaviour : MonoBehaviour
{
    private Transform player;
    public Text questInfo;
    private float dist;
    public float movespeed;
    public float howclose;

    public Animator animator;
    private bool near = false;

    // Start is called before the first frame update
    void Start()
    {
        //player tag should be "Player" or else change the tag in line below
        player = GameObject.FindGameObjectWithTag("Player").transform; 

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);

        if(dist <= howclose){
            //transform.LookAt(player);
            Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);
            //GetComponent<Rigidbody>().AddForce(transform.forward * movespeed);
            near = true;
        }else{
            near = false;
        }
        animator.SetBool("isNear", near);
        if(near){
            questInfo.text = "Find and kill Goblin.";
            }
        

        //for melee attach or explode
        if(dist <= 1.5f){
            //make godbloom do things
        }
    }
}

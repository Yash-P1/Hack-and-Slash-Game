using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthGoblin : MonoBehaviour
{
    public Text questInfo;
    public float health;
    public Animator animator;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
        if(health <= 0){
            Debug.Log("Dead");
            animator.SetBool("isDead", true);
            questInfo.text = "Go to Goldbloom, collect the reward.";
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            
            health = health - 3f;
        }
    }
}

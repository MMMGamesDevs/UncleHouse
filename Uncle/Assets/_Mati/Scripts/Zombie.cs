using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    int HP = 100;
    public Slider healthBar;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(healthBar != null) healthBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            //AudioManager.instance.Play("DragonDeath");
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            //AudioManager.instance.Play("DragonDamage");
            animator.SetTrigger("damage");
        }
    }
}

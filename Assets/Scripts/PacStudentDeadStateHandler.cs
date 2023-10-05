using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentDeadStateHandler : MonoBehaviour
{
    void Start()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isDead", true);
    }
}

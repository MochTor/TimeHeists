using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShatterUlti : MonoBehaviour
{
    private Animator animator;
    private Collider ultiTrigger;
    public GameObject sword;

    void Start()
    {
        animator = GetComponent<Animator>();
        //ultiTrigger = sword.gameObject.GetComponent<Collider>;
    }

    // Update is called once per frame
    void Update()
    {
        //if (CrossPlatformInputManager.GetButtonDown("Ulti"))
        if (Input.GetKeyDown("q"))
        {
            animator.SetTrigger("isUlting");
        }
    }
}

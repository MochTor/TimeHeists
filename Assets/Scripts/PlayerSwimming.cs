using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwimming : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Animator animator = other.GetComponent<Animator>();
            other.gameObject.GetComponent<CharacterController>().height = 0.4f;
            if (other.gameObject.GetComponent<CharacterController>().velocity.magnitude > 0)
            {
                //other.gameObject.GetComponent<CharacterController>().center = new Vector3(0.0f, 0.0f, 0.0f);
                animator.SetBool("isSwimmingIdle", false);
                animator.SetBool("isSwimming", true);
            }
            else
            {
                animator.SetBool("isSwimmingIdle", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Animator animator = other.GetComponent<Animator>();
            animator.SetBool("isSwimming", false);
            other.gameObject.GetComponent<CharacterController>().height = 1.82f;
            //other.gameObject.GetComponent<CharacterController>().center = new Vector3(0.0f, 0.92f, 0.0f);
        }
    }
}


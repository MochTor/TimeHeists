using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "RedFlag":
                if (this.gameObject.CompareTag("BlueSpawn"))
                {
                    //increase point and delete gizmo from player's
                    Debug.Log("Point for Red Team");
                }
                break;
            case "BlueFlag":
                if (this.gameObject.CompareTag("RedSpawn"))
                {
                    //increase point and delete gizmo from player's
                    Debug.Log("Point for Blue Team");
                }
                break;
        }
    }
}
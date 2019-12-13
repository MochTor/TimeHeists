using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSounds : MonoBehaviour {

    public AudioClip[] snowSteps;
    public AudioClip[] waterSteps;
    public AudioClip[] terrainSteps;

    public float groundDistance = 1.3f;

    private AudioSource playerAudio;
    private RaycastHit hitInfo;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    bool Grounded() {
        return Physics.Raycast(transform.position + Vector3.up * 0.5f, -Vector3.up, out hitInfo, groundDistance);
    }

    public void Footsteps() {
        int r;
        Grounded();
        switch (hitInfo.transform.gameObject.tag) {
            case "SnowTerrain":
                r = Random.Range(0, snowSteps.Length);
                playerAudio.PlayOneShot(snowSteps[r]);
                break;
        }
    }

}

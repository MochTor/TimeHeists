using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSetup : MonoBehaviour
{

    private bool _isInteractable = true;    //Controls if the boat has been taken under control by a player

    public bool IsInteractable
    {
        get { return _isInteractable; }
    }

    private GameObject _player;

    public GameObject _boatCamera;

    public Canvas takeBoatCommanCanvas;

    private BoatMotion BMScript;

    private MeshCollider _boatMeshCollider;
    private Rigidbody _boatRB;


    // Use this for initialization
    void Start()
    {
        takeBoatCommanCanvas.gameObject.SetActive(false);
        _boatCamera = this.gameObject.transform.GetChild(0).gameObject;
        _boatCamera.SetActive(false);
        BMScript = GetComponent<BoatMotion>();
        BMScript.enabled = false;
        _boatMeshCollider = GetComponent<MeshCollider>();
        _boatRB = GetComponent<Rigidbody>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_isInteractable)
            {
                print("Enters on boat");
                takeBoatCommanCanvas.gameObject.SetActive(true);
                _player = other.gameObject;
            }
            else
            {
                other.gameObject.transform.parent = gameObject.transform;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_isInteractable)
            {
                print("Exit on boat");
                takeBoatCommanCanvas.gameObject.SetActive(false);
            }
            other.gameObject.transform.parent = null;
        }
    }

    public void ActivateBoatNavigationView()
    {
        _isInteractable = false;
        takeBoatCommanCanvas.gameObject.SetActive(false);
        _player.transform.GetChild(0).gameObject.SetActive(false);
        _player.gameObject.transform.parent = gameObject.transform;
        _player.gameObject.GetComponent<CharacterController>().enabled = false;
        _player.gameObject.GetComponent<PlayerMotion>().enabled = false;
        _boatCamera.SetActive(true);
        _boatMeshCollider.convex = true;
        BMScript.enabled = true;
        _boatRB.isKinematic = false;
    }

    public void DeactivateBoatNavigationView()
    {
        _isInteractable = true;
        takeBoatCommanCanvas.gameObject.SetActive(true);
        _player.transform.GetChild(0).gameObject.SetActive(true);
        _player.gameObject.transform.parent = null;
        _player.gameObject.GetComponent<CharacterController>().enabled = true;
        _player.gameObject.GetComponent<PlayerMotion>().enabled = true;
        _boatCamera.SetActive(false);
        _boatMeshCollider.convex = false;
        BMScript.enabled = false;
        _boatRB.isKinematic = true;
    }
}

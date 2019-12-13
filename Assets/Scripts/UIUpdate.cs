using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour {

    public Text healthValues;
    public Slider healthSlider;
    private CharacterStats characterStats; 

	// Use this for initialization
	void Start () {
        characterStats = GetComponent<CharacterStats>();
        healthSlider.maxValue = characterStats.GetMaxHealth();
	}
	
	// Update is called once per frame
	void Update () {
        healthValues.text = characterStats.GetHealth() + " / " + characterStats.GetMaxHealth();
        healthSlider.value = characterStats.GetHealth();
		
	}
}

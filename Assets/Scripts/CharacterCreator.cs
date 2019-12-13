using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterCreator : MonoBehaviour
{
    public GameObject positionPlaceholder;
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateViking()
    {
        //GameObject character = Resources.Load("Assets/Resources/VikingCharacters/Character_Chief_01_Black.prefab") as GameObject;
        //character.transform.localPosition = position.transform.position;
        GameObject instantiateCharacter = Instantiate(character, positionPlaceholder.transform.position, positionPlaceholder.transform.rotation);
        instantiateCharacter.transform.localScale = positionPlaceholder.transform.localScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int index = 0;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(characters[index], transform.position, Quaternion.identity);
        characters[index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            characters[index].SetActive(false);
            index++;
            if (index >= characters.Length)
            {
                index = 0;
            }
            characters[index].SetActive(true);
        }
    }    
}

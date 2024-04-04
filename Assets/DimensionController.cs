using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionController : MonoBehaviour
{
    public bool next;
    bool first = true;
    List<GameObject> fragments;


    private void Start()
    {
        fragments = new();
    }
    // Update is called once per frame
    void Update()
    {
        if (first)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                fragments.Add(gameObject.transform.GetChild(i).gameObject);
            }
            first = false;
        }

        if (next && fragments.Count > 1)
        {
            fragments.RemoveAt(0);
            fragments[0].gameObject.SetActive(true);
            next = false;
        }
    }
}

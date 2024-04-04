using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstateRandomly : MonoBehaviour
{
    public Transform pos;
    public GameObject[] objsInst;
    bool t = true;
    void Start()
    {
        StartCoroutine(Iniciar1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Iniciar1()
    {
        while (t)
        {
            yield return new WaitForSeconds(2);
            instanciarObj();
        }
    }

    public GameObject instanciarObj()
    {
        int n = Random.Range(0, objsInst.Length);
        GameObject obj = Instantiate(objsInst[n], pos.position, objsInst[n].transform.rotation);
        return obj;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Power : MonoBehaviour
{
    public UnityEvent onInstintBegin, onInstintFinished;
    public UnityEvent<float> onTimeChanged;
    bool isInstint, first = true;
    public IEnumerator cr;
    public bool finish;
    // Start is called before the first frame update
    private void Start()
    {
        cr = timeInstint();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)&& !finish)
        {
            isInstint = !isInstint;
            first = true;
        }


        if (first)
        {
            if (isInstint)
            {
                cr = timeInstint();
                onInstintBegin.Invoke();
                StartCoroutine(cr);
            }
            else
            {
                StopCoroutine(cr);
                onInstintFinished.Invoke();
            }
            first = false;
        }
    }

    public IEnumerator timeInstint()
    {
        onTimeChanged.Invoke(15);
        for (int i = 0; i < 15; i++)
        {
            onTimeChanged.Invoke(15-i);
            yield return new WaitForSeconds(1);
        }
        if (!finish)
        {
            isInstint = !isInstint;
            first = true;
        }
    }
}

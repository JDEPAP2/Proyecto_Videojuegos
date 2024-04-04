using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenManager : MonoBehaviour
{
    public string nombreS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeScene(string nombreS)
    {
        SceneManager.LoadScene(nombreS);
    }
}

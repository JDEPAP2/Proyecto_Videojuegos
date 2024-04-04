using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [ColorUsage(true, true)]
    public Color color;
    Color original;
    public float time = 1f,scale=1.5f;
    public VisualEffect vf;
    IEnumerator cor;
    bool changing = false;
    public Power pw;

    private void Start()
    {
        original = vf.GetVector4("Color");
        cor = hit();
    }
    // Update is called once per frame
    public IEnumerator hit()
    {
        vf.SetVector4("Color", color);
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, gameObject.transform.localScale + Vector3.forward, 1);
        vf.SetFloat("Size", 0.3f);
        changing = true;
        yield return new WaitForSeconds(2);
        vf.SetVector4("Color", original);
        vf.SetFloat("Size", 1.15f);
        changing = false;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Recolectables");
    }

    private void OnEnable()
    {
        if (cor != null)
        {
            StopCoroutine(cor);
            cor = hit();
        }
        if (changing)
        {
            vf.SetVector4("Color", original);
            vf.SetFloat("Size", 1.15f);
            changing = false;
        }
        pw.finish = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(cor);
        }
    }
}

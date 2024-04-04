using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mecEnemigo : MonoBehaviour
{
    public float rangoAlerta;
    public LayerMask capaJugador;
    bool estarAlerta;
    public Transform jugador;
    public float velocidad;
    bool atacar; 
    public float rangoAtaque;
    public Animator a;
    public int vidaEnemigo2=10;
    public Slider barraVidaE2;
    public int damage=2, cont=0;


    public logicaGolpes golpe;
    

    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position,rangoAlerta, 
        capaJugador);

        if(estarAlerta==true){
            
             transform.LookAt(new Vector3(jugador.position.x,
             transform.position.y,jugador.position.z));
             transform.position = Vector3.MoveTowards(transform.position,
             new Vector3(jugador.position.x,transform.position.y,
             jugador.position.z), velocidad*Time.deltaTime);

        }

        atacar = Physics.CheckSphere(transform.position,rangoAtaque, 
        capaJugador);

        if(atacar){           
            a.SetBool("atacar", true);
            cont++;
            if(cont == 55){
                golpe.golpe=true;
                cont = 0;
            }

        }else{
             a.SetBool("atacar", false);
             cont = 0;
             golpe.golpe=false;
        } 
        
        if(atacar && Input.GetKeyDown(KeyCode.Q)){
            a.SetBool("damage", true);
            Debug.Log("funciona");
        }
        else{
           
            a.SetBool("damage", false);
        }


        barraVidaE2.value = vidaEnemigo2;
        atacar = Physics.CheckSphere(transform.position,rangoAtaque, 
        capaJugador);
        if(Input.GetKeyDown(KeyCode.Q) && atacar)
        {
            vidaEnemigo2 -= damage;
        }

        if(vidaEnemigo2 <= 0){
            transform.gameObject.SetActive(false);
        }

        //if(vidaPersonaje <= 0){}
    


    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,rangoAlerta);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,rangoAtaque);
        
    }







}

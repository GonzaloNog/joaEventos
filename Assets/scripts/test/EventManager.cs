using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        Destroy(this);
    }
    public void Event(string a)
    {
        switch (a)
        {
            case "nota":  Nota();  break;
            case "boton": Boton(); break;
            case "botonNota": BotonNota(); break;

            default: print("Evento No Encontrado: " + a); break;
        }
    }
    private void Boton()
    {
        Debug.Log("Boton start");
        Animator anim = GameManager.instance.getInteractionObj().GetComponent<colliderBoton>().interaction.GetComponent<Animator>();
        
        anim.SetBool("anim", !anim.GetBool("anim"));
    }
    private void Nota()
    {
        GameManager.instance.GetUI().Nota(GameManager.instance.getInteractionObj().GetComponent<colliderBoton>().texto);
    }
    private void BotonNota()
    {
        Boton();
        Nota();
    }
}

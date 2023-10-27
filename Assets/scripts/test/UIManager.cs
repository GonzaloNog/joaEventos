using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject nota;
    public GameObject InteractionUI;

    public void Nota(string textoNota)
    {
        Debug.Log(textoNota);
        nota.GetComponent<Animator>().SetInteger("anim",1);
    }
    public void SetTip(bool set)
    {
        InteractionUI.SetActive(set);
    }
}

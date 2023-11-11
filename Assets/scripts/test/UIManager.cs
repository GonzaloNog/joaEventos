using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject nota;
    public GameObject InteractionUI;
    public TextMeshProUGUI notaText;
    public GameObject keyCounter;
    public GameObject idKeyCounter;

    public void Nota(string textoNota)
    {
        notaText.text = textoNota;
        nota.GetComponent<Animator>().SetInteger("anim",1);
    }
    public void SetTip(bool set)
    {
        InteractionUI.SetActive(set);
    }

    public void UpdateKeyCounter()
    {
        string texto = "Llaves: " + GameManager.instance.keys;
        keyCounter.GetComponent<TextMeshProUGUI>().text = texto;
    }
}
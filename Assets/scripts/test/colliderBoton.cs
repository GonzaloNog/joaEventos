using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class colliderBoton : MonoBehaviour
{
    public GameObject interaction;
    public string texto;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            GameManager.instance.GetUI().SetTip(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            GameManager.instance.GetUI().SetTip(false);
        }
    }
}

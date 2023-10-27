using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class colliderNota : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player") && Input.GetKey(KeyCode.E))
        {
            EventManager.instance.Event("nota");
        }
    }
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

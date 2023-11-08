using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class colliderBoton : MonoBehaviour
{
    public GameObject interaction;
    public string texto;

    public bool keyRecuest = false;

    
    public KeyID key;
    [System.Serializable]
    public struct KeyID
    {
        public int id;
        public bool on;
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
    public bool isOpen()
    {
        if (key.on)
        {
            if (GameManager.instance.isKeyInventori(key.id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(keyRecuest)
        {
            if (GameManager.instance.keys > 0)
            {
                GameManager.instance.keys--;
                keyRecuest = false;
                return true;
            }
            else
                return false;
        }
        else
            return true;
    }
}

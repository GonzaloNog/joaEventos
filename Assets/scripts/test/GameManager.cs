using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager UI;
    [SerializeField] private AnimManager Anim;
    public static GameManager instance;
    private GameObject interactionObj;

    [Header("keys")]
    public int keys = 0;
    public List<int> keysList = new List<int>();
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        Destroy(this);
    }
    public UIManager GetUI()
    {
        return UI;
    }
    public AnimManager GetAnimManager()
    {
        return Anim;
    }
    public GameObject getInteractionObj()
    {
        return interactionObj;
    }
    public void setInteractionObj(GameObject obj)
    {
        interactionObj = obj;
    }
    public bool isKeyInventori(int num)
    {
        return keysList.Contains(num);
    }
    public void addToKeyList(int id)
    {
        keysList.Add(id);
    }
}

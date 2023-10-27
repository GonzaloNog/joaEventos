using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class animGen : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }
    public void ToggleAnim()
    {
        if (anim.GetInteger("anim") == 1)
        {
            anim.SetInteger("anim",0);
        }
        else if (anim.GetInteger("anim") == 0)
        {
            anim.SetInteger("anim",0);
        }
    }
    public void PauseAnim()
    {
        
    }
    public void PrenderAnim()
    {
        anim.SetInteger("anim",1);
    }
    public void ApagarAnim()
    {
        anim.SetInteger("anim",0);
    }
}

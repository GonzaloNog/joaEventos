using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform[] points;
    public GameObject target;
    public float maxDistanceTarget;

    private bool isLive;
    private Rigidbody rb;
    private int idPoints = 0;
    public float speed;
    void Start()
    {
        isLive = true;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetTarget();
        float paso = speed * Time.deltaTime;
        rb.MovePosition(Vector3.MoveTowards(rb.position, GetTarget(), paso));

        if (rb.position == new Vector3(points[idPoints].position.x, rb.position.y, points[idPoints].position.z))
        {
            Debug.Log("Punto completado");
            if(idPoints >= points.Length -1)
                idPoints = 0;
            else
                idPoints += 1;
        }
    }
    public Vector3 GetTarget()
    {
        float distance = Vector3.Distance(rb.position,target.transform.position);
        if (distance < maxDistanceTarget)
            return target.transform.position;
        else
            return new Vector3(points[idPoints].position.x, rb.position.y, points[idPoints].position.z);
    }
}

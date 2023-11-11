using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    private GameObject eventoOBJ;
    private bool eventoIsOn = false;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            checkEvent();
        }
    }
    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("Entro");
            eventoIsOn = true;
            eventoOBJ = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("Salio");
            eventoIsOn = false;
            eventoOBJ = null;
        }
    }
    public void checkEvent()
    {
        if (eventoIsOn)
        {
            colliderBoton colBot = eventoOBJ.GetComponent<colliderBoton>();
            GameManager.instance.setInteractionObj(eventoOBJ);

            if (colBot.isOpen() || colBot.key.isKey /*tiene que haber una forma mejor*/)
            {
                if (colBot.key.on)
                {
                    EventManager.instance.Event(eventoOBJ.gameObject.tag, colBot.key.id);
                }
                else
                {
                    EventManager.instance.Event(eventoOBJ.gameObject.tag);
                }
            }
        }
        else
        {
            Debug.Log("Ningun Evento Detectado");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerI : MonoBehaviour
{
    private float rotation = 60f, moveVertical;
    private Animator anim;
    private InventoryController tools;

    [SerializeField] float speed = 8f;

    void Start()
    {
        anim = GetComponent<Animator>();
        tools = GetComponent<InventoryController>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotation();
    }

    private void Move()
    {
        moveVertical = Input.GetAxis("Vertical");
        transform.Translate(0, 0, moveVertical * Time.deltaTime * speed);
        anim.SetFloat("SpeedY", moveVertical);
    }

    private void Rotation()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, Time.deltaTime * -(rotation), 0.0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, Time.deltaTime * rotation, 0.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.CompareTag("Tool"))
         {
            GameObject instruments = other.gameObject;
            instruments.SetActive(false);
            tools.CountTool(instruments);
         }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject platform;
    Vector2 initialPosition;
    bool platformReturning;
    Rigidbody2D rb;

    private void Start()
    {
        //rb.GetComponent<Rigidbody2D>();
        initialPosition = this.transform.position;
    }

    private void Update()
    {
       // if (platformReturning)
            //transform.position = Vector2.MoveTowards(transform.position, initialPosition, 20f * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        platform.transform.position += platform.transform.up * Time.deltaTime;
        platformReturning = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //platformReturning = true;
        //transform.position = Vector2.MoveTowards(transform.position, initialPosition, 20f * Time.deltaTime);
        if (collision.CompareTag("Player"))
        this.transform.position = initialPosition;
    }
}

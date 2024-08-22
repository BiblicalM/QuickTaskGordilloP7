using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMovement;
    private Rigidbody2D rb;

    public float speed = 8;
    private float jumpForce = 14;
    public GameObject groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        transform.Translate(UnityEngine.Vector2.right * horizontalMovement * speed * Time.deltaTime);
        //rb.velocity = UnityEngine.Vector2.right * horizontalMovement * speed * Time.deltaTime;
        //rb.velocity.Set(horizontalMovement * speed * Time.deltaTime, 0);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new UnityEngine.Vector2(0, jumpForce) * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

}

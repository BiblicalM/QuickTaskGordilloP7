using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float horizontalMovement;
    private Rigidbody2D rb;
    private bool grounded;

    public GameObject scene;
    public float speed = 8;
    private float jumpForce = 7;

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

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(new UnityEngine.Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
        }

        if (transform.position.y < -4)
        {
            SceneManager.LoadScene(scene.name);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            UnityEngine.Vector3 normal = other.GetContact(0).normal;
            if (normal == UnityEngine.Vector3.up)
            {
                grounded = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}

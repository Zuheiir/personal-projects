using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int player = -1;
    public float speed = 10;
    PolygonCollider2D coll;
    BoxCollider2D boxcoll2d;
    Rigidbody2D rb;
    public Animator anim;

    List<List<KeyCode>> controls = new List<List<KeyCode>>{new List<KeyCode>{KeyCode.W, KeyCode.UpArrow}, new List<KeyCode>{KeyCode.A, KeyCode.LeftArrow}, new List<KeyCode>{KeyCode.D, KeyCode.RightArrow}, new List<KeyCode>{KeyCode.S, KeyCode.DownArrow}, new List<KeyCode>{KeyCode.Y, KeyCode.KeypadPlus}, new List<KeyCode>{KeyCode.U, KeyCode.KeypadMinus}};

    // Start is called before the first frame update
    void Start()
    {
        coll = gameObject.GetComponentInChildren<PolygonCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Jump", false);
        anim.SetBool("Movement", false);
        anim.SetBool("Crouch", false);
        
            if (Input.GetKey(controls[0][player]))  
            {
                rb.AddForce(new Vector2(0f, 2.5f), ForceMode2D.Impulse);
                anim.SetBool("Jump", true);
            }

            if (Input.GetKey(controls[3][player]))
            {
            } else {
                anim.SetBool("Crouch", true);
            }

            

            if (Input.GetKey(controls[1][player]))
            {
                rb.position -= new Vector2(transform.right.x, transform.right.y) * Time.deltaTime * speed;
                anim.SetBool("Movement", true);
            }

            if (Input.GetKey(controls[2][player]))
            {
                rb.position += new Vector2(transform.right.x, transform.right.y) * Time.deltaTime * speed;
                anim.SetBool("Movement", true);
            }
            
/*
        if (player == 1)
        {
            anim.SetBool("Movement", false);
            anim.SetBool("Crouch", false);
            if (Input.GetKey("w"))  
            {
                Debug.Log("WW");
                if (Input.GetButtonDown("Jump")) { }
                rb.AddForce(new Vector2(0f, 2.5f), ForceMode2D.Impulse);
            }

            if (Input.GetKey("s"))
            {
                anim.SetBool("Crouch", true);
            } else {
                anim.SetBool("Crouch", false);
            }

            

            if (Input.GetKey("a"))
            {
                rb.position -= new Vector2(transform.right.x, transform.right.y) * Time.deltaTime * speed;
                anim.SetBool("Movement", true);
            }

            if (Input.GetKey("d"))
            {
                rb.position += new Vector2(transform.right.x, transform.right.y) * Time.deltaTime * speed;
                anim.SetBool("Movement", true);
            }
            

        }
        else if(player == 2)
        {
            anim.SetBool("Movement", false);
            anim.SetBool("Crouch", false);
            if (Input.GetKey("up"))
            {
                Debug.Log("up arrow");
                if (Input.GetButtonDown("Jump")) { }
                rb.AddForce(new Vector2(0f, 2.5f), ForceMode2D.Impulse);
            }

            if (Input.GetKey("down"))
            {
                anim.SetBool("Crouch", true);
                print("down arrow key is held down");
            } else {
                anim.SetBool("Crouch", false);
            }
            else
            {

                if (Input.GetKey("left"))
                {
                    rb.position -= new Vector2(transform.right.x, transform.right.y) * Time.deltaTime * speed;
                    anim.SetBool("Movement", true);
                    print("left arrow key is held down");
                }

                if (Input.GetKey("right"))
                {
                    rb.position += new Vector2(transform.right.x, transform.right.y) * Time.deltaTime * speed;
                    anim.SetBool("Movement", true);
                    print("right arrow key is held down");

                }
            }
        }
        */
    }

    private bool onGround() {
        float extraHeightText = 0.01f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxcoll2d.bounds.center, Vector2.down, boxcoll2d.bounds.extents.y + extraHeightText);
        Color rayColor;
        if (raycastHit.collider != null) {
            rayColor = Color.green;
        } else {
            rayColor = Color.red;
        }

        Debug.DrawRay(boxcoll2d.bounds.center, Vector2.down* (boxcoll2d.bounds.extents.y + extraHeightText));
        return raycastHit.collider != null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.collider.gameObject.name);
        print(collision.GetContact(0).point);
    }
}

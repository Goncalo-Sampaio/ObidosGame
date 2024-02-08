using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class movement2 : MonoBehaviour
{

    [SerializeField]
    private float _playerSpeed = 3f;
    [SerializeField]
    private float _jumpHeight = 3f;
    [SerializeField]
    private float _gravityValue = -9.81f;
    private float _playerBorder;
    private bool move_right = false;
    private bool move_left = false;
    private Rigidbody2D rb;
    private Vector2 playerVelocity;
    private bool groundedPlayer = false;
    private bool isClimbing = false;




    // Start is called before the first frame update
    void Start()
        
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        _playerBorder = GetComponent<Collider2D>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKey(KeyCode.A))
        {
            move_left = true;
            gameObject.transform.position += _playerSpeed * Time.deltaTime * new Vector3(-1, 0, 0);
            if (isClimbing)
            {
                gameObject.transform.position += _playerSpeed * Time.deltaTime * new Vector3(0, 3, 0);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            move_right = true;
            gameObject.transform.position += _playerSpeed * Time.deltaTime * new Vector3(1, 0,0);
            if (isClimbing)
            {
                gameObject.transform.position += _playerSpeed * Time.deltaTime * new Vector3(0, 3, 0);
            }
        }
        if (Input.GetKey(KeyCode.Space) && groundedPlayer == true && Physics2D.Raycast(transform.position, Vector2.down,_playerBorder+0.2f))
        {
            rb.AddForce(new Vector3(0, _jumpHeight, 0));
            groundedPlayer = false;
        }
        

       // playerVelocity.y += _gravityValue * Time.deltaTime;



    }

    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "ladder")
        {
            groundedPlayer = true;
        }
        if (collision.gameObject.tag == "ladder")
        {
            isClimbing = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ladder")
        {
            isClimbing = false;
        }
    }
}
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
    private Rigidbody2D player;
    private Vector2 playerVelocity;
    //private bool groundedPlayer = false;
    private bool isClimbing = false;
    private float direction = 0f;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;




    // Start is called before the first frame update
    void Start()
        
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        _playerBorder = GetComponent<Collider2D>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

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
       
        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * _playerSpeed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * _playerSpeed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, _jumpHeight);
        }



        // playerVelocity.y += _gravityValue * Time.deltaTime;



    }

    
    
   
}
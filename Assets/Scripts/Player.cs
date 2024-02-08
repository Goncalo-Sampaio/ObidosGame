using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private static Player instance = null;
    [SerializeField]
    private float _playerSpeed = 3f;
    [SerializeField]
    private float _jumpHeight = 3f;
    [SerializeField]
    private float _gravityValue = -9.81f;
    private bool move_right = false;
    private bool move_left = false;
    private Rigidbody2D rb;
    private Vector2 playerVelocity;
    private bool groundedPlayer;

    private bool _nearLibrarian = false;
    private GameManager _gameManager;
    private Animator _animator;
    private bool _jumping = false;
    private bool _falling = false;
    private bool _startFalling = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
        
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {       
        

        if (Input.GetKey(KeyCode.W) && _nearLibrarian)
        {
            GameObject.Find("Canvas").GetComponent<Canvas2>().InteractWithLibrarian();
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            move_left = true;
            gameObject.transform.position += _playerSpeed * Time.deltaTime * new Vector3(-1, 0, 0);
            _animator.SetBool("Walking", true);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            move_right = true;
            gameObject.transform.position += _playerSpeed * Time.deltaTime * new Vector3(1, 0,0);
            _animator.SetBool("Walking", true);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (Input.GetKey(KeyCode.Space) && groundedPlayer == true)
        {
            _animator.SetBool("Grounded", false);
            Debug.Log("Jump");
            _jumping = true;
            rb.AddForce(new Vector3(0, _jumpHeight, 0));
            _animator.SetTrigger("Jump");
            groundedPlayer = false;
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && groundedPlayer == true)
        {
            _animator.SetBool("Walking", false);
            _startFalling = true;
        }

        if (groundedPlayer == false &&  !_jumping && _startFalling)
        {
            _animator.SetBool("Grounded", false);
            _animator.SetTrigger("Falling");
        }

       // playerVelocity.y += _gravityValue * Time.deltaTime;

    }

    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {    
        /*if (collision.gameObject.tag == "floor")
        {
            groundedPlayer = true;
            Debug.Log("colision");
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Librarian")
        {
            _nearLibrarian = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Librarian")
        {
            _nearLibrarian = false;
            Debug.Log("exit");
        }
    }

    public void PlayerPositioner()
    {
        gameObject.transform.position = _gameManager.GetNewPosition();
        _startFalling = false;
    }

    public void Grounded()
    {
        groundedPlayer = true;

        if (_jumping == true || _falling == true)
        {
            _jumping = false;
            _falling = false;
            _animator.SetBool("Grounded", true);
        }
    }

    public void StayGrounded()
    {
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && groundedPlayer == true && !_jumping)
        {
            _animator.SetTrigger("Grounded");
        }
    }

    public void NotGrounded()
    {
        if (!_jumping)
        {
            _falling = true;
        }

        groundedPlayer = false;
    }


}
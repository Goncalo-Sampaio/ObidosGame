using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerForTesting : MonoBehaviour
{
    private static PlayerForTesting instance = null;
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
    [SerializeField]
    private GameObject Bridge;

    private bool _nearLibrarian = false;
    private bool _nearArea;
    private GameManager _gameManager;


    

    // Start is called before the first frame update
    void Start()

    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Bridge.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.W) && _nearArea)
        {
            Bridge.gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            move_left = true;
            gameObject.transform.position += _playerSpeed * Time.deltaTime * new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            move_right = true;
            gameObject.transform.position += _playerSpeed * Time.deltaTime * new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space) && groundedPlayer == true)
        {
            Debug.Log("Jump");
            rb.AddForce(new Vector3(0, _jumpHeight, 0));
            groundedPlayer = false;
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
        if (collision.gameObject.tag == "area")
        {
            _nearArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "area")
        {
            _nearArea = false;
            Debug.Log("exit");
        }
    }

   

    public void PlayerPositioner()
    {
        gameObject.transform.position = _gameManager.GetNewPosition();
    }

    public void Grounded()
    {
        groundedPlayer = true;
    }


}
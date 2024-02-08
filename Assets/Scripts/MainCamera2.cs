using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _bookShelf1;
    [SerializeField]
    private ParticleSystem _bookShelf1Particles;
    [SerializeField]
    private GameObject _bookShelf2;
    [SerializeField]
    private ParticleSystem _bookShelf2Particles;
    private GameManager _gameManager;
    private bool _moveEnabled = false;
    private bool _b1CanBeActivated = true;
    private bool _b2CanBeActivated = true;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _moveEnabled = _gameManager.CheckMoveEnabled();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.M) && _moveEnabled)
        {

            if (Input.GetMouseButtonDown(0))
            { // if left button pressed...
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider.gameObject == _bookShelf1 && _b1CanBeActivated)
                    {
                        Debug.Log(hit);
                        Debug.Log("hit");
                        _bookShelf1.GetComponent<Animation>().Play("Machine1");
                        _b1CanBeActivated = false;
                    }
                    else if (hit.collider.gameObject == _bookShelf2 && _b2CanBeActivated)
                    {
                        Debug.Log(hit);
                        Debug.Log("hit");
                        _bookShelf2.GetComponent<Animation>().Play("Machine1");
                        _b2CanBeActivated = false;
                    }
                }
            }
        }
  
        if(Input.GetKeyDown(KeyCode.M) && _moveEnabled && _b1CanBeActivated == true)
        {
            _bookShelf1Particles.Play();
        }

        if (Input.GetKeyUp(KeyCode.M) || _b1CanBeActivated == false)
        {
            _bookShelf1Particles.Stop();
        }

        if (Input.GetKeyDown(KeyCode.M) && _moveEnabled && _b2CanBeActivated == true)
        {
            _bookShelf2Particles.Play();
        }

        if (Input.GetKeyUp(KeyCode.M) || _b2CanBeActivated == false)
        {
            _bookShelf2Particles.Stop();
        }

    }
}

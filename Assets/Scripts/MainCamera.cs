using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _machine1;
    [SerializeField]
    private ParticleSystem _machine1Particles;
    private GameManager _gameManager;
    private bool _moveEnabled = false;
    private bool _m1CanBeActivated = true;
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
                    if (hit.collider.gameObject == _machine1 && _m1CanBeActivated)
                    {
                        Debug.Log(hit);
                        Debug.Log("hit");
                        _machine1.GetComponent<Animation>().Play("Machine1");
                        _m1CanBeActivated = false;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.M) && _moveEnabled && _m1CanBeActivated == true)
        {
            _machine1Particles.Play();
        }

        if (Input.GetKeyUp(KeyCode.M) || _m1CanBeActivated == false)
        {
            _machine1Particles.Stop();
        }

    }
}

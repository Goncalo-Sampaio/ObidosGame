using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
{
    [SerializeField]
    private bool _right = false;
    [SerializeField]
    private bool _top = false;
    [SerializeField]
    private bool _center = true;
    [SerializeField]
    private int _buildIndexToLoad = 0;
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _gameManager.SetNewPosition(_right, _top, _center);
            SceneManager.LoadScene(_buildIndexToLoad);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private Vector3 _spawnPosition = new Vector3(-5, -3, 0);
    private bool _moveEnabled = false;
    private List<int> _collectibles = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    private List<int> _collected = new List<int>();
    private int _typographyState = 0;
    private GameObject _player;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
        _player = GameObject.FindGameObjectWithTag("Player");
        _player.GetComponent<Player>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetNewPosition()
    {
        return _spawnPosition;
    }

    public void SetNewPosition(bool right, bool top, bool center)
    {
        if (center)
        {
            _spawnPosition = new Vector3(0, -3, 0);
        }
        else if (right == true)
        {
            if (top == true)
            {
                _spawnPosition = new Vector3(7.5f, 3.7f, 0);
            }
            else
            {
                _spawnPosition = new Vector3(7.5f, -3f, 0);
            }
        }
        else if (right == false)
        {
            if (top == true)
            {
                _spawnPosition = new Vector3(-7.5f, 3.7f, 0);
            }
            else
            {
                _spawnPosition = new Vector3(-7.5f, -3f, 0);
            }
        }
    }

    public bool IsCollected(int collectible)
    {
        if (_collected.Contains(collectible))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Collect(int collectible)
    {
        _collected.Add(collectible);
        _collectibles.Remove(collectible);
    }

    public void CollectM(int collectible)
    {
        _collected.Add(collectible);
        _collectibles.Remove(collectible);
        _typographyState = 2;
    }

    public void EnableMove()
    {
        _moveEnabled = true;
    }

    public int TypographyState()
    {
        return _typographyState;
    }

    public void ChangeTypographyState(int state)
    {
        _typographyState = state;
    }

    public void EnablePlayerMovement()
    {
        _player.GetComponent<Player>().enabled = true;
    }

    public void DisablePlayerMovement()
    {
        _player.GetComponent<Player>().enabled = false;
    }

    public bool CheckMoveEnabled()
    {
        return _moveEnabled;
    }
}

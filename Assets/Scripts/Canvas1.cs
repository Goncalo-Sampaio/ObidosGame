using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas1 : MonoBehaviour
{
    [SerializeField]
    private Animation _machine1;
    private bool _machine1Used = false;
    private GameManager _gameManager;
    private bool _moveEnable = false;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _moveEnable = _gameManager.CheckMoveEnabled();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void MoveMachine1()
    {
        _machine1.Play("Machine1");
        _machine1Used = true;
    }
}

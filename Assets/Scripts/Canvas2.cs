using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Canvas2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _startingText;
    [SerializeField]
    private GameObject _startingText1;
    [SerializeField]
    private GameObject _collectedM;
    [SerializeField]
    private GameObject _collectedM2;
    [SerializeField]
    private GameObject _moveTut;

    private GameManager _gameManager;
    private int _state = 0;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        _state = _gameManager.TypographyState();

        if (_state == 0)
        {
            _startingText.SetActive(true);
        }

        if (_state >=3)
        {
            _moveTut.SetActive(true);
        }

        //Typography();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Typography()
    {
        switch (_state)
        {
            case 0:
                _startingText.SetActive(true);
                break;
            case 2:
                _collectedM.SetActive(true);
                break;
        }
    }

    public void StartingText1()
    {
        _startingText.SetActive(false);
        _startingText1.SetActive(true);
    }

    public void DisableStartingText()
    {
        _startingText1.SetActive(false);
        _state = 1;

        _gameManager.ChangeTypographyState(_state);
        _gameManager.EnablePlayerMovement();
    }

    public void InteractWithLibrarian()
    {
        _gameManager.DisablePlayerMovement();

        switch (_state)
        {
            case 0:
                _startingText.SetActive(true);
                break;
            case 1:
                _startingText.SetActive(true);
                break;
            case 2:
                _collectedM.SetActive(true);
                break;
            default:
                _collectedM.SetActive(true);
                break;
        }
    }

    public void CollectedM2()
    {
        _collectedM.SetActive(false);
        _collectedM2.SetActive(true);
    }

    public void DisableM2()
    {
        _collectedM2.SetActive(false);
        _state = 3;

        _gameManager.ChangeTypographyState(_state);
        _gameManager.EnablePlayerMovement();
        _gameManager.EnableMove();
        _moveTut.SetActive(true);
    }

    public void EnableMoveTutorial()
    {
        _moveTut.SetActive(true);
    }
}

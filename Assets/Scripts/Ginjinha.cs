using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Ginjinha : MonoBehaviour
{
    [SerializeField]
    private int _itemId = 0;
    public int ginjinhas = 0;
    public Text textoGinjinha;
    private bool isCounting;
    

    private GameManager _gameManager;

    private
    // Start is called before the first frame update
    void Start()
    {

         textoGinjinha.gameObject.SetActive(false);
        isCounting = false;


        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (_gameManager.IsCollected(_itemId))
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            ginjinhas += 1;



        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _gameManager.Collect(_itemId);
            gameObject.GetComponent<Renderer>().enabled = false;
            ginjinhas += 1;
            textoGinjinha.gameObject.SetActive(true);
            isCounting = true;
        }
    }
    IEnumerator waiter()
    {
     if (isCounting == true)
        {
            yield return new WaitForSecondsRealtime(3);
            gameObject.SetActive(false);
        }
        

    }
}

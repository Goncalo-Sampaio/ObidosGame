using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField]
    private int _itemId = 0;

    private GameManager _gameManager;

    private
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (_gameManager.IsCollected(_itemId))
        {
            Destroy(gameObject);
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

            StartCoroutine(AnimationCoroutine());
        }
    }

    IEnumerator AnimationCoroutine()
    {
        GetComponent<Animator>().SetTrigger("Picked");
        yield return new WaitForSeconds(0.83f);
        Destroy(gameObject);
    }
}

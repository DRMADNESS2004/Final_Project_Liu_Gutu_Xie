using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Trigger : MonoBehaviour
{

    [SerializeField]
    private GameObject gameScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
        Debug.Log("Character has entered trigger area.");
        gameScript.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Character has exited trigger area.");
        gameScript.SetActive(false);
    }
}

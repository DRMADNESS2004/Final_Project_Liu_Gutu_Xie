using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MazeEndpoint : MonoBehaviour
{
    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (!triggered && collision.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync("Map2");

            //isWon = true;
            Debug.Log("entered");
            triggered = true;
        }
    }

    void Update()
    {

    }

}
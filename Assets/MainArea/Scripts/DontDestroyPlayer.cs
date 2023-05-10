using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyPlayer : MonoBehaviour
{
    public static DontDestroyPlayer playerInstance;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerInstance.gameObject.SetActive(true);
    }
}

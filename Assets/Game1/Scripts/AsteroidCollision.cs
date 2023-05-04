using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public bool isCollided = false;

    [SerializeField]
    private GameObject missile;

    public AudioSource missileHit;

    
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
        onClick oc = GetComponent<onClick>();

        Debug.Log("MissileCollided");
        //isCollided = true;

        
        if (collision.gameObject.tag == "Missile")
        {
            missileHit.Play();
            isCollided = true;
            oc.ResetMissilePosition();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Missile Out");
        isCollided = false;

    }
}

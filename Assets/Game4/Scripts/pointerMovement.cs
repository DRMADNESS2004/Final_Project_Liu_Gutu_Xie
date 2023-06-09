using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointerMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float minX = -796f;
    public float maxX = 807f;

    private RectTransform rectTransform;

    public AudioSource unlocked;
    public AudioSource notunlocked;

    [SerializeField]
    private GameObject victoryCanvas;

    [SerializeField]
    private GameObject lockCanvas;

    // Start is called before the first frame update
    void Start()
    {
        // Get the RectTransform component of the pointer object
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new position of the pointer
        float newX = Mathf.PingPong(Time.time * speed, maxX - minX) + minX;

        // Update the position of the pointer
        rectTransform.anchoredPosition = new Vector2(newX, rectTransform.anchoredPosition.y);

        OnMouseDown();
    }

    private void OnMouseDown()
    {
        // Get the current position of the pointer
        if (Input.GetMouseButtonDown(0))
        {
            float currentX = rectTransform.anchoredPosition.x;
            Debug.Log(currentX);
            //check if it's in the green zone
            if (currentX > -796.0f && currentX < -760.0f)
            {
                Debug.Log("correct");
                unlocked.Play();
                victoryCanvas.SetActive(true);
                lockCanvas.SetActive(false);

            }
            else
            {
                Debug.Log("incorrect");
                notunlocked.Play();

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnim : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _textMeshPro;

    public string[] stringArray;

    float timeBtwnChars = .3f;

    float timeBtwnWords = .5f;

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        EndCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //check if theres more chars
    void EndCheck()
    {
        if (i <= stringArray.Length - 1)
        {
            _textMeshPro.text = stringArray[i];
            StartCoroutine(TextVisible());
        }
    }

    private IEnumerator TextVisible()
    {
        _textMeshPro.ForceMeshUpdate();
        int totalVisibleChars = _textMeshPro.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (totalVisibleChars + 1);
            _textMeshPro.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleChars)
            {
                i++;
                Invoke("EndCheck", timeBtwnChars); break;
            }

            counter++;
            yield return new WaitForSeconds(timeBtwnChars);
        }
    }
}

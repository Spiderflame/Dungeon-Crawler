using UnityEngine;
using TMPro;
using System.Collections;

public class DialougeScript : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject BG;
    public string[] lines;
    public float textSpeed;

    private int index;

    public bool textDone;
    private bool isTyping;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void DisplayMessage(string[] message)
    {
        StopAllCoroutines();
        index = 0;
        lines = message;
        textDone = false;
        BG.SetActive(true);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {        
        textComponent.text = string.Empty;
        isTyping = true;

        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textDone = true;
            BG.SetActive(false);
        }
    }

    public bool getTextDone()
    {
        return textDone;
    }
}

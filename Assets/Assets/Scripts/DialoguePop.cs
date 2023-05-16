using System.Collections;
using UnityEngine;
using TMPro;

public class DialoguePop : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string dialogueLines;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = dialogueLines;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 256; i -= 2)
        {
            dialogueText.color = new Color(97, 255, 111, i);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialoguePanel.SetActive(true);
    }
}

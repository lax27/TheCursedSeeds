using System.Collections;
using UnityEngine;
using TMPro;

public class DialoguePop : MonoBehaviour
{
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text DialogueText;
    [SerializeField, TextArea(4, 6)] private string DialogueLines;

    // Start is called before the first frame update
    void Start()
    {
        DialogueText.text = DialogueLines;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 256; i -= 2)
        {
            DialogueText.color = new Color(97, 255, 111, i);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialoguePanel.SetActive(true);



    }
}

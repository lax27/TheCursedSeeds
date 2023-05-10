using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WeaponNull : MonoBehaviour
{
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text DialogueText;
    [SerializeField, TextArea(4, 6)] private string[] DialogueLines;
    public GameObject weapon;
    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private int counter;
    // Update is called once per frame
    void Update()
    {
        if (weapon == null && counter != 1)
        {
            
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (DialogueText.text == DialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                DialogueText.text = DialogueLines[lineIndex];
                counter++;
            }

        }
    }
    private void StartDialogue()
    {
        didDialogueStart = true;
        DialoguePanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < DialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            DialoguePanel.SetActive(false);
        }
    }


    private IEnumerator ShowLine()
    {
        DialogueText.text = string.Empty;

        foreach (char ch in DialogueLines[lineIndex])
        {
            DialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
}

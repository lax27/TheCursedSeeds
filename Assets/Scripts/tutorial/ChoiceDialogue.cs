using System.Collections;
using UnityEngine;
using TMPro;

public class ChoiceDialogue : MonoBehaviour
{
    [SerializeField] private GameObject exclamation;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text DialogueText; 
    [SerializeField, TextArea(4, 6)] private string[] DialogueLines;
    [SerializeField] private GameObject mantee;
    [SerializeField] private Pmove movement;
    [SerializeField] private GameObject itemToTake;


    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;

    float timer = 0.0f;
    float waitTime = 5.0f;
    private void Start()
    {
        mantee = GameObject.Find("mantee_v2");
        movement = mantee.GetComponent<Pmove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange && Input.GetButtonDown("interaction"))
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
            }
          
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        DialoguePanel.SetActive(true);
        exclamation.SetActive(false);
        lineIndex = 0;
        movement.enabled = false;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex == DialogueLines.Length)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                // Player chooses to take the item
                itemToTake.SetActive(true);
                DialogueText.text = "You took a seed. Look around to plant it";
       
                    // Do something after waiting for waitTime seconds
                    didDialogueStart = false;
                    DialoguePanel.SetActive(false);
                    exclamation.SetActive(true);
                    movement.enabled = true;
                

            }
            else if (Input.GetButtonDown("DENY"))
            {
                // Player chooses to leave the item
                DialogueText.text = "You left the item.";

                    // Do something after waiting for waitTime seconds
                    didDialogueStart = false;
                    DialoguePanel.SetActive(false);
                    exclamation.SetActive(true);
                    movement.enabled = true;
               

            }/*
        else if (lineIndex == 3)
        {
            // Player has made a choice
            if (Input.GetKeyDown(KeyCode.F))
            {
                // Player chooses to take the item
                itemToTake.SetActive(true);
                DialogueText.text = "You took a seed. Look around to plant it";
                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    // Do something after waiting for waitTime seconds
                    didDialogueStart = false;
                    DialoguePanel.SetActive(false);
                    exclamation.SetActive(true);
                    movement.enabled = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                // Player chooses to leave the item
                DialogueText.text = "You left the item.";
                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    // Do something after waiting for waitTime seconds
                    didDialogueStart = false;
                    DialoguePanel.SetActive(false);
                    exclamation.SetActive(true);
                    movement.enabled = true;
                }
            }
            else
            {
                // Player has not yet made a choice
                lineIndex--;
            }
        }
        else if (lineIndex < DialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            // Dialogue is complete
            didDialogueStart = false;
            DialoguePanel.SetActive(false);
            exclamation.SetActive(true);
            movement.enabled = true;
        }*/
        }
        else if (lineIndex < DialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            // Dialogue is complete
            didDialogueStart = false;
            DialoguePanel.SetActive(false);
            exclamation.SetActive(true);
            movement.enabled = true;
        }
    }

    private IEnumerator ShowLine()
    {
        DialogueText.text = string.Empty;

        foreach(char  ch in DialogueLines[lineIndex])
        {
            DialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            exclamation.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            exclamation.SetActive(false);

        }
    }
}
using System.Collections;
using UnityEngine;
using TMPro;

public class BossDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject mantee;
    [SerializeField] private PlayerMovement movement;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    public int count = 0;
    private bool isPrinted = false;
    // Start is called before the first frame update
    void Start()
    {
        mantee = GameObject.Find("mantee_v2");
        movement = mantee.GetComponent<PlayerMovement>();
        if (count == 0)
        {
            dialogueLines[0] = "count es 0";
            dialogueLines[1] = "Todo correcto";
        }
        else
        {
            dialogueLines[0] = "Esto ya ha pasado";
            dialogueLines[1] = "Como";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && !isPrinted)
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (Input.GetButtonDown("interaction"))
            {
                if (dialogueText.text == dialogueLines[lineIndex])
                {
                    NextDialogueLine();
                }
                else
                {
                    StopAllCoroutines();
                    dialogueText.text = dialogueLines[lineIndex];
                }
            }
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        movement.enabled = false;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            movement.enabled = true;
            isPrinted = true;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}

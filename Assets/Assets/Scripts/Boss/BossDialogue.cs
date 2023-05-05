using System.Collections;
using UnityEngine;
using TMPro;

public class BossDialogue : MonoBehaviour
{
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text DialogueText;
    [SerializeField] private GameObject mantee;
    [SerializeField] private PlayerMovement movement;
    [SerializeField, TextArea(4, 6)] private string[] DialogueLines;

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
            DialogueLines[0] = "count es 0";
            DialogueLines[1] = "Todo correcto";
        }
        else
        {
            DialogueLines[0] = "Esto ya ha pasado";
            DialogueLines[1] = "Como";
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
                 if (DialogueText.text == DialogueLines[lineIndex])
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



    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        DialoguePanel.SetActive(true);
        lineIndex = 0;
        movement.enabled = false;
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
            movement.enabled = true;
            isPrinted = true;
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

using System.Collections;
using UnityEngine;
using TMPro;

public class TeacherDialogue : MonoBehaviour
{
    [SerializeField] private GameObject exclamation;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text DialogueText;
    [SerializeField, TextArea(4, 6)] private string[] DialogueLines;
    [SerializeField] private GameObject mantee;
    [SerializeField] private Pmove movement;
    public GameObject Teacher;
    private SpriteRenderer t;
    private BoxCollider2D coll;

    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private bool TpActivate;
    private void Start()
    {
        mantee = GameObject.Find("Mantee_v2");
        t = Teacher.GetComponent<SpriteRenderer>();
        coll = Teacher.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("interaction"))
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
        if (lineIndex < DialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            DialoguePanel.SetActive(false);
            exclamation.SetActive(false);
            movement.enabled = true;
            t.enabled = false;
            coll.enabled = false;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;


        }
    }
}

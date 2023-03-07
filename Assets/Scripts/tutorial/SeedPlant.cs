using System.Collections;
using TMPro;
using UnityEngine;

public class SeedPlant : MonoBehaviour
{
    [SerializeField] private GameObject exclamation;
    [SerializeField] private GameObject exclamation_2;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text DialogueText;
    [SerializeField, TextArea(4, 6)] private string[] DialogueLines;
    [SerializeField] private GameObject mantee;
    [SerializeField] private Pmove movement;

    public GameObject Plant;
    private CircleCollider2D collider_2; 
    public GameObject PlantSecond;
    private CircleCollider2D second_Collider;
    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private void Start()
    {
        collider_2 = Plant.GetComponent<CircleCollider2D>();
        mantee = GameObject.Find("mantee_v2");
        movement = mantee.GetComponent<Pmove>();
        second_Collider = PlantSecond.GetComponent<CircleCollider2D>();

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
                exclamation.SetActive(false);
                movement.enabled = true;
                didDialogueStart = false;
                DialoguePanel.SetActive(false);
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
            movement.enabled = true;
            collider_2.enabled = false;
            second_Collider.enabled = false;
            exclamation_2.SetActive(false);
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

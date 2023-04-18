using UnityEngine;
using UnityEngine.UI;

public class DisplayImage : MonoBehaviour
{
    public float displayTime = 0.5f; // Time in seconds to display the image
    private GameObject image; // Reference to the Image component
    private Canvas myCanvas;
    private Renderer myRenderer;
    private float timer = 0.0f;
    public float duration = 3.0f;

    void Start()
    {
        // Get the Image component on this game object
        image = GameObject.Find("image"); 
        myRenderer = image.GetComponent<Renderer>();

        // Hide the image initially
       

        // Call the HideImage method after the specified display time has elapsed
     
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer <= duration)
        {
            // Do something when the timer has ended, e.g. disable a game object
            myRenderer.enabled = true;


        }
        else
        {
            myRenderer.enabled = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuoptions : MonoBehaviour
{
    //NOMBRE HA DE ESTAR EN MAYUS. YA HAY UN SCTIPT PARA EL VOLUMEN DEL MENU

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStart()
    {
        SceneManager.LoadScene(0);
    }

    public void Back()
    {
        SceneManager.LoadScene(2);
    }

    public void OnSettings()
    {
        SceneManager.LoadScene(1);

    }
}

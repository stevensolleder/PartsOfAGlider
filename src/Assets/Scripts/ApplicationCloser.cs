using UnityEngine;



public class ApplicationCloser : MonoBehaviour
{
    //Beenden der Anwendung mit ESC
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
}
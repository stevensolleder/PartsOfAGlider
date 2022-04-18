using UnityEngine;

public class TextToCameraRotator : MonoBehaviour
{ 
    //Rotieren des Textes zur Kamera
    private void Update() => gameObject.transform.rotation=Quaternion.Euler(0, 90* (Camera.main.transform.position.x > gameObject.transform.position.x?-1:1), 0);
}

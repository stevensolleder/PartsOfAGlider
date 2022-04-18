using UnityEngine;

public class SourcesDisplayer : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private int fontSize;
    [SerializeField] private Font font;
    
    //Anzeigen der Quelle
    private void OnGUI()
    {
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = fontSize;
        guiStyle.font = font;
        
        GUI.Label(new Rect(10, 10, 600, 30), text, guiStyle);
    }
}

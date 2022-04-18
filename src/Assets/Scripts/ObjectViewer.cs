using UnityEngine;



public sealed class ObjectViewer : MonoBehaviour 
{
    [SerializeField] private Transform viewedObject;
    [SerializeField] private float distanceToViewedObject = 10;
    [SerializeField] private float movementSpeedMultiplier = 1;

    [SerializeField] private GameObject explanation;
    
    private Vector3 lastPointerPositionOnViewPort;

    
    //Aufrufe vor dem ersten Frame
    private void Start()
    {
        LookAtViewedObject(new Vector3(0.5f, 0.5f, 0f));
        SetPosition();
    }

    //Aufrufe für einen Frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) lastPointerPositionOnViewPort = gameObject.GetComponent<Camera>().ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        else
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                LookAtViewedObject(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                SetPosition();
            }
        }

        Vector3 p = gameObject.transform.position;
        explanation.SetActive((-2 < p.x && p.x < 6) && (-3 < p.y && p.y < 5) && (-20 < p.z && p.z < -18));
    }

    
    //Rotieren der Kamera mit Blick auf viewedObject
    private void LookAtViewedObject(Vector3 currentPosition)
    {
        Vector3 newPosition = gameObject.GetComponent<Camera>().ScreenToViewportPoint(currentPosition);
        Vector3 direction = lastPointerPositionOnViewPort - newPosition;
        lastPointerPositionOnViewPort = newPosition;
                    
        gameObject.transform.Rotate(Vector3.right, direction.y *  180 * movementSpeedMultiplier);
        gameObject.transform.Rotate(Vector3.up, (direction.x * 180 * movementSpeedMultiplier) * -1, Space.World);
    }

    //Setzen der Position der Kamera
    private void SetPosition()
    {
        gameObject.transform.position = viewedObject.position;
        gameObject.transform.Translate(new Vector3(0, 0, -distanceToViewedObject));
    }
}
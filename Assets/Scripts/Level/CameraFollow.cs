using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float followAhead = 3.5f;
    public float minPosX;
    public float maxPosX;

    public Transform limitLeft;
    public Transform limitRight;

    public Transform colLeft;
    public Transform colRight;

    float camWidth;
    float lastPos;
    // Start is called before the first frame update
    void Start()
    {
        /*
        float camWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        Debug.Log("Ancho Camera: " + camWidth);
        float height = Camera.main.orthographicSize;
        Debug.Log("Camera.main.aspect: " + Camera.main.aspect);
        float width = height* Camera.main.aspect;
        Debug.Log("Otro Ancho: " + width);
        */
        camWidth = Camera.main.orthographicSize * Camera.main.aspect;
        minPosX = limitLeft.position.x + camWidth;
        //Debug.Log("Posicion min camara: " + minPosX);
        maxPosX = limitRight.position.x - camWidth;
        //Debug.Log("Posicion max camara: " + +minPosX);
        lastPos = minPosX;

        colLeft.position = new Vector2(transform.position.x - camWidth - 0.65f, colLeft.position.y);
        colRight.position = new Vector2(transform.position.x + camWidth + 0.65f, colRight.position.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        float newPosX = target.position.x + followAhead;
        newPosX = Mathf.Clamp(newPosX, lastPos, maxPosX);
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
        lastPos = newPosX;
    }
}

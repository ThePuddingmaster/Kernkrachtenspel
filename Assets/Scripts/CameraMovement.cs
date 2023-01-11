using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Touch firstTouch = new Touch();
    public Camera moveCam;

    private float rotateX = 0f;
    private float rotateY = 0f;
    private Vector3 originPoint;

    public float rotationSpeedX = 0.4f;
    public float rotationSpeedY = 0.2f;

    void Start()
    {
        originPoint = moveCam.transform.eulerAngles;
        rotateX = originPoint.x;
        rotateY = originPoint.y;
    }

    //Camera follows player
    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began) //When the finger first touches the screen
            {
                firstTouch = touch;
            }

            else if (touch.phase == TouchPhase.Moved) //While the finger is still on the screen
            {
                //Calculate new position
                float deltaX = firstTouch.position.x - touch.position.x;
                float deltaY = firstTouch.position.y - touch.position.y;

                rotateX -= deltaX * Time.deltaTime * rotationSpeedX;
                rotateY -= deltaY * Time.deltaTime * rotationSpeedY;

                //Put new positions into camera position -> Allow swiping camera
                moveCam.transform.eulerAngles = new Vector3(-rotateY, rotateX, 0f);
            }

            else if(touch.phase == TouchPhase.Ended) //When the finger leaves the screen
            {
                firstTouch = new Touch();
            }
        }
    }
}

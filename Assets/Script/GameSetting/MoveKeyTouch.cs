using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveKeyTouch : MonoBehaviour
{
    public GameObject CameraObj;
    private float cameraSpeed = 50f;
    Vector2 prePos = default;
    float distance = 0f;
    float distanceNow = 0f;
    Vector2 dir;
    Vector3 vec;

    private void Update()
    {
        Drag();
        DragExit();
    }

    public void Drag()
    {

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if(prePos == default)
            {
                prePos = Input.GetTouch(0).position;
                return;
            }
            dir = (Input.GetTouch(0).position - prePos).normalized;
            vec = new Vector3(dir.x, 0, dir.y);
            CameraObj.transform.position -= vec*cameraSpeed * Time.deltaTime;
            prePos = Input.GetTouch(0).position;
        }

        if(Input.touchCount == 2)
        {            
            if(distance == 0)
            {
                distance = (Input.GetTouch(0).position - Input.GetTouch(1).position).magnitude;
            }
            distanceNow = (Input.GetTouch(0).position - Input.GetTouch(1).position).magnitude;

            float MovePos = distanceNow - distance;
            Vector3 cameraYPos = CameraObj.transform.position;

            if(MovePos > 0)
            {
               cameraYPos.y -= cameraSpeed * Time.deltaTime;
            }

            if (MovePos < 0)
            {
                cameraYPos.y += cameraSpeed * Time.deltaTime;
            }

            distance = distanceNow;
            CameraObj.transform.position = cameraYPos;
        }
    }

    public void DragExit()
    {
        if (Input.touchCount == 0)
        {
            prePos = default;
            distance = 0f;
        }
    }




}

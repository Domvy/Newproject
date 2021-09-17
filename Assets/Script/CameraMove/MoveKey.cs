using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKey : MonoBehaviour
{
    public float cameraSpeed = 100f;
    public float cameraZoomSpeed = 100f;
    public Camera mainCamera;
    [Range(1,50)]
    private float distance;

    void Update()
    {
        if(Input.GetKey(KeyCode.A)) // 카메라 이동
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, 1) * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -1) * cameraSpeed * Time.deltaTime);
        }
        //if (Input.GetKey(KeyCode.Q)) // 카메라 회전
        //{
        //    transform.transform.Rotate(Vector3.down * cameraSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.transform.Rotate(Vector3.up * cameraSpeed * Time.deltaTime);
        //}
        Zoom(); //확대
    }

    private void Zoom()
    {
        distance = Input.GetAxis("Mouse ScrollWheel") * -1 * cameraZoomSpeed;        
        if (distance != 0)
        {
            mainCamera.fieldOfView += distance;
        }
    }
}

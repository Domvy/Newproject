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

    float x;
    float z;

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) // 카메라 이동
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
        float x = Mathf.Clamp(transform.position.x, -140, 60);
        float z = Mathf.Clamp(transform.position.z, -30, 60);
        transform.position = new Vector3(x, transform.position.y, z);
        

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

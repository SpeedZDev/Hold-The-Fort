using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public bool IsInFirstPerson;
    public Transform Player;
    public float SensX;
    public float SensY;
    float XRotation = 0;
    void Start()
    {
        if (IsInFirstPerson)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        float MouseX = Input.GetAxis("Mouse X") * SensX * Time.deltaTime;
        float MosueY = Input.GetAxis("Mouse Y") * SensY * Time.deltaTime;

        XRotation -= MosueY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        Player.Rotate(Vector3.up * MouseX);


    }
}

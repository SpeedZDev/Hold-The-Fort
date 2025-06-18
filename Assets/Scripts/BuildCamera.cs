using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildCamera : MonoBehaviour
{
    public float moveSpeed;
    
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed + Vector3.forward * Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;
        
    }


   
}

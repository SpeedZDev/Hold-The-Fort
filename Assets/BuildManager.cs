using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public bool IsInBuildMode;
    public Camera FpsCam;
    public Camera BuildCamera;
    public static BuildManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (IsInBuildMode)
            {
                IsInBuildMode = false;
            }
            else
            {
                IsInBuildMode = true;
            }
        }

        if (IsInBuildMode)
        {
            BuildCamera.enabled = true;
            FpsCam.enabled = false;
            
        }
        else
        {
            FpsCam.enabled = true;
            BuildCamera.enabled = false;
        }
    }
}

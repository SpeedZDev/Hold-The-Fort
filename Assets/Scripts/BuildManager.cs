using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public bool IsInBuildMode;
    public Camera FpsCam;
    public Camera BuildCamera;
    public static BuildManager instance;
    public LayerMask BuildableLayers;
    Vector3 LastPos;
    public GameObject MouseIndacator, CellIndacator;
    public Grid grid;
    public Camera BuildCam;

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
        if (IsInBuildMode)
        {
            Vector3 MosePos = GetSelectedMousePos();
            Vector3Int GridPos = grid.WorldToCell(MosePos);
            MouseIndacator.transform.position = MosePos;
            CellIndacator.transform.position = grid.CellToWorld(GridPos);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
           
            
            IsInBuildMode = !IsInBuildMode;

            if (IsInBuildMode)
            {
                BuildCamera.gameObject.SetActive(true);
                FpsCam.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                FpsCam.gameObject.SetActive(true);
                BuildCamera.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        
    }

    Vector3 GetSelectedMousePos()
    {
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = BuildCamera.nearClipPlane;
        Ray ray = BuildCam.ScreenPointToRay(MousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, BuildableLayers))
        {
            LastPos = hit.point;

            Debug.Log(hit.point);
        }
        return LastPos;
    }
}

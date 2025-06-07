using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    public int damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera cam = Camera.main;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 1.5f))
            {
                if (hit.transform.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    enemy.gameObject.GetComponent<Health>().health -= damage;
                }
            }
        }
    }
}

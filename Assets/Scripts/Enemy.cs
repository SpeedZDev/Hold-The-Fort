using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public GameObject Target;
    public float MovementSpeed;
    public float StoppingDistance;
    public int Damage;
    public float TimeBtwnAttacks;
    public float MaxTimeBtwnAttacks;
   
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        TimeBtwnAttacks -= Time.deltaTime;
       
        if(Target != null)
        {
            StoppingDistance = Target.transform.localScale.z + 0.5f;
            if (Vector3.Distance(transform.position, Target.transform.position) > StoppingDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z), MovementSpeed * Time.deltaTime);

            }

            if (Vector3.Distance(transform.position, Target.transform.position) <= StoppingDistance && TimeBtwnAttacks <= 0f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
                {
                    if (hit.transform.TryGetComponent<Health>(out Health health))
                    {
                        health.health -= Damage;
                    }
                }
                TimeBtwnAttacks = MaxTimeBtwnAttacks;
            }
        }

    }

    private void OnDestroy()
    {
        WaveManager.instance.AliveEnemies.Remove(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image bar;
    public TMP_Text HealthText;
    public int MaxHealth;
    void Start()
    {
        transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y + 1.5f, transform.parent.position.z);
        MaxHealth = transform.parent.GetComponent<Health>().health;
        HealthText = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        bar = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = transform.parent.GetComponent<Health>().health + "/" + MaxHealth;
        bar.fillAmount = (float)transform.parent.GetComponent<Health>().health / MaxHealth;
    }
}

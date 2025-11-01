using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public NewHealth newHealth;
    private float currH;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        currH = newHealth.currentHealth;
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = currH/10;
    }
}

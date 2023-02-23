using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{

    public static KillCounter instance;

    public TMP_Text killText;
    public int currentKill = 0;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        killText.text = "Kill : " + currentKill.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseKill(int v)
    {
        currentKill += v;
        killText.text = "Kill : " + currentKill.ToString();

    }
}

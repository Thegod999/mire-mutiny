using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      PlayerPrefs.SetFloat("Shot_Speed", 30);
      PlayerPrefs.SetFloat("Literal_Speed", 5);
      PlayerPrefs.SetFloat("Shot_Quickness", 40);
      PlayerPrefs.SetFloat("Shot_Life", 120);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

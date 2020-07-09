using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      PlayerPrefs.SetFloat("Shot_Speed", 30);
      PlayerPrefs.SetFloat("Literal_Speed", 4);
      PlayerPrefs.SetFloat("Shot_Quickness", 40);
      PlayerPrefs.SetFloat("Shot_Life", 120);
      PlayerPrefs.SetFloat("dash_Time", 30);
      PlayerPrefs.SetFloat("dash_anim_wait", 30);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

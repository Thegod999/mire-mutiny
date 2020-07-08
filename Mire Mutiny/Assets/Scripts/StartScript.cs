using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
  public int literalSpeed;
  public int shotSpeed;
  public int shotQuickness;
  public int shotLife;
  public int dashTime;
  public int dashAnimWait;
    // Start is called before the first frame update
    void Start()
    {
      PlayerPrefs.SetFloat("Shot_Speed", shotSpeed); //30
      PlayerPrefs.SetFloat("Literal_Speed", literalSpeed); //4
      PlayerPrefs.SetFloat("Shot_Quickness", shotQuickness); //40
      PlayerPrefs.SetFloat("Shot_Life", shotLife); //120
      PlayerPrefs.SetFloat("dash_Time", dashTime); //30
      PlayerPrefs.SetFloat("dash_anim_wait", dashAnimWait); //30
    }

    // Update is called once per frame
    void Update()
    {

    }
}

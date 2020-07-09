using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public float shotSpeed = 30;
    public float literalSpeed = 4;
    public float shotQuickness = 40;
    public float shotLife = 120;
    public float dashTime = 30;
    public float dashAnimWait = 30;
    // Start is called before the first frame update
    void Start()
    {
      UpdateStats();
    }
    void Update() {
      if (Input.GetKey(KeyCode.U)) {
        PlayerPrefs.DeleteAll();
        UpdateStats();
      }
    }
    void UpdateStats() {
      PlayerPrefs.SetFloat("Shot_Speed", shotSpeed);
      PlayerPrefs.SetFloat("Literal_Speed", literalSpeed);
      PlayerPrefs.SetFloat("Shot_Quickness", shotQuickness);
      PlayerPrefs.SetFloat("Shot_Life", shotLife);
      PlayerPrefs.SetFloat("dash_Time", dashTime);
      PlayerPrefs.SetFloat("dash_anim_wait", dashAnimWait);
    }
}

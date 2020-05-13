using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpeedUpSmall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D Collision){
      if (Collision.gameObject.CompareTag("playerCharacter")){
        if (PlayerPrefs.GetFloat("Shot_Speed", 30) > 5){
        PlayerPrefs.SetFloat("Shot_Speed", PlayerPrefs.GetFloat("Shot_Speed", 30)-5);
        Destroy(gameObject);
      }
        if (PlayerPrefs.GetFloat("Shot_Speed", 30) <= 5){
          PlayerPrefs.SetFloat("Shot_Speed", 1);
          Destroy(gameObject);
        }
      }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotQuicknessUp : MonoBehaviour
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
        PlayerPrefs.SetFloat("Shot_Quickness", PlayerPrefs.GetFloat("Shot_Quickness", 40)+10);
        Destroy(gameObject);
    }
}}

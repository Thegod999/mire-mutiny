using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
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
        PlayerPrefs.SetFloat("Literal_Speed", PlayerPrefs.GetFloat("Literal_Speed", 4)+1);
        Destroy(gameObject);
    }
}}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletLifeUp : MonoBehaviour
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
        PlayerPrefs.SetFloat("Shot_Life", PlayerPrefs.GetFloat("Shot_Life", 120)+20);
        Destroy(gameObject);
    }
}}

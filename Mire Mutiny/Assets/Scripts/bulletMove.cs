using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    public float speed = PlayerPrefs.GetFloat("Shot_Quickness", 40);
    // Start is called before the first frame update
    void Start()
    {
      speed = PlayerPrefs.GetFloat("Shot_Quickness", 40);
    }

    // Update is called once per frame
    void Update()
    {
        speed = PlayerPrefs.GetFloat("Shot_Quickness", 40);
        transform.Translate(Vector2.up * speed * .001f);
    }
}

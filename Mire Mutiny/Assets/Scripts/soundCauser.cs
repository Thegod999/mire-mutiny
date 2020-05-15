using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundCauser : MonoBehaviour
{
    AudioSource sound;
    public bool isPlayed;
    public int waitLength;
    // Start is called before the first frame update
    void Start()
    {
      sound = GetComponent<AudioSource>();
      isPlayed = false;
      waitLength = 60;
    }

    // Update is called once per frame
    void Update()
    {
      if (gameObject.name.Contains("(Clone)") && isPlayed == false) {
        sound.Play(0);
//        Debug.Log("Sound");
//        Destroy(gameObject);
        isPlayed = true;
      }
      if (isPlayed == true) {
        waitLength --;
      }
      if (waitLength <= 0) {
        Destroy(gameObject);
      }
    }
}

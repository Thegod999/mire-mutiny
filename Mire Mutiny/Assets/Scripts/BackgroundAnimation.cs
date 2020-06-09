using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
  public Animator anim;
  public bool ofCourse = true;
    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
      anim.SetBool("ofCourse", ofCourse);
    }

    // Update is called once per frame
    void Update()
    {
      anim.SetBool("ofCourse", ofCourse);
    }
}

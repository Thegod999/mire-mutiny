using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float speed;
  public Animator anim;
  private float Vertical;
  private float Horizontal;

    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      anim.SetFloat("AxisVertical", Vertical);
      anim.SetFloat("AxisHorizontal", Horizontal);
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

      transform.Translate(Vector3.up * Time.deltaTime * speed * Input.GetAxis("Vertical"));
      transform.Translate(Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
    }
}

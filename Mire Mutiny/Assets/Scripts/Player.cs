using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float speed;
  public Animator anim;
  private float Vertical;
  private float Horizontal;

  public Vector3 bulletOffset = new Vector3(0, 0, 0);
	public GameObject BulletPrefab;
	public GameObject BulletPrefabClone;
	public float shotSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
      if (shotSpeed > 0) {
        shotSpeed --;
      }
    }
    void FixedUpdate()
    {
      anim.SetFloat("AxisVertical", Vertical);
      anim.SetFloat("AxisHorizontal", Horizontal);
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

      transform.Translate(Vector3.up * Time.deltaTime * speed * Input.GetAxis("Vertical"));
      transform.Translate(Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));


      if (Input.GetMouseButtonDown(0) && shotSpeed == 0) {
        			Vector3 offset = transform.rotation * bulletOffset;
        			GameObject Bullet = (GameObject)Instantiate(BulletPrefab, transform.position + offset, transform.rotation);
        			shotSpeed = 15f;
        		}
      }
}

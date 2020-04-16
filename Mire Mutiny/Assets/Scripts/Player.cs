using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float speed;
  public Animator anim;
  public float Vertical;
  public float Horizontal;
  public bool moveUp;
  public bool moveDown;
  public bool moveLeft;
  public bool moveRight;
  public bool moveUpRight;
  public bool moveUpLeft;
  public bool moveDownRight;
  public bool moveDownLeft;

  public Vector3 bulletOffset = new Vector3(0, 0, 0);
	public GameObject BulletPrefab;
	public GameObject BulletPrefabClone;
	public float shotSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
      Horizontal = 0;
      Vertical = 0;
      speed = speed/50;
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
      if (shotSpeed > 0) {
        shotSpeed --;
      }
      if (Input.GetKeyUp(KeyCode.A)) {
        Horizontal = 0;
        Debug.Log(Horizontal);
      }
      if (Input.GetKeyUp(KeyCode.D)) {
        Horizontal = 0;
        Debug.Log(Horizontal);
      }
      if (Input.GetKeyUp(KeyCode.W)) {
        Vertical = 0;
        Debug.Log(Vertical);
      }
      if (Input.GetKeyUp(KeyCode.S)) {
        Vertical = 0;
        Debug.Log(Vertical);
      }
      if (Horizontal == -1 && Vertical == 0) {
        moveLeft = true;
      }
      else{
        moveLeft = false;
      }
      if (Horizontal == 1 && Vertical == 0) {
        moveRight = true;
      }
      else{
        moveRight = false;
      }
      if (Vertical == 1 && Horizontal == 0) {
        moveUp = true;
      }
      else{
        moveUp = false;
      }
      if (Vertical == -1  && Horizontal == 0) {
        moveDown = true;
      }
      else{
        moveDown = false;
      }
      if (Vertical == 1  && Horizontal == 1) {
        moveUpRight = true;
      }
      else{
        moveUpRight = false;
      }
      if (Vertical == 1  && Horizontal == -1) {
        moveUpLeft = true;
      }
      else{
        moveUpLeft = false;
      }
      if (Vertical == -1  && Horizontal == 1) {
        moveDownRight = true;
      }
      else{
        moveDownRight = false;
      }
      if (Vertical == -1  && Horizontal == -1) {
        moveDownLeft = true;
      }
      else{
        moveDownLeft = false;
      }
//      Debug.Log(Time.deltaTime);
    }
    void FixedUpdate()
    {
      anim.SetFloat("AxisVertical", Vertical);
      anim.SetFloat("AxisHorizontal", Horizontal);
      if (Input.GetKey(KeyCode.A)) {
        Horizontal = -1;
        Debug.Log(Horizontal);
      }
      if (Input.GetKeyUp(KeyCode.A)) {
        Horizontal = 0;
        Debug.Log(Horizontal);
      }
      if (Input.GetKey(KeyCode.D)) {
        Horizontal = 1;
        Debug.Log(Horizontal);
      }
      if (Input.GetKeyUp(KeyCode.D)) {
        Horizontal = 0;
        Debug.Log(Horizontal);
      }
      if (Input.GetKey(KeyCode.W)) {
        Vertical = 1;
        Debug.Log(Vertical);
      }
      if (Input.GetKeyUp(KeyCode.W)) {
        Vertical = 0;
        Debug.Log(Vertical);
      }
      if (Input.GetKey(KeyCode.S)) {
        Vertical = -1;
        Debug.Log(Vertical);
      }
      if (Input.GetKeyUp(KeyCode.S)) {
        Vertical = 0;
        Debug.Log(Vertical);
      }
//        Horizontal = Input.GetAxis("Horizontal");
//        Vertical = Input.GetAxis("Vertical");

      transform.Translate(Vector3.up * speed * Input.GetAxis("Vertical"));
      transform.Translate(Vector3.right * speed * Input.GetAxis("Horizontal"));


      if (Input.GetMouseButtonDown(0) && shotSpeed == 0) {
        			Vector3 offset = transform.rotation * bulletOffset;
        			GameObject Bullet = (GameObject)Instantiate(BulletPrefab, transform.position + offset, transform.rotation);
        			shotSpeed = 15f;
        		}
      }
}

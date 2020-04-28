using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public Camera cameraInterface;
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
  public Rigidbody2D RigidBoi2D;

  public Vector3 bulletOffset = new Vector3(0, 0, 0);
	public GameObject BulletPrefab;
	public GameObject BulletPrefabClone;
	public float shotSpeed = 15f;
  private float shotSpeedReturn;
//  public float pointerAngle;
  Vector2 pointerPosition;
  Vector2 moveLoc;

    // Start is called before the first frame update
    void Start()
    {
//     float pointerAngle = Mathf.Atan2(moveLoc.y, move.x);
      shotSpeedReturn = shotSpeed;
      Horizontal = 0;
      Vertical = 0;
      speed = speed/50;
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
     pointerPosition = cameraInterface.ScreenToWorldPoint(Input.mousePosition);
      moveLoc.x = Input.GetAxisRaw("Horizontal");
      moveLoc.y = Input.GetAxisRaw("Vertical");

//      pointerAngle = Quaternion.LookRotation(pointerPosition);
//      Debug.Log(pointerPosition);
//        Debug.Log(pointerAngle);
      if (shotSpeed > 0) {
        shotSpeed --;
      }
      if (Input.GetKeyUp(KeyCode.A)) {
        Horizontal = 0;
//        Debug.Log(Horizontal);
      }
      if (Input.GetKeyUp(KeyCode.D)) {
        Horizontal = 0;
//        Debug.Log(Horizontal);
      }
      if (Input.GetKeyUp(KeyCode.W)) {
        Vertical = 0;
//        Debug.Log(Vertical);
      }
      if (Input.GetKeyUp(KeyCode.S)) {
        Vertical = 0;
  //      Debug.Log(Vertical);
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
      Vector2 shootDir = pointerPosition - RigidBoi2D.position;
      float pointerAngle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg -90f;
      if (Input.GetMouseButtonDown(0) && shotSpeed == 0) {
//        			Vector3 offset = transform.rotation * bulletOffset;
              GameObject Bullet = (GameObject)Instantiate(BulletPrefab, transform.position, Quaternion.Euler(0, 0, pointerAngle));
              shotSpeed = shotSpeedReturn;
              Debug.Log("clickDown");
            }
//      Debug.Log(Time.deltaTime);
    }
    void FixedUpdate()
    {
//      Vector2 shootDir = pointerPosition - RigidBoi2D.position;
//      float pointerAngle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg -90f;
//      Debug.Log(pointerAngle);
      anim.SetFloat("AxisVertical", Vertical);
      anim.SetFloat("AxisHorizontal", Horizontal);
      anim.SetBool("moveUpRight", moveUpRight);
      anim.SetBool("moveUp", moveUp);
      anim.SetBool("moveUpLeft", moveUpLeft);
      anim.SetBool("moveDownRight", moveDownRight);
      anim.SetBool("moveDown", moveDown);
      anim.SetBool("moveDownLeft", moveDownLeft);
      anim.SetBool("moveLeft", moveLeft);
      anim.SetBool("moveRight", moveRight);
      if (Input.GetKey(KeyCode.A)) {
        Horizontal = -1;
//        Debug.Log(Horizontal);
      }
      if (Input.GetKeyUp(KeyCode.A)) {
        Horizontal = 0;
//        Debug.Log(Horizontal);
      }
      if (Input.GetKey(KeyCode.D)) {
        Horizontal = 1;
//        Debug.Log(Horizontal);
      }
      if (Input.GetKeyUp(KeyCode.D)) {
        Horizontal = 0;
//        Debug.Log(Horizontal);
      }
      if (Input.GetKey(KeyCode.W)) {
        Vertical = 1;
//        Debug.Log(Vertical);
      }
      if (Input.GetKeyUp(KeyCode.W)) {
        Vertical = 0;
//        Debug.Log(Vertical);
      }
      if (Input.GetKey(KeyCode.S)) {
        Vertical = -1;
//        Debug.Log(Vertical);
      }
      if (Input.GetKeyUp(KeyCode.S)) {
        Vertical = 0;
//        Debug.Log(Vertical);
      }
//        Horizontal = Input.GetAxis("Horizontal");
//        Vertical = Input.GetAxis("Vertical");

      transform.Translate(Vector3.up * speed * Input.GetAxis("Vertical"));
      transform.Translate(Vector3.right * speed * Input.GetAxis("Horizontal"));
      }
}

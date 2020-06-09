using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
  public Camera cameraInterface;
  public float speed;
  public bool useSpeedSlow;
  public float speedSlow;
  public float speedRemoval = 0.02f;
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
  public GameObject popSound;
	public GameObject BulletPrefabClone;
	public float shotSpeed = 5;
  private float shotSpeedReturn;
  public float pointerAngle;
  Vector2 pointerPosition;
  public Vector2 moveLoc;
    void Start(){
//     float pointerAngle = Mathf.Atan2(moveLoc.y, move.x);
      shotSpeed = PlayerPrefs.GetFloat("Shot_Speed", 30);
      shotSpeedReturn = PlayerPrefs.GetFloat("Shot_Speed", 30);
      Horizontal = 0;
      Vertical = 0;
//      speed = speed/50;
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
      speed = PlayerPrefs.GetFloat("Literal_Speed", 5);
      speedSlow = speed/2;
      shotSpeedReturn = PlayerPrefs.GetFloat("Shot_Speed", 30);
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
        useSpeedSlow = true;
      }
      else{
        moveUpRight = false;
        useSpeedSlow = false;
      }
      if (Vertical == 1  && Horizontal == -1) {
        moveUpLeft = true;
        useSpeedSlow = true;
      }
      else{
        moveUpLeft = false;
        useSpeedSlow = false;
      }
      if (Vertical == -1  && Horizontal == 1) {
        moveDownRight = true;
        useSpeedSlow = true;
      }
      else{
        moveDownRight = false;
        useSpeedSlow = false;
      }
      if (Vertical == -1  && Horizontal == -1) {
        moveDownLeft = true;
        useSpeedSlow = true;
      }
      else{
        moveDownLeft = false;
        useSpeedSlow = false;
      }
      Vector2 shootDir = pointerPosition - RigidBoi2D.position;
      float pointerAngle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg -90f;
      if (Input.GetMouseButtonDown(0) && shotSpeed == 0) {
//        			Vector3 offset = transform.rotation * bulletOffset;
              GameObject Bullet = (GameObject)Instantiate(BulletPrefab, new Vector3 (transform.position.x, transform.position.y, 5), Quaternion.Euler(0, 0, pointerAngle));
              Instantiate(popSound, transform.position, Quaternion.identity);
              shotSpeed = shotSpeedReturn;
//              Debug.Log("clickDown");
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
      if (Input.GetKeyUp(KeyCode.R)) {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
      }
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
      if (Input.GetKey(KeyCode.M)) {
        PlayerPrefs.DeleteAll();
      }
      if (Input.GetKey(KeyCode.L)) {
        Application.Quit();
      }
//        Horizontal = Input.GetAxis("Horizontal");
//        Vertical = Input.GetAxis("Vertical");
//      if (useSpeedSlow == false) {
//        transform.Translate(Vector3.up * speed * speedRemoval‬ * Input.GetAxis("Vertical"));
//        transform.Translate(Vector3.right * speed * speedRemoval‬ * Input.GetAxis("Horizontal"));
//      }
//      if (useSpeedSlow = true) {
//        transform.Translate(Vector3.up * speedSlow * speedRemoval‬ * Input.GetAxis("Vertical"));
//        transform.Translate(Vector3.right * speedSlow * speedRemoval‬ * Input.GetAxis("Horizontal"));
//      }
      transform.Translate(Vector3.up * speed * speedRemoval‬ * Input.GetAxis("Vertical"));
      transform.Translate(Vector3.right * speed * speedRemoval‬ * Input.GetAxis("Horizontal"));
      }

}

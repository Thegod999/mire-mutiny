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
  public float spreadRange;
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
  public bool dashActive;
  public float dashLock ;
  public bool dashCont;
  public bool dashUp;
  public bool dashDown;
  public bool dashLeft;
  public bool dashRight;
  public bool dashUpRight;
  public bool dashUpLeft;
  public bool dashDownRight;
  public bool dashDownLeft;
  public float dashAnimWait;

    void Start(){
//     float pointerAngle = Mathf.Atan2(moveLoc.y, move.x);
      shotSpeed = PlayerPrefs.GetFloat("Shot_Speed", 30);
      shotSpeedReturn = PlayerPrefs.GetFloat("Shot_Speed", 30);
      dashLock = PlayerPrefs.GetFloat("dash_Time", 30);
      dashAnimWait = PlayerPrefs.GetFloat("dash_anim_wait", 30);
      dashActive = true;
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
        if (dashCont == true) {
          dashLeft = true;
          dashLock = PlayerPrefs.GetFloat("dash_Time", 30);
          dashCont = false;
        }
      }
      else{
        moveLeft = false;
      }
      if (Horizontal == 1 && Vertical == 0) {
        moveRight = true;
        if (dashCont == true) {
          dashRight = true;
          dashLock = PlayerPrefs.GetFloat("dash_Time", 30);
          dashCont = false;
        }
      }
      else{
        moveRight = false;
      }
      if (Vertical == 1 && Horizontal == 0) {
        moveUp = true;
        if (dashCont == true) {
          dashUp = true;
          dashLock = PlayerPrefs.GetFloat("dash_Time", 30);
          dashCont = false;
        }
      }
      else{
        moveUp = false;
      }
      if (Vertical == -1  && Horizontal == 0) {
        moveDown = true;
        if (dashCont == true) {
          dashDown = true;
          dashLock = PlayerPrefs.GetFloat("dash_Time", 30);
          dashCont = false;
        }
      }
      else{
        moveDown = false;
      }
      if (Vertical == 1  && Horizontal == 1) {
        moveUpRight = true;
        useSpeedSlow = true;
        if (dashCont == true) {
          dashUpRight = true;
          dashLock = PlayerPrefs.GetFloat("dash_Time", 30);
          dashCont = false;
        }
      }
      else{
        moveUpRight = false;
        useSpeedSlow = false;
      }
      if (Vertical == 1  && Horizontal == -1) {
        moveUpLeft = true;
        useSpeedSlow = true;
        if (dashCont == true) {
          dashUpLeft = true;
          dashLock = PlayerPrefs.GetFloat("dash_Time", 30);
          dashCont = false;
        }
      }
      else{
        moveUpLeft = false;
        useSpeedSlow = false;
      }
      if (Vertical == -1  && Horizontal == 1) {
        moveDownRight = true;
        useSpeedSlow = true;
        if (dashCont == true) {
          dashDownRight = true;
          dashLock = PlayerPrefs.GetFloat("dash_Time", 30);
          dashCont = false;
        }
      }
      else{
        moveDownRight = false;
        useSpeedSlow = false;
      }
      if (Vertical == -1  && Horizontal == -1) {
        moveDownLeft = true;
        useSpeedSlow = true;
        if (dashCont == true) {
          dashDownLeft = true;
          dashLock = PlayerPrefs.GetFloat("dash_Time", 30);
          dashCont = false;
        }
      }
      else{
        moveDownLeft = false;
        useSpeedSlow = false;
      }
      if (dashLock != 0) {
        dashLock--;
      }
      if (Input.GetKeyDown(KeyCode.LeftShift) && dashActive == true && dashLock <= 0){
        Debug.Log("Dash!");
        dashCont = true;
//        dashActive = false;
//        dashLock = PlayerPrefs.GetFloat("dash_Time", 30);
      }
      Vector2 shootDir = pointerPosition - RigidBoi2D.position;
      float pointerAngle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg - 90f + Random.Range(-spreadRange, spreadRange);
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
      anim.SetBool("dashUpRight", dashUpRight);
      anim.SetBool("dashUp", dashUp);
      anim.SetBool("dashUpLeft", dashUpLeft);
      anim.SetBool("dashDownRight", dashDownRight);
      anim.SetBool("dashDown", dashDown);
      anim.SetBool("dashDownLeft", dashDownLeft);
      anim.SetBool("dashLeft", dashLeft);
      anim.SetBool("dashRight", dashRight);
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

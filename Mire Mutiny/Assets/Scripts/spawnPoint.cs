using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour{

  public int childDoorRequirment;
    //1 == bottom requirment
    //2 == top requirment
    //3 == left requirment
    //4 == right requirment


    private roomDatabase database;
    private int random;
    private bool generated = false;

    public float waitTime = 4f;
    // Start is called before the first frame update
    void Start(){
      Destroy(gameObject, waitTime);
      database = GameObject.FindGameObjectWithTag("rooms").GetComponent<roomDatabase>();
      Invoke("Generate", 0.1f);
    }

    // Update is called once per frame
    void Generate(){
      if (generated == false) {
        if (childDoorRequirment == 1) {
          random = Random.Range(0, database.bottomRooms.Length);
          Instantiate(database.bottomRooms[random], transform.position, database.bottomRooms[random].transform.rotation);
        }
        else if (childDoorRequirment == 2) {
          random = Random.Range(0, database.topRooms.Length);
          Instantiate(database.topRooms[random], transform.position, database.topRooms[random].transform.rotation);
        }
        else if (childDoorRequirment == 3) {
          random = Random.Range(0, database.leftRooms.Length);
          Instantiate(database.leftRooms[random], transform.position, database.leftRooms[random].transform.rotation);
        }
        else if (childDoorRequirment == 4) {
          random = Random.Range(0, database.rightRooms.Length);
          Instantiate(database.rightRooms[random], transform.position, database.rightRooms[random].transform.rotation);
        }
        else {
          Debug.Log("Error: No Child Request");
        }
        generated = true;
      }
    }
    void OnTriggerEnter2D(Collider2D collision){
      if(collision.CompareTag("SpawnPoint") && collision.GetComponent<spawnPoint>().generated == true){
        if (collision.GetComponent<spawnPoint>().generated == false && generated == false){
          Instantiate(database.closedRooms, transform.position, Quaternion.identity);
          Destroy(gameObject);
        }
        generated = true;
      }
    }
}

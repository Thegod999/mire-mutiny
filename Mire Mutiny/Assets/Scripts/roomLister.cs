using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomLister : MonoBehaviour{
  private roomDatabase database;
  void Start(){
    database = GameObject.FindGameObjectWithTag("rooms").GetComponent<roomDatabase>();
    database.rooms.Add(this.gameObject);
  }
}

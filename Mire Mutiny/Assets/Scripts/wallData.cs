using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallData : MonoBehaviour
{
  public int WallCount;
  void Start() {
    this.gameObject.SetActive(false);
  }
  void OnTriggerEnter2D(Collider other) {
    if (other.gameObject.tag == "MainCamera") {
      this.gameObject.SetActive(true);
    }
  }
  void OnTriggerExit2D(Collider other) {
    if (other.gameObject.tag == "MainCamera") {
      this.gameObject.SetActive(false);
    }
  }

}

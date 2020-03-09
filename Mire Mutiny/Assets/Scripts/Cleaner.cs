using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "SpawnPoint"){
//			Debug.Log("Cleaned!");
		Destroy(collision.gameObject);
	}
	else {}
	}
}

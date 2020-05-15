using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splatterLife : MonoBehaviour
{
  public int lifespan = 120;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (gameObject.name.Contains("(Clone)")) {
          lifespan--;
      }
      if (lifespan <= 0 && gameObject.name.Contains("(Clone)")) {
//        Debug.Log("Destroy");
        Destroy(gameObject);
      }
    }
}

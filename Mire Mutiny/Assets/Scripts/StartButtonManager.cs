using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonManager : MonoBehaviour
{
  public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
      Button btn = startButton.GetComponent<Button>();
      		btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick(){
//		Debug.Log ("Button Click");
    SceneManager.LoadScene("OpenRoomTesting");
	}
}

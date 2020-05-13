using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitButtonManager : MonoBehaviour
{
  public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
      Button btn = quitButton.GetComponent<Button>();
      		btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick(){
//		Debug.Log ("Button Click");
//    SceneManager.LoadScene("OpenRoomTesting");
    Application.Quit();
	}
}

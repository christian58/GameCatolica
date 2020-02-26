using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class change_scene : MonoBehaviour
{
    public string sceneName; 
    public Button loadSceneBtn;
    public GameObject LoadGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        // loadSceneBtn.onClick.Addlistner(ChangeScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeScene(){ 
        SceneManager.LoadScene(sceneName); 
    }

    public void OpenLoadGameMenu()
    {
        LoadGameMenu.SetActive(true);
    }
}

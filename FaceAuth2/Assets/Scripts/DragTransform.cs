using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragTransform : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance; 
    public Vector3 slot_pos;
    public GameObject TextCalification;
    
    public float timeStart;
    public Text textBox;    // Timer Text
    bool timerActive = true;

    private float starttime, endtime;
    int score = 0;
	public Text textshowed = null;  // Score Text
	public void changeWord (string word) {
		textshowed.text = word;
	}

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        textBox.text = timeStart.ToString("F2");
    }
   
    void OnMouseEnter()
    {
        // GetComponent<Renderer>().material.color = mouseOverColor;
    }
 
    void OnMouseExit()
    {
        // GetComponent<Renderer>().material.color = originalColor;
    }
 
    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }
 
    void OnMouseUp()
    {
        dragging = false;
    }
 
    void Update()
    {
        // Time execution
        timeStart += Time.deltaTime;
        textBox.text = timeStart.ToString("F2");
        // Calification Status
        if (score == 4)
        {
            TextCalification.SetActive(true);
        }
        // Score update
        if (Input.GetMouseButtonDown (0))
            starttime = Time.time;
        if (Input.GetMouseButtonUp (0))
            endtime = Time.time;
        if (endtime - starttime > 0.5f) {
            score++;
            Debug.Log ("Long click");
            changeWord (score.ToString());
            starttime = 0f;
            endtime = 0f;
        }
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
            if (transform.position.x >= -4.5f && transform.position.x <= -3.5f && transform.position.y >= -3.65f && transform.position.y <= -2.65f)
            {
                // Debug.Log("X: " + transform.position.x);
                transform.position = new Vector3(-4f, -3.15f, 0f);
            }
            else if (transform.position.x >= -4.5f && transform.position.x <= -3.5f && transform.position.y >= -2f && transform.position.y <= -1f)
            {
                // Debug.Log("X: " + transform.position.x);
                transform.position = new Vector3(-4f, -1.5f, 0f);
            }
            else if (transform.position.x >= -4.5f && transform.position.x <= -3.5f && transform.position.y >= -0.35f && transform.position.y <= 0.65f)
            {
                // Debug.Log("X: " + transform.position.x);
                transform.position = new Vector3(-4f, 0.15f, 0f);
            }
            else if (transform.position.x >= -4.5f && transform.position.x <= -3.5f && transform.position.y >= 1.2f && transform.position.y <= 2.2f)
            {
                // Debug.Log("X: " + transform.position.x);
                transform.position = new Vector3(-4f, 1.7f, 0f);
            }
            else if (transform.position.x >= -4.5f && transform.position.x <= -3.5f && transform.position.y >= 2.75f && transform.position.y <= 3.75f)
            {
                // Debug.Log("X: " + transform.position.x);
                transform.position = new Vector3(-4f, 3.25f, 0f);
            }
            
            else if (transform.position.x >= 4.7f && transform.position.x <= 5.7f && transform.position.y >= -3.65f && transform.position.y <= -2.65f)
            {
                // Debug.Log("X: " + transform.position.x);
                transform.position = new Vector3(5.2f, -3.15f, 0f);
            }
            else if (transform.position.x >= 4.7f && transform.position.x <= 5.7f && transform.position.y >= -2f && transform.position.y <= -1f)
            {
                // Debug.Log("X: " + transform.position.x);
                transform.position = new Vector3(5.2f, -1.5f, 0f);
            }
            else if (transform.position.x >= 4.7f && transform.position.x <= 5.7f && transform.position.y >= -0.35f && transform.position.y <= 0.65f)
            {
                // Debug.Log("X: " + transform.position.x);
                transform.position = new Vector3(5.2f, 0.15f, 0f);
            }
            else if (transform.position.x >= 4.7f && transform.position.x <= 5.7f && transform.position.y >= 1.2f && transform.position.y <= 2.2f)
            {
                // Debug.Log("X: " + transform.position.x);
                transform.position = new Vector3(5.2f, 1.7f, 0f);
            }

            // if (transform.position.x >= -4.5f && transform.position.x <= -3.55f)
            // {
            //     Debug.Log("X: " + transform.position.x);
            //     Debug.Log(slot_pos);
            //     if(slot_pos.x == 0.0 && slot_pos.y == 0.0 && slot_pos.z == 0.0)
            //     {
            //         Debug.Log(slot_pos);
            //         transform.position = new Vector3(-4f, -3.15f, 0f);
            //     }
            //     if(slot_pos.x == -4.0 && slot_pos.y == -3.2 && slot_pos.z == 0.0)
            //     {
            //         Debug.Log(slot_pos);
            //         transform.position = new Vector3(-4f, -1.5f, 0f);
            //     }
            //     if(Physics.Raycast(transform.position,new Vector3(-4f, -3.15f, 0f),1) == false)
            //     {
            //         slot_pos = new Vector3(-4f, -3.15f, 0f);
            //     }
            // }
        }
        
        WWWForm form = new WWWForm();
        //Debug.Log("Uploaddddddd");
        // form.AddField("usuario", c);
        // form.AddField("nivel", setNivel);
        // form.AddField("dificultad", setDificultad);
        form.AddField("tiempo", textBox.ToString());
        form.AddField("scores", textshowed.ToString());
        // form.AddField("grado", setGrado);
    }

    public void timerButton()
    {
        timerActive = !timerActive;
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
//using System.Diagnostics;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

public class GuardarDatosN1
{
    public string id;
    public int movimientos;
    public int tiempo;

    public GuardarDatosN1() { }
    public GuardarDatosN1(string id, int movimientos, int tiempo)
    {
        this.id = id;
        this.movimientos = movimientos;
        this.tiempo = tiempo;
    }
}
public class Cube1Move : MonoBehaviour
{
    //public RawImage backImage;
    public GameObject PanelG1N1;
    bool Instruccion;

    public GameObject Text_text_Nivel;

    public GameObject General;
    public Text TextInfo;
    public GameObject BtnLink;

    public GameObject Btn_aceptar;

    public string setUser;
    public string setNivel;
    public string setDificultad;
    public string setTiempo;
    public string setScore;
    public string setGrado;

    static public string ident;
    static public string grado;

    /********************/

    AuthUI authUI;
    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;
    DatabaseReference reference;

    GuardarDatosN1 guardarDatosN1;

    public Vector2 startPos1;
    public Vector2 direction1;
    public Vector2 endPos1;
    public Text m_Text1;
    string message1;


    public GameObject ayuda;


    public Vector3 offset;

    public GameObject player;
    public GameObject center;

    public GameObject Up;
    public GameObject Down;
    public GameObject Left;
    public GameObject Right;

    public GameObject Const;

    public Text mesaje;


    public int step = 9;

    public int aux;

    public float speed;
    public float timeStep;

    bool input = true;
    bool gane = false;
    // Start is called before the first frame update
    public int x = 0;
    public int y = 0;
    public int z = 0;

    public int coordenadaX;
    public int coordenadaZ;

    /*******************  ANIMATION **************************/

    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    float cubesPivotDistance;
    Vector3 cubesPivot;






    /*********************************************/
    //Pair<int, int> par = new Pair<int, int>();
    //List< Pair<int, int> > metas = new List< Pair<int, int> >();

    bool flag_borde;

    public List<Vector2> metas;
    public Vector2 escenario1;

    public List<List<Vector2>> bordes;

    public List<Vector2> lista_aux;

    public List<Vector2> lista_aux01;

    public Vector2 margen;

    /*********************************************/
    bool flagg;

    bool bander = true;

    public float auxX;
    public float auxZ;

    public int n_escenario;


    public Vector2 startPos;
    public Vector2 endPos;
    public bool fingerHold = false;


    int xx, yy;
    bool pushh, pushh2;

    int punt;
    int tiempo_seg;

    int corx, cor2x;
    int cory, cor2y;

    bool complete, complete2;

    int start_time_s, start_time_m, start_time_h, elapsed_time_s, elapsed_time_m, elapsed_time_h;

    static public string iden;


    void Start()
    {
        Instruccion = true;
        //PanelG1N1.SetActive(false);

        General.SetActive(false);
        BtnLink.SetActive(false);


        Btn_aceptar.SetActive(false);
        Text_text_Nivel.SetActive(false);


        //iden = gameObject.GetComponent<AuthManager>().userIdd.id;
        //iden = authManager.iden;

        //iden = gameObject.GetComponent<AuthManager>().ide;



        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://engame-test.firebaseio.com/");

        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        authUI = GetComponent<AuthUI>();
        //auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        InitializeFirebase();

        /**************/
        start_time_h = DateTime.Now.Hour;
        start_time_m = DateTime.Now.Minute;
        start_time_s = DateTime.Now.Second;

        //puente.transform.positio
        //player.transform.position.x
        corx = 24;
        cory = 8;

        cor2x = 20;
        cor2y = -8;


        punt = 0;

        mesaje.text = "SCORE: " + punt;

        input = true;
        bander = true;

        coordenadaX = 0;
        coordenadaZ = 0;
        pushh = true;
        pushh2 = true;
        flagg = true;
        Screen.orientation = ScreenOrientation.Landscape;


        /*********************************************/

        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);



        /*********************************************/

        speed = (float)0.015;
        timeStep = (float)1.0;

        flag_borde = false;
        bordes = new List<List<Vector2>>();
        n_escenario = 0;

        /****************  ESCENARIO 0  *************************/

        lista_aux = new List<Vector2>();

        margen = new Vector2(-4, -12); lista_aux.Add(margen);
        margen = new Vector2(0, -12); lista_aux.Add(margen);
        margen = new Vector2(4, -12); lista_aux.Add(margen);
        margen = new Vector2(8, -12); lista_aux.Add(margen);
        margen = new Vector2(12, -12); lista_aux.Add(margen);
        margen = new Vector2(16, -12); lista_aux.Add(margen);
        margen = new Vector2(20, -12); lista_aux.Add(margen);
        margen = new Vector2(24, -12); lista_aux.Add(margen);
        margen = new Vector2(28, -12); lista_aux.Add(margen);
        margen = new Vector2(28, -8); lista_aux.Add(margen);
        margen = new Vector2(28, -4); lista_aux.Add(margen);
        margen = new Vector2(28, 0); lista_aux.Add(margen);
        margen = new Vector2(28, 4); lista_aux.Add(margen);
        margen = new Vector2(28, 8); lista_aux.Add(margen);
        margen = new Vector2(28, 12); lista_aux.Add(margen);
        margen = new Vector2(28, 16); lista_aux.Add(margen);
        margen = new Vector2(24, 16); lista_aux.Add(margen);
        margen = new Vector2(20, 16); lista_aux.Add(margen);
        margen = new Vector2(16, 16); lista_aux.Add(margen);
        margen = new Vector2(12, 16); lista_aux.Add(margen);
        margen = new Vector2(8, 16); lista_aux.Add(margen);
        margen = new Vector2(4, 16); lista_aux.Add(margen);
        margen = new Vector2(0, 16); lista_aux.Add(margen);
        margen = new Vector2(-4, 16); lista_aux.Add(margen);
        margen = new Vector2(-8, 16); lista_aux.Add(margen);
        margen = new Vector2(-8, 12); lista_aux.Add(margen);
        margen = new Vector2(-8, 8); lista_aux.Add(margen);
        margen = new Vector2(-8, 4); lista_aux.Add(margen);
        margen = new Vector2(-8, 0); lista_aux.Add(margen);
        margen = new Vector2(-8, -4); lista_aux.Add(margen);
        margen = new Vector2(-8, -8); lista_aux.Add(margen);

        complete = false;
        complete2 = false;


        bordes.Add(lista_aux);



        /***************** ESCENARIO II ************************/

        escenario1 = new Vector2(20, 8);
        metas.Add(escenario1);


        /***************** ESCENARIO III ************************/

        escenario1 = new Vector2(40, -12);
        metas.Add(escenario1);

        /***************** ESCENARIO IV ************************/

        escenario1 = new Vector2(-12, -8);
        metas.Add(escenario1);

        IniciarBordes();

        //margen = new Vector2(28, -8); lista_aux.Add(margen);

        Print_e();


    }

    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
    }

    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
                //displayName = user.DisplayName ?? "";
                //emailAddress = user.Email ?? "";
                //photoUrl = user.PhotoUrl ?? "";
            }
        }
    }


    public void GetUserIdNivel1(string userId, string userGrado)
    {

        ident = userId;
        grado = userGrado;
    }


    // Update is called once per frame
    void Update()
    {
        /*
        if(Instruccion == true)
        {
            PanelG1N1.SetActive(false);
        }*/

        if(Input.touchCount < 2)
        {
            if (input == true)
            {


                if (player.transform.position.x > 0)
                {
                    coordenadaX = (int)(player.transform.position.x + 0.1);

                }
                else coordenadaX = (int)(player.transform.position.x - 0.1);

                if (player.transform.position.z < 0)
                {
                    coordenadaZ = (int)(player.transform.position.z - 0.1);
                }
                else coordenadaZ = (int)(player.transform.position.z + 0.1);


                if (corx == coordenadaX && cory == coordenadaZ) complete = true;
                if (cor2x == coordenadaX && cor2y == coordenadaZ) complete2 = true;



                Debug.Log("ErrorROOROROR");

                if (complete && complete2)
                {
                    Debug.Log("GANEEEEEEEEEEEEEEE");
                    input = false;

                    elapsed_time_s = DateTime.Now.Second;
                    elapsed_time_m = DateTime.Now.Minute;
                    elapsed_time_h = DateTime.Now.Hour;

                    tiempo_seg = (60 - start_time_s) - (60 - elapsed_time_s);
                    int time_min = (60) * ((60 - start_time_m) - (60 - elapsed_time_m));
                    int time_hour = (60) * (elapsed_time_h - start_time_h);
                    int segg = tiempo_seg + time_min + time_hour;

                    guardarDatosN1 = new GuardarDatosN1(ident, punt, segg);
                    string json = JsonUtility.ToJson(guardarDatosN1);
                    //string json01 = JsonUtility.ToJson(rol);
                    //string idd = newUser.UserId;

                    Text_text_Nivel.SetActive(true);
                    General.SetActive(true);
                    BtnLink.SetActive(true);


                    Btn_aceptar.SetActive(true);

                    reference.Child("usersData").Child(ident).Child("Game1").Child("Nivel1").SetRawJsonValueAsync(json);



                    string move = punt.ToString();
                    string time = segg.ToString();

                    setUser = ident;
                    setNivel = "1";
                    setDificultad = "1";

                    setTiempo = time;
                    setScore = move;
                    setGrado = grado;

                    Debug.Log("GANE");
                    StartCoroutine(Upload());
                    Debug.Log("END GANE");






                }








                Debug.Log("Exactoy ");
                Debug.Log(coordenadaX);
                Debug.Log(coordenadaZ);


                if (flagg == true)
                {


                    if (Input.touchCount > 0 && bander == true)
                    {
                        input = false;

                        flagg = false;
                        //mesaje.text= "ENtrOOOOO";
                        Touch touch1 = Input.GetTouch(0);

                        // Handle finger movements based on TouchPhase
                        switch (touch1.phase)
                        {
                            //When a touch has first been detected, change the message and record the starting position
                            case TouchPhase.Began:
                                // Record initial touch position.
                                startPos1 = touch1.position;
                                endPos1 = touch1.position;
                                xx = ((int)startPos1.x) % 1000;
                                yy = ((int)startPos1.y) % 1000;
                                string aux = " " + xx;
                                string aux2 = aux + yy;
                                //mesaje.text = "Begun " + aux2;
                                break;

                            //Determine if the touch is a moving touch
                            case TouchPhase.Moved:
                                // Determine direction by comparing the current touch position with the initial one
                                direction1 = touch1.position - startPos1;
                                //mesaje.text = "Moving ";
                                break;

                            case TouchPhase.Ended:
                                // Report that the touch has ended when it ends
                                endPos1 = touch1.position;
                                xx = ((int)endPos1.x) % 1000;
                                yy = ((int)endPos1.y) % 1000;
                                string aux3 = " " + xx;
                                string aux4 = aux3 + yy;
                                //mesaje.text = "Ending " + yy;
                                break;
                        }
                        int difx = (int)startPos1.x - (int)endPos1.x;
                        int dify = (int)startPos1.y - (int)endPos1.y;
                        if (Mathf.Abs(difx) > Mathf.Abs(dify))
                        {


                            if (Mathf.Abs(difx) > 200)
                            {
                                if (difx > 0)
                                {
                                    StartCoroutine("moveLeft");
                                    //punt++;
                                    //mesaje.text = "SCORE: " + punt;
                                }
                                else
                                {
                                    StartCoroutine("moveRight");
                                    //punt++;
                                    //mesaje.text = "SCORE: " + punt;
                                }


                            }

                        }
                        else
                        {
                            //punt++;
                            //mesaje.text = "SCORE: " + punt;
                            if (Mathf.Abs(dify) > 200)
                            {
                                if (dify > 0)
                                {
                                    StartCoroutine("moveDown");
                                    //punt++;
                                    //mesaje.text = "SCORE: " + punt;
                                }
                                else
                                {
                                    StartCoroutine("moveUp");
                                    //punt++;
                                    //mesaje.text = "SCORE: " + punt;
                                }

                            }

                        }



                        input = true;

                        //mesaje.text = "Touch : " + message1 + "in direction" + direction1;
                    }

                }


                if (input == true)
                {
                    //Debug.Log("DoWhy");
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        input = false;
                        StartCoroutine("moveUp");

                    }
                    else if (Input.GetKey(KeyCode.DownArrow))
                    {
                        input = false;
                        StartCoroutine("moveDown");

                    }
                    else if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        input = false;
                        StartCoroutine("moveLeft");

                    }
                    else if (Input.GetKey(KeyCode.RightArrow))
                    {
                        input = false;
                        StartCoroutine("moveRight");
                    }


                }


                if (flagg == false)
                {
                    if (corx == coordenadaX && cory == coordenadaZ && System.Math.Abs(player.transform.position.y - 4) < 1)
                    //if (posVictoriaX == coordenadaX && posVictoriaZ == coordenadaZ)
                    {
                        //mesaje.text = "GANE xD";
                        //n_escenario++;
                        input = false;
                        //lista_aux[17] = lista_aux[16];
                        //puente.SetActive(true);
                        //n_escenario++;
                        Debug.Log(coordenadaX);
                        Debug.Log(coordenadaZ);

                    }

                    if ((int)metas[n_escenario].x == coordenadaX && (int)metas[n_escenario].y == coordenadaZ && System.Math.Abs(player.transform.position.y - 4) < 1)
                    //if (posVictoriaX == coordenadaX && posVictoriaZ == coordenadaZ)
                    {
                        //margen = new Vector2(28, -12); lista_aux.Add(margen);

                        Debug.Log(coordenadaX);
                        Debug.Log(coordenadaZ);
                        //n_escenario++;

                        flagg = true;

                    }
                    else
                    {
                        flagg = true;

                        pushh = true;
                    }




                }

            }
        }



    }


    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        //Debug.Log("Uploaddddddd");
        form.AddField("usuario", setUser);
        form.AddField("juego", setNivel);
        form.AddField("nivel", setDificultad);
        form.AddField("tiempo", setTiempo);
        form.AddField("scores", setScore);
        form.AddField("grado", setGrado);

        Debug.Log("DATOS");
        Debug.Log(setUser);
        Debug.Log(setNivel);
        Debug.Log(setDificultad);
        Debug.Log(setTiempo);
        Debug.Log(setScore);
        Debug.Log(setGrado);
        Debug.Log("END DATOS");

        UnityWebRequest www = UnityWebRequest.Post("https://herokudjangoappaqp.herokuapp.com/api/agregar/", form);
        yield return www.SendWebRequest();
        //Text_info.text = "Entreeeeeee" + setNivel;

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            TextInfo.text = "ERRRRRRROR " + grado;
        }
        else
        {
            //var oMycustomclassname = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(www);
            MyClass myObject = new MyClass();
            myObject = JsonUtility.FromJson<MyClass>(www.downloadHandler.text);



            //Text_info.text = "No LO se" + grado;

            string linkk = myObject.ayuda;

            if (myObject.resultado == "Aprendio.")
            {
                TextInfo.text = "Felicidades usted completo el nivel satisfactoriamente ";
            }
            if(myObject.resultado == "No Aprendio.")
            //else
            {
                TextInfo.text = "No logro completar los objetivos del nivel, para mejorar sus capacidades ingrese en el siguiente link: ";

                BtnLink.GetComponentInChildren<Text>().text = linkk;
            }

            //LinkBtn.GetComponentInChildren<Text>().text = 

            //Aprender.text = myObject.ayuda;


        }


    }

    public void PressBtnLink()
    {
        //Application.OpenURL(LinkBtn.GetComponentInChildren<Text>().text);
        Application.OpenURL("https://forum.unity.com/threads/change-button-text.424817/");
    }







    IEnumerator moveUp()
    {
        z = (int)System.Math.Abs(Up.transform.position.z - Down.transform.position.z);

        x = (int)System.Math.Abs(Right.transform.position.x - Left.transform.position.x);

        Debug.Log(player.transform.position);



        if (player.transform.position.x > 0)
        {
            coordenadaX = (int)(player.transform.position.x + 0.1);

        }
        else coordenadaX = (int)(player.transform.position.x - 0.1);

        if (player.transform.position.z < 0)
        {
            coordenadaZ = (int)(player.transform.position.z - 0.1);
        }
        else coordenadaZ = (int)(player.transform.position.z + 0.1);


        GiroValido(coordenadaX, coordenadaZ + 4);
        if (!flag_borde)
        {
            //GiroValido(coordenadaX, coordenadaZ + 6);
        }

        if (!flag_borde)
        {

            punt++;
            mesaje.text = "SCORE: " + punt;

            offset = Up.transform.position;


            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(Up.transform.position, Vector3.right, step);
                yield return new WaitForSeconds(speed);
            }


            center.transform.position = player.transform.position;

            /*
            if (z < 5 && x < 5)
            {
                Up.transform.position = new Vector3(Up.transform.position.x, Up.transform.position.y + 2, Up.transform.position.z + 2);
                Right.transform.position = new Vector3(Right.transform.position.x, Right.transform.position.y + 2, Right.transform.position.z);
                Left.transform.position = new Vector3(Left.transform.position.x, Left.transform.position.y + 2, Left.transform.position.z);
            }
            else if (z > 5 && x < 5)
            {
                Up.transform.position = new Vector3(Up.transform.position.x, Up.transform.position.y - 2, Up.transform.position.z - 2);
                Right.transform.position = new Vector3(Right.transform.position.x, Right.transform.position.y - 2, Right.transform.position.z);
                Left.transform.position = new Vector3(Left.transform.position.x, Left.transform.position.y - 2, Left.transform.position.z);
            }
            */

            Down.transform.position = offset;
            yield return new WaitForSeconds(speed);
            yield return new WaitForSeconds(timeStep * 0.1f);
            input = true;
            //Debug.Log(player.transform.position);


        }
        else
        {
            //Debug.Log("perdi");
            flag_borde = false;
            yield return new WaitForSeconds(timeStep * 0.3f);
            input = true;
            //Debug.Log(player.transform.position);
            //yield return new WaitForSeconds(timeStep);
        }
    }

    IEnumerator moveDown()
    {
        z = (int)System.Math.Abs(Up.transform.position.z - Down.transform.position.z);
        x = (int)System.Math.Abs(Right.transform.position.x - Left.transform.position.x);

        //Debug.Log(player.transform.position);


        if (player.transform.position.x > 0)
        {
            coordenadaX = (int)(player.transform.position.x + 0.1);

        }
        else coordenadaX = (int)(player.transform.position.x - 0.1);

        if (player.transform.position.z < 0)
        {
            coordenadaZ = (int)(player.transform.position.z - 0.1);
        }
        else coordenadaZ = (int)(player.transform.position.z + 0.1);


        GiroValido(coordenadaX, coordenadaZ - 4);
        if (!flag_borde)
        {
            //GiroValido(coordenadaX, coordenadaZ - 6);
        }

        if (!flag_borde)
        {
            punt++;
            mesaje.text = "SCORE: " + punt;

            offset = Down.transform.position;

            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(Down.transform.position, Vector3.left, step);
                yield return new WaitForSeconds(speed);
            }



            center.transform.position = player.transform.position;
            /*
            if (z < 5 && x < 5)
            {
                Down.transform.position = new Vector3(Down.transform.position.x, Down.transform.position.y + 2, Down.transform.position.z - 2);
                Right.transform.position = new Vector3(Right.transform.position.x, Right.transform.position.y + 2, Right.transform.position.z);
                Left.transform.position = new Vector3(Left.transform.position.x, Left.transform.position.y + 2, Left.transform.position.z);
            }
            else if (z > 5 && x < 5)
            {
                Down.transform.position = new Vector3(Down.transform.position.x, Down.transform.position.y - 2, Down.transform.position.z + 2);
                Right.transform.position = new Vector3(Right.transform.position.x, Right.transform.position.y - 2, Right.transform.position.z);
                Left.transform.position = new Vector3(Left.transform.position.x, Left.transform.position.y - 2, Left.transform.position.z);
            }
            */
            Up.transform.position = offset;
            yield return new WaitForSeconds(timeStep * 0.1f);
            input = true;
            //Debug.Log(player.transform.position);


        }
        else
        {
            //Debug.Log("perdi");
            flag_borde = false;
            yield return new WaitForSeconds(timeStep * 0.3f);
            input = true;
            //Debug.Log(player.transform.position);
            //yield return new WaitForSeconds(timeStep);
        }
    }

    IEnumerator moveLeft()
    {
        z = (int)System.Math.Abs(Up.transform.position.z - Down.transform.position.z);

        x = (int)System.Math.Abs(Right.transform.position.x - Left.transform.position.x);

        Debug.Log("Anterior");
        Debug.Log(player.transform.position);

        if (player.transform.position.x > 0)
        {
            coordenadaX = (int)(player.transform.position.x + 0.1);

        }
        else coordenadaX = (int)(player.transform.position.x - 0.1);

        if (player.transform.position.z < 0)
        {
            coordenadaZ = (int)(player.transform.position.z - 0.1);
        }
        else coordenadaZ = (int)(player.transform.position.z + 0.1);

        GiroValido(coordenadaX - 4, coordenadaZ);

        if (!flag_borde)
        {
            //GiroValido(coordenadaX - 6, coordenadaZ);
        }

        if (!flag_borde)
        {
            punt++;
            mesaje.text = "SCORE: " + punt;

            offset = Left.transform.position;

            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(Left.transform.position, Vector3.forward, step);
                yield return new WaitForSeconds(speed);
            }


            center.transform.position = player.transform.position;

            /*
            if (x < 5 && z < 5)
            {
                Left.transform.position = new Vector3(Left.transform.position.x - 2, Left.transform.position.y + 2, Left.transform.position.z);
                Up.transform.position = new Vector3(Up.transform.position.x, Up.transform.position.y + 2, Up.transform.position.z);
                Down.transform.position = new Vector3(Down.transform.position.x, Down.transform.position.y + 2, Down.transform.position.z);
            }
            else if (x > 5 && z < 5)
            {
                Left.transform.position = new Vector3(Left.transform.position.x + 2, Left.transform.position.y - 2, Left.transform.position.z);
                Up.transform.position = new Vector3(Up.transform.position.x, Up.transform.position.y - 2, Up.transform.position.z);
                Down.transform.position = new Vector3(Down.transform.position.x, Down.transform.position.y - 2, Down.transform.position.z);
            }
            else
            {
                Right.transform.position = new Vector3(Right.transform.position.x, Right.transform.position.y, Right.transform.position.z);
                Up.transform.position = new Vector3(Up.transform.position.x, Up.transform.position.y, Up.transform.position.z);
                Down.transform.position = new Vector3(Down.transform.position.x, Down.transform.position.y, Down.transform.position.z);
            }
            */
            //Right.transform.position = new Vector3(Right.transform.position.x, Right.transform.position.y, Right.transform.position.z);
            //Up.transform.position = new Vector3(Up.transform.position.x, Up.transform.position.y, Up.transform.position.z);
            //Down.transform.position = new Vector3(Down.transform.position.x, Down.transform.position.y, Down.transform.position.z);

            //Right.transform.position = offset;


            //Debug.Log(player.transform.position);
            yield return new WaitForSeconds(timeStep * 0.1f);
            input = true;

        }
        else
        {
            //Debug.Log("perdi");
            flag_borde = false;
            yield return new WaitForSeconds(timeStep * 0.3f);
            input = true;
            //Debug.Log(player.transform.position);
            //yield return new WaitForSeconds(timeStep);
        }

    }

    IEnumerator moveRight()
    {
        z = (int)System.Math.Abs(Up.transform.position.z - Down.transform.position.z);

        x = (int)System.Math.Abs(Right.transform.position.x - Left.transform.position.x);
        //Debug.Log("derecha");
        //Debug.Log(player.transform.position);

        if (player.transform.position.x > 0)
        {
            coordenadaX = (int)(player.transform.position.x + 0.1);

        }
        else coordenadaX = (int)(player.transform.position.x - 0.1);

        if (player.transform.position.z < 0)
        {
            coordenadaZ = (int)(player.transform.position.z - 0.1);
        }
        else coordenadaZ = (int)(player.transform.position.z + 0.1);

        //comentar para pequenos tamanos

        Debug.Log("Validooo");
        Debug.Log(coordenadaX);
        Debug.Log(coordenadaZ);
        GiroValido(coordenadaX + 4, coordenadaZ);
        Debug.Log("Noloes");
        if (!flag_borde)
        {
            //GiroValido(coordenadaX + 6, coordenadaZ);
        }


        if (!flag_borde)
        {
            punt++;
            mesaje.text = "SCORE: " + punt;

            offset = Right.transform.position;


            for (int i = 0; i < (90 / step); i++)
            {
                player.transform.RotateAround(Right.transform.position, Vector3.back, step);
                yield return new WaitForSeconds(speed);
            }

            center.transform.position = player.transform.position;

            /*
            if (x < 5 && z < 5)
            {
                Right.transform.position = new Vector3(Right.transform.position.x + 2, Right.transform.position.y + 2, Right.transform.position.z);
                Up.transform.position = new Vector3(Up.transform.position.x, Up.transform.position.y + 2, Up.transform.position.z);
                Down.transform.position = new Vector3(Down.transform.position.x, Down.transform.position.y + 2, Down.transform.position.z);
            }
            else if (x > 5 && z < 5)
            {
                Right.transform.position = new Vector3(Right.transform.position.x - 2, Right.transform.position.y - 2, Right.transform.position.z);
                Up.transform.position = new Vector3(Up.transform.position.x, Up.transform.position.y - 2, Up.transform.position.z);
                Down.transform.position = new Vector3(Down.transform.position.x, Down.transform.position.y - 2, Down.transform.position.z);
            }
            else
            {
                Right.transform.position = new Vector3(Right.transform.position.x, Right.transform.position.y, Right.transform.position.z);
                Up.transform.position = new Vector3(Up.transform.position.x, Up.transform.position.y, Up.transform.position.z);
                Down.transform.position = new Vector3(Down.transform.position.x, Down.transform.position.y, Down.transform.position.z);
            }
            */

            //Right.transform.position = new Vector3(Right.transform.position.x, Right.transform.position.y, Right.transform.position.z);
            //Up.transform.position = new Vector3(Up.transform.position.x, Up.transform.position.y, Up.transform.position.z);
            //Down.transform.position = new Vector3(Down.transform.position.x, Down.transform.position.y, Down.transform.position.z);

            //Left.transform.position = offset;


            //Debug.Log(player.transform.position);
            yield return new WaitForSeconds(timeStep * 0.1f);
            input = true;
        }
        else
        {
            //Debug.Log("perdirrrrr");
            flag_borde = false;
            yield return new WaitForSeconds(timeStep * 0.3f);
            input = true;
            //Debug.Log(player.transform.position);
            //yield return new WaitForSeconds(timeStep);
        }

        Debug.Log("derecha");
        Debug.Log(player.transform.position);
    }


    void IniciarBordes()
    {
        int j = 0;
        int tam_list = bordes[j].Count;
        //Debug.Log("Inicia");
        //Debug.Log(tam_list);
        /*
        for (int i = 0; i < tam_list; i++)
        {
            bordes[j].Add(new Vector2(bordes[j][i].x + 2, bordes[j][i].y));
            bordes[j].Add(new Vector2(bordes[j][i].x - 2, bordes[j][i].y));
            bordes[j].Add(new Vector2(bordes[j][i].x, bordes[j][i].y + 2));
            bordes[j].Add(new Vector2(bordes[j][i].x, bordes[j][i].y - 2));
        }
        */




        //Debug.Log("termina");
        //Debug.Log(bordes[j].Count);
    }

    void GiroValido(int xx, int yy)
    {
        /*
        if (!complete)
        {
            if (28 == xx && -8 == yy || 30 == xx && -8 == yy || 26 == xx && -8 == yy || 28 == xx && -6 == yy || 28 == xx && -10 == yy)
            {
                flag_borde = true;
                return;
            }
        }
        */

        //Debug.Log(bordes[n_escenario].Count );

        for (int i = 0; i < bordes[n_escenario].Count; i++)
        {

            if ((int)metas[n_escenario].x == xx && (int)metas[n_escenario].y == yy)
            {
                break;
            }

            else if ((int)bordes[n_escenario][i].x == xx && (int)bordes[n_escenario][i].y == yy)
            {
                flag_borde = true;
                break;
            }
        }

    }


    void Print_e()
    {
        //Debug.Log("Print");

        for (int i = 0; i < bordes[0].Count; i++)
        {
            //Debug.Log(bordes[0][i]);
        }
    }


    public void PanelInicioG1N1()
    {
        Debug.Log("MENSAJEE ENTREEEE");
        Instruccion = true;
        PanelG1N1.SetActive(false);

    }


    public void ReloadScena()
    {
        Debug.Log("ERERERE");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}

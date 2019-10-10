using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NamNPC;
using NamNPC.NamEnemy;
using System;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public Text contZombi; //variable tipo text para mostrar el numero de zombis
    public Text contCiud; //variable tipo text para mostrar el numero de ciudadanos
    int numZomb;
    int numCiud;

    System.Random rnd = new System.Random(); //variable tipo random para dar un minimo de personajes a la variable readonly
    GameObject heroe;  //variables para crear personajes
    GameObject zombi;
    GameObject ciudadano;
    NamNPC.NamEnemy.DatosZom utilZombi; // variable tipo estructura de zombi
    public readonly int minimo; //variable readonly para un minimo de personajes
    const int maximo = 25; //variable const para un maximo de personajes

    public Generator() //constructor de clase para dar un minimo de personajes a minimo
    {
        minimo = rnd.Next(5, 16);
    }

    void Start()
    {
        heroe = GameObject.CreatePrimitive(PrimitiveType.Cube); //creacion de heroe
        heroe.AddComponent<PersHero>();
        heroe.AddComponent<MoviFps>();
        heroe.AddComponent<Rigidbody>();
        GameObject movCam = new GameObject(); // objeto para añadirle la camara y el script de la camara y este añadirlo al heroe
        movCam.AddComponent<Camera>();
        movCam.AddComponent<CamFps>();
        movCam.transform.SetParent(heroe.transform);
        heroe.transform.position = new Vector3(rnd.Next(5, 24), 0.5f, rnd.Next(5, 24));

        int cantidad = rnd.Next(minimo, maximo); //random para crear personajes
        for (int i = 0; i < cantidad; i++) //for para crear numero de personajes
        {
            int escojer = rnd.Next(0, 2); //segun random se crea un zombi o ciudadano
            if (escojer == 0) //si es cero crea zombi
            {
                zombi = GameObject.CreatePrimitive(PrimitiveType.Cube); 
                zombi.AddComponent<NamNPC.NamEnemy.Zombi>();
                zombi.transform.position = zombi.GetComponent<NamNPC.NamEnemy.Zombi>().mov; //da posicion al zombi
                utilZombi = zombi.GetComponent<NamNPC.NamEnemy.Zombi>().utilZom;
                zombi.GetComponent<Renderer>().material.color = utilZombi.colorZombi;
                zombi.AddComponent<Rigidbody>();
                zombi.name = "Zombi";
            }
            else //si no crea un ciudadano
            {
                ciudadano = GameObject.CreatePrimitive(PrimitiveType.Cube);
                ciudadano.AddComponent<NamNPC.NamAlly.Ciudadano>();
                ciudadano.transform.position = ciudadano.GetComponent<NamNPC.NamAlly.Ciudadano>().ubic;
                ciudadano.AddComponent<Rigidbody>();
                ciudadano.name = "Ciudadanito";
            }
        }
        
        numZomb = 0; //variable para contar los zombis
        foreach (Zombi i in Transform.FindObjectsOfType<Zombi>()) //si el objeto de la escena tiene el componente zombi, que cuente 1
        {
            numZomb += 1;
        }
        contZombi.text = "Zombi: " + numZomb; //para mostrar la cantidad de zombis en pantalla
        
        numCiud = 0; //variable para contar los zombis
        foreach (NamNPC.NamAlly.Ciudadano i in Transform.FindObjectsOfType<NamNPC.NamAlly.Ciudadano>()) //si el objeto de la escena tiene el componente ciudadano, que cuente 1
        {
            numCiud += 1;
        }
        contCiud.text = "Ciudadano: " + numCiud; //para mostrar la cantidad de ciudadanos en pantalla
    }

    
}

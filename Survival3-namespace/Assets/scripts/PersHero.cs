using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NamNPC;
using System;

public class PersHero : MonoBehaviour
{
    NamNPC.NamEnemy.DatosZom utilZomb; //variable tipo estructura de zombi
    NamNPC.NamAlly.DatosCiud utilCiu;
    System.Random rnd = new System.Random(); //variable tipo random para dar velocidad al heroe
    public readonly float velhero;
    public PersHero() //constructor
    {
        velhero = rnd.Next(1, 2);
    }

    void OnCollisionEnter(Collision colision) //funcion para identificsr la colision con un zombi o ciudadano
    {
        if (colision.transform.name == "Zombi") //si choca con un zombi
        {
            utilZomb = colision.gameObject.GetComponent<NamNPC.NamEnemy.Zombi>().utilZom; //asigna lo datos a la variable de tipo estructura de zombi
            Debug.Log("waaarrrr quiero comer " + utilZomb.queComer);
        }
        else if (colision.transform.name == "Ciudadanito") //si choca con un ciudadano
        {
            utilCiu = colision.gameObject.GetComponent<NamNPC.NamAlly.Ciudadano>().utilCiud; //asigna lo datos a la variable de tipo estructura de ciudadano
            Debug.Log("hola soy " + utilCiu.varNombrs + " y tengo " + utilCiu.edadCiudd);
        }
    }
}

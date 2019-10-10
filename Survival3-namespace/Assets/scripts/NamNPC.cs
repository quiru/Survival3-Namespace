    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


namespace NamNPC //namespace para guardar los namespace de zombi y ciudadano
{
    
   namespace NamAlly //namespace para guardar la clase del ciudadano
   {
        public class Ciudadano : MonoBehaviour //clase ciudadano
        {
            public DatosCiud utilCiud; //variable tipo estructura ciudadano para utilizar los datos
            public Vector3 ubic;
            void Awake()
            {
                utilCiud.edadCiudd = Random.Range(15, 101); //random para asignar una edad al ciudadano
                int darNomb = Random.Range(0, 21); //random para asignar un nombre al ciudadano del enum de nombres
                utilCiud.varNombrs = (DatosCiud.nombreCiudd)darNomb; //asigna nombre
                ubic = new Vector3(Random.Range(1, 20), 0.5f, Random.Range(1, 20));
            }
            
        }
        public struct DatosCiud //estructura de ciudadano para datos
        {
            public enum nombreCiudd //enum para posibles nombres de ciudadano
            {
                rolando, josue, jaimito, romualdo, dioselina, maripan, consepcion, pancracia, leocadio, anzisar, juvenal, arturito, casilda, zacarin, antanas, gargamel, marucha, enriqueta, sinthia, anastasia
            }
            public nombreCiudd varNombrs; //variable de tipo enum para los nombres

            public int edadCiudd;
        }
    }

    namespace NamEnemy //namespace para guardar la clase zombi
    {
        public class Zombi : MonoBehaviour //clase zombi
        {
            public DatosZom utilZom; //variable tipo estructura de zombi para manejar los datos
            public Vector3 mov;
            public int cambiaMov;
            float velRand;
            int cambiaRot;

            void Awake()
            {
                int numColor = Random.Range(1, 4); //random para dar color segun numero
                switch (numColor)
                {
                    case 1:
                        utilZom.colorZombi = Color.cyan;
                        break;
                    case 2:
                        utilZom.colorZombi = Color.magenta;
                        break;
                    case 3:
                        utilZom.colorZombi = Color.green;
                        break;
                }

                int darGusto = Random.Range(0, 5);
                utilZom.queComer = (DatosZom.Gusto)darGusto; //da gusto al zombi de enum
                mov = new Vector3(Random.Range(1, 20), 0.5f, Random.Range(1, 20));
                cambiaMov = 0;
                velRand = Random.Range(1f, 2f);
                cambiaRot = 0;
            }

            void Start()
            {
                int daEstado = Random.Range(1, 4); //inicializa los estados 
                utilZom.estado = (DatosZom.Estados)daEstado;

                StartCoroutine("cambioEstado"); //inicializa la corrutina para cambiar de estado
            }

            void Update()
            {
                switch (utilZom.estado) //switch para decir que hcer al zombi
                {
                    case DatosZom.Estados.rotating:
                        if (cambiaRot == 0) //si cambiaRot es cero rota hacia un lado si no hacia el otro
                        {
                            transform.eulerAngles += new Vector3(0, 0.5f, 0);
                        }
                        else
                        {
                            transform.eulerAngles -= new Vector3(0, 0.5f, 0);
                        }
                        break;
                    case DatosZom.Estados.moving:
                        if (cambiaMov == 0) //si  cambiaMov es 0 se mueve hacia un lado y asi sucesivamente
                        {
                            transform.position += new Vector3(0, 0, velRand * Time.deltaTime);
                        }
                        else if (cambiaMov == 1)
                        {
                            transform.position -= new Vector3(0, 0, velRand * Time.deltaTime);
                        }
                        else if (cambiaMov == 2)
                        {
                            transform.position -= new Vector3(velRand * Time.deltaTime, 0, 0);
                        }
                        else if (cambiaMov == 3)
                        {
                            transform.position += new Vector3(velRand * Time.deltaTime, 0, 0);
                        }
                        break;
                    case DatosZom.Estados.idle:
                        transform.position += new Vector3(0, 0, 0);
                        break;
                }
            }

            IEnumerator cambioEstado() //corrutina para cambiar de estado
            {
                while (true)
                {
                    if (utilZom.estado == (DatosZom.Estados)0)
                    {
                        utilZom.estado = (DatosZom.Estados)1;
                        cambiaMov = Random.Range(0, 4);
                    }
                    else if (utilZom.estado == (DatosZom.Estados)1)
                    {
                        utilZom.estado = (DatosZom.Estados)2;
                    }
                    else
                    {
                        utilZom.estado = (DatosZom.Estados)0;
                        cambiaRot = Random.Range(0, 2);
                    }
                    yield return new WaitForSeconds(3);
                }
            }
        }
        public struct DatosZom //estructura de ciudadano para guardar sus datos
        {
            public Color colorZombi;

            public enum Gusto
            {
                culito, deditos, uñas, teticas, homoplato
            }
            public Gusto queComer;

            public enum Estados
            {
                rotating, moving, idle 
            }
            public Estados estado;
        }
    }
}

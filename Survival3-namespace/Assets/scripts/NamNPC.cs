    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


namespace NamNPC
{
    
   namespace NamAlly
   {
        public class Ciudadano : MonoBehaviour
        {
            public DatosCiud utilCiud;
            public Vector3 ubic;
            void Awake()
            {
                utilCiud.edadCiudd = Random.Range(15, 101);
                int darNomb = Random.Range(0, 21);
                utilCiud.varNombrs = (DatosCiud.nombreCiudd)darNomb;
                ubic = new Vector3(Random.Range(1, 20), 0.5f, Random.Range(1, 20));
            }
            
        }
        public struct DatosCiud
        {
            public enum nombreCiudd
            {
                rolando, josue, jaimito, romualdo, dioselina, maripan, consepcion, pancracia, leocadio, anzisar, juvenal, arturito, casilda, zacarin, antanas, gargamel, marucha, enriqueta, sinthia, anastasia
            }
            public nombreCiudd varNombrs;

            public int edadCiudd;
        }
    }

    namespace NamEnemy
    {
        public class Zombi : MonoBehaviour
        {
            public DatosZom utilZom;
            public Vector3 mov;
            public int cambiaMov;
            float velRand;
            int cambiaRot;

            void Awake()
            {
                int numColor = Random.Range(1, 4);
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
                utilZom.queComer = (DatosZom.Gusto)darGusto;
                mov = new Vector3(Random.Range(1, 20), 0.5f, Random.Range(1, 20));
                cambiaMov = 0;
                velRand = Random.Range(1f, 2f);
                cambiaRot = 0;
            }

            void Start()
            {
                int daEstado = Random.Range(1, 4);
                utilZom.estado = (DatosZom.Estados)daEstado;

                StartCoroutine("cambioEstado");
            }

            void Update()
            {
                switch (utilZom.estado)
                {
                    case DatosZom.Estados.rotating:
                        if (cambiaRot == 0)
                        {
                            transform.eulerAngles += new Vector3(0, 0.5f, 0);
                        }
                        else
                        {
                            transform.eulerAngles -= new Vector3(0, 0.5f, 0);
                        }
                        break;
                    case DatosZom.Estados.moving:
                        if (cambiaMov == 0)
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

            IEnumerator cambioEstado()
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
        public struct DatosZom
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

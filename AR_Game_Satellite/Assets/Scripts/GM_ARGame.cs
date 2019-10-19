using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GM_ARGame : MonoBehaviour
{
    #region Singleton for the AR Game
    private static GM_ARGame instance;
    public static GM_ARGame Instance { get => instance;}
    #endregion

    public TextMeshProUGUI txtDebug; //The text to show what object are colliding


    public List<GameObject> curImgTargetContact; //The list of objects that are colliding

    [Header("The imagr targets")]
    public List<GameObject> theTargets;

    List<GameObject> orderedTargets;


    // Start is called before the first frame update
    void Start()
    {
        instance = this; //Singleton

        curImgTargetContact = new List<GameObject>();
        orderedTargets = new List<GameObject>();

        //obtener de forma aleatoria la primera carta y aniadirla a la lista de
        //targets ordenados

        //Elegir de forma aleatoria cualquiera de sus colliders hijos para
        //establecer cual de ellos hara match

        //Repetir proceso hasta que la lista "theTargets este vacia"


        
        //Ahora de la lista ordenada, elegir de forma aleatoria una carta
        //Teniendo la carta elegida, escoger otra carta de la lista y preguntar si el collider hijo
        //que hara match no tiene establecido la carta con quien hara match
        //ciclo while(mientras los 5 matches no esten establecidos, corre el ciclo)
            //Si no lo tiene establecido
                //ponerlo como carta que hara match (parentName), en ambas cartas
                //poner el nombre del collider hijo (colMatchName), en ambas cartas
                //Ahora de la lista ordenada, elegir cual carta no tiene match 
                //Sumar 1 al total de matches por hacer, hay que tener 5
            //Ya tiene establecido
                //Escoger otra carta para hacer match
               





        txtDebug.gameObject.SetActive(false);
    }




    public void TargetsCollision()
    {
        txtDebug.gameObject.SetActive(true);
        string nameTargets = "";
        for (int i = 0; i < curImgTargetContact.Count; i++)
        {
            nameTargets += curImgTargetContact[i].name;
        }

        txtDebug.text = "Los targets que colisionan: " + nameTargets;
    }

    public void DisableText()
    {
        txtDebug.text = "";
        txtDebug.gameObject.SetActive(false);
    }
}

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

    public List<GameObject> orderedTargets;


    // Start is called before the first frame update
    void Start()
    {
        instance = this; //Singleton

        curImgTargetContact = new List<GameObject>();
        orderedTargets = new List<GameObject>();

        //obtener de forma aleatoria la primera carta y aniadirla a la lista de
        //targets ordenados


        int twice = 2;
        for (int i = 0; i < theTargets.Count; i++)
        {
            //Elegir de forma aleatoria cualquiera de sus colliders hijos para
            //establecer cual de ellos hara match
            while(twice > 0)
            {
                int randCol = Random.Range(0, 4);
                if (!theTargets[i].transform.GetChild(randCol).GetComponent<MatchAttributes>().match)
                {
                    Debug.LogError("Colisionador seleccionado: " + randCol);
                    theTargets[i].transform.GetChild(randCol).GetComponent<MatchAttributes>().match = true;
                    twice--;
                }
            }
            twice = 2;

        }


        int rand = Random.Range(0, theTargets.Count);
        GameObject targetSelected = theTargets[rand];
        Debug.LogError("Tarjeta seleccionada: " + targetSelected.name);
        orderedTargets.Add(targetSelected);
        theTargets.Remove(targetSelected);

        

        /*int randOredered = Random.Range(0, orderedTargets.Count);
        GameObject orderTargetSelected = orderedTargets[randOredered];
        Debug.LogError("Hare match con: " + orderTargetSelected.name);*/

        bool checkOtherCard = true;
        int cardsMatched = 0;
        int randColSelected = 0;
        while (checkOtherCard)
        {
            if(theTargets.Count == 0)
            {
                checkOtherCard = false;
            }
            else
            {
                rand = Random.Range(0, theTargets.Count);
                targetSelected = theTargets[rand];
                Debug.LogError("\nTarjeta seleccionada: " + targetSelected.name);

                int randOredered = Random.Range(0, orderedTargets.Count);
                GameObject orderTargetSelected = orderedTargets[randOredered];
                Debug.LogError("Hare match con: " + orderTargetSelected.name);

                for (int i = 0; i < orderTargetSelected.transform.childCount; i++)
                {
                    if (orderTargetSelected.transform.GetChild(i).GetComponent<MatchAttributes>().match &&
                        orderTargetSelected.transform.GetChild(i).GetComponent<MatchAttributes>().parentName == null)
                    {
                        Debug.LogError("Hijo disponible de tarjeta ordenada: "+ orderTargetSelected.transform.GetChild(i).name);

                        bool untilDone = false;
                        while(!untilDone)
                        {
                            //Elegir de forma aleatoria cualquiera de sus colliders hijos para
                            //establecer cual de ellos hara match
                            randColSelected = Random.Range(0, targetSelected.transform.childCount);
                            
                            if (!targetSelected.transform.GetChild(randColSelected).GetComponent<MatchAttributes>().match)
                            {
                                Debug.LogError("Colisionador seleccionado: " + randColSelected);
                                targetSelected.transform.GetChild(randColSelected).GetComponent<MatchAttributes>().match = true;
                                //times--;
                                untilDone = true;
                            }
                        }

                        orderTargetSelected.transform.GetChild(i).GetComponent<MatchAttributes>().parentName = targetSelected.name;

                        orderTargetSelected.transform.GetChild(i).GetComponent<MatchAttributes>().colMatchName = targetSelected.transform.GetChild(randColSelected).name;

                        targetSelected.transform.GetChild(randColSelected).GetComponent<MatchAttributes>().parentName = orderTargetSelected.name;
                        targetSelected.transform.GetChild(randColSelected).GetComponent<MatchAttributes>().colMatchName = orderTargetSelected.transform.GetChild(i).name;

                        orderedTargets.Add(targetSelected);
                        theTargets.Remove(targetSelected);

                        cardsMatched++;
                        i = orderTargetSelected.transform.childCount;
                    }
                    if (i == orderTargetSelected.transform.childCount - 1)
                    {
                        Debug.LogError("Ya estan ocupados todos los hijos");
                    }
                }
            }  
        }



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

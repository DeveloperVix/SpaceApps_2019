using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionImg : MonoBehaviour
{
    public MatchAttributes matchAttributes;

    private void Awake()
    {
        matchAttributes = gameObject.AddComponent<MatchAttributes>();
    }

    //We need to know when the part of the target is colliding with other image
    void OnTriggerEnter(Collider obj) 
    {
        //NOTE: is necessary to know if it is another image target
        matchAttributes.colliding = true;
        Debug.Log("Colisiono con: " + obj.gameObject.name);
        GM_ARGame.Instance.curImgTargetContact.Add(obj.gameObject); //Add to the list of the obj
        GM_ARGame.Instance.TargetsCollision();                      //Call the method to show the text

    }

    //If the targets stop colliding 
    private void OnTriggerExit(Collider obj)
    {
        matchAttributes.colliding = false;
        //Remove the object from the list of objects that are colliding
        GM_ARGame.Instance.curImgTargetContact.Remove(obj.gameObject);
        //Disable the text
        GM_ARGame.Instance.DisableText();
    }
}

public class MatchAttributes : MonoBehaviour
{
    public bool colliding;
    public bool match;//Set this variable true if be the col match

    public string parentName; //Wich card need to match
    public string colMatchName; //Wich child collider need to match
}

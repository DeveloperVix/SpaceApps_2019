﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionImg : MonoBehaviour
{
    public MatchAttributes matchAttributes;

    public string nameParent;

    public SpriteRenderer spriteFeedback;

    public bool satellite = true;

    private void Awake()
    {
        matchAttributes = gameObject.AddComponent<MatchAttributes>();
        nameParent = transform.parent.name;

        spriteFeedback = GetComponentInChildren<SpriteRenderer>();
        spriteFeedback.color = Color.red;
    }

    //We need to know when the part of the target is colliding with other image
    void OnTriggerEnter(Collider obj) 
    {
        //NOTE: is necessary to know if it is another image target
        if (obj.GetComponent<MatchAttributes>().parentName != null)
        {
            if (obj.GetComponent<MatchAttributes>().parentName == nameParent)
            {
                matchAttributes.colliding = true;
                spriteFeedback.color = Color.green;
                Debug.Log("Colisiono con: " + obj.gameObject.name);
                GM_ARGame.Instance.curImgTargetContact.Add(obj.gameObject); //Add to the list of the obj
                //GM_ARGame.Instance.TargetsCollision();                      //Call the method to show the text
                GM_ARGame.Instance.CountColision(satellite);
            }
        }
    }

    //If the targets stop colliding 
    private void OnTriggerExit(Collider obj)
    {   
        //Disable the text
        //GM_ARGame.Instance.DisableText();

        if (obj.GetComponent<MatchAttributes>().parentName != null)
        {
            if (obj.GetComponent<MatchAttributes>().parentName == nameParent)
            {
                matchAttributes.colliding = false;
                spriteFeedback.color = Color.red;
                //Remove the object from the list of objects that are colliding
                GM_ARGame.Instance.curImgTargetContact.Remove(obj.gameObject);
                //GM_ARGame.Instance.TargetsCollision();                      //Call the method to show the text
                GM_ARGame.Instance.LessCountColision(satellite);
            }
        }
    }
}

public class MatchAttributes : MonoBehaviour
{
    public bool colliding;
    public bool match;//Set this variable true if be the col match

    public string parentName; //Wich card need to match
    public string colMatchName; //Wich child collider need to match
}

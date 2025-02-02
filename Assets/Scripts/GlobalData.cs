﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


///// Optional (able)
// 0 - fire {1,0}
// 1 - take {1,0}
// 2 - impact {1,0}
// 3 - shoot {1,0}
// 4 - decrafting {1,0}
///// Variable 
// 5 - mass {1 ... 9}
// 6 - strong lvl {1 ... 9}
// 7 - eat lvl {1 ... 9}
// 8 - HV(Health & Venom) lvl {1 ... 9}
// 9..11 - Element id;

public static class GlobalData
{
    //// Inventory data
    public static Dictionary<string, int> inventoryElements = new Dictionary<string, int>();
    public static string rightHand = "";
    public static string leftHand = "";
    
    private static string eTag;
    private static GameObject elementGO;

    // functions utils


    // main functions
    static void takeAction(RaycastHit hit)
    {
        rightHand = hit.transform.tag;
        Object.Destroy(hit.transform.gameObject);
    }
    static void takeToInventoryAction(RaycastHit hit)
    {
        string eTag = hit.transform.tag;
        rightHand = "";
        try {
            inventoryElements[eTag]+=1;
        }
        catch {
            inventoryElements.Add(eTag,1);
        }
    }
    static void useAction(RaycastHit hit)
    {
        string eTag = hit.transform.tag;
        if (leftHand == "")
        {
            if(eTag[3] == '1')
            {
                float x, y, z;
                x = hit.transform.position.x;
                y = hit.transform.position.y;
                z = hit.transform.position.z;
                GameObject newObject,tmp;
                tmp = (GameObject)Resources.Load("prefabs/11100" + eTag[5], typeof(GameObject));
                newObject = GameObject.Instantiate(tmp);
                newObject.transform.position+= new Vector3(x,y,z-0.3f);
                newObject = GameObject.Instantiate(tmp);
                newObject.transform.position+= new Vector3(x,y,z+0.3f);
                //newObject = (GameObject)Resources.Load("prefabs/11100" + eTag[5], typeof(GameObject));
                // newObject = GameObject.Instantiate(GameObject.FindGameObjectWithTag("11100" + eTag[5]));
                // newObject.transform.position = hit.transform.position;
                // newObject = GameObject.Instantiate(GameObject.FindGameObjectWithTag("11100" + eTag[5]));
                // 
                //newObject.transform.position.Set(x,y,z);
                //newObject.transform.rotation = hit.transform.rotation;
                GameObject.Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            if(leftHand == "111001" && rightHand == leftHand)
            {
                hit.transform.Find("Torch").gameObject.SetActive(true);
                hit.transform.tag = "000005";
            }
        }
    }
    public static void doAction(RaycastHit hit)
    {
        eTag = hit.transform.tag;
        
        if(rightHand == "")
        {
            if(eTag[1] == '1')
            {
                takeAction(hit);
            }
        }
        else
        {
            if(rightHand[2] == '1')
            {
                useAction(hit);
            }
        } 

    }
}
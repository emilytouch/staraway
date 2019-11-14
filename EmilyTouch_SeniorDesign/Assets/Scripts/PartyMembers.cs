using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers;

public class PartyMembers : MonoBehaviour
{
    public float relationshipLevel;
    public bool isParty;
    public bool isFriends;
    public bool isMaxed;
    
    // Start is called before the first frame update
    void Start()
    {
        relationshipLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (relationshipLevel <= 0)
        {
            relationshipLevel = 0;
            isParty = true;
        }

        if (relationshipLevel == 50)
        {
            isFriends = true;
        }

        if (relationshipLevel >= 100)
        {
            relationshipLevel = 100;
            isMaxed = true;
        }
    }
}

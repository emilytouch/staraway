﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers;

public class PartyMembers : MonoBehaviour
{
    public float relationshipLevel;
    public bool isParty;
    public bool isFriends;
    public bool isRomanced;
    
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
        }
    }
}

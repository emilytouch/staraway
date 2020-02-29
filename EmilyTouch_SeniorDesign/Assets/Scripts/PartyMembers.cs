using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers;

public class PartyMembers : MonoBehaviour
{
    int relationshipLevel;
    int addRelationship = 5;

    public Text relationshipText;

    public Button[] partyButtons;
    
    bool isParty;
    bool isAcquainted;
    bool isFriends;
    bool isMaxed;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        if (relationshipLevel >= 5)
        {
            isAcquainted = true;
        }

        if (relationshipLevel >= 50)
        {
            isFriends = true;
        }

        if (relationshipLevel >= 100)
        {
            relationshipLevel = 100;
            isMaxed = true;
        }
    }

    public void RelationshipPlus()
    {
        relationshipLevel = relationshipLevel + addRelationship;
    }

    public void RelationshipMinus()
    {
        relationshipLevel = relationshipLevel - addRelationship;
    }

    public void SetRelationshipText()
    {
        relationshipText.text = "{name} support:" + relationshipLevel;
    }

    public void CharacterDescOpen()
    {

    }
}

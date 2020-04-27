using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers;

public class PartyMembers : MonoBehaviour
{
    public int relationshipLevel;
    //int addRelationship = 5;

    public Text relationshipText;
    public Text statusText;
    public Button partyButton;

    string relationshipStatus;
    public string NPCName;
    
    // Start is called before the first frame update
    void Start()
    {
        //relationshipLevel = 0;
        SetRelationshipText();
        SetStatusText();
    }

    // Update is called once per frame
    void Update()
    {

        if (relationshipLevel < 5)
        {
            partyButton.interactable = false;
        }

        else
        {
            partyButton.interactable = true;

        }

        if (relationshipLevel <= 0)
        {
            relationshipLevel = 0;
            relationshipStatus = "Unknown";
            SetRelationshipText();
            SetStatusText();
        }

        if (relationshipLevel >= 5)
        {
            relationshipStatus = "Ally";
            SetStatusText();
            SetRelationshipText();

        }

        if (relationshipLevel >= 50)
        {
            relationshipStatus = "Friend";
            SetStatusText();
            SetRelationshipText();

        }

        if (relationshipLevel >= 100)
        {
            relationshipLevel = 100;
            relationshipStatus = "Partner";
            SetStatusText();
            SetRelationshipText();

        }

        SetRelationshipText();
        SetStatusText();
    }

    private void SetRelationshipText()
    {
        relationshipText.text = "SUPPORT: " + relationshipLevel;
    }

    private void SetStatusText()
    {
        statusText.text = NPCName + ": " + relationshipStatus;
    }

    public void SpaceDogApproval(int addRelationship)
    {
        GameObject.Find("SpaceDogButton").GetComponent<PartyMembers>().relationshipLevel += addRelationship;
        PixelCrushers.DialogueSystem.DialogueManager.ShowAlert("Support " + addRelationship);
    }

    public void AlfanApproval(int addRelationship)
    {
        GameObject.Find("AlfanButton").GetComponent<PartyMembers>().relationshipLevel += addRelationship;
        PixelCrushers.DialogueSystem.DialogueManager.ShowAlert("Support " + addRelationship);
    }
    public void ArcanumApproval(int addRelationship)
    {
        GameObject.Find("ArcanumButton").GetComponent<PartyMembers>().relationshipLevel += addRelationship;
        PixelCrushers.DialogueSystem.DialogueManager.ShowAlert("Support " + addRelationship);
    }
    public void NexisApproval(int addRelationship)
    {
        GameObject.Find("NexisButton").GetComponent<PartyMembers>().relationshipLevel += addRelationship;
        PixelCrushers.DialogueSystem.DialogueManager.ShowAlert("Support " + addRelationship);
    }
    public void ThyApproval(int addRelationship)
    {
        GameObject.Find("ThyButton").GetComponent<PartyMembers>().relationshipLevel += addRelationship;
        PixelCrushers.DialogueSystem.DialogueManager.ShowAlert("Support " + addRelationship);
    }
}
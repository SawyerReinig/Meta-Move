using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PoofGoneHand : MonoBehaviour
{

    public Transform GunBarrell, Sight1, Sight2, Sight3, Receiver, Handle; 
    public Transform RocketTip, RocketBody, RocketBack /*Hand*/; 
    MeshRenderer GunBarrellMesh, Sight1Mesh, Sight2Mesh, Sight3Mesh, ReceiverMesh, HandleMesh, RocketTipMesh, RocketBodyMesh, RocketBackMesh;
    MeshCollider RocketTipColl, RocketBodyColl, RocketBackColl /*HandColl*/;
    BoxCollider  GunBarrellColl, Sight1Coll, Sight2Coll, Sight3Coll, ReceiverColl,  HandleColl;
    //SkinnedMeshRenderer ActualHand;  
    [SerializeField] private InputActionReference TaDaButton;  
    bool HasSkin, HasMesh; 
    int WhatYaHoldin = 1; 

    // Start is called before the first frame update
    void Start()
    {
        
            GunBarrellMesh = GunBarrell.GetComponent<MeshRenderer>();
            Sight1Mesh = Sight1.GetComponent<MeshRenderer>();
            Sight2Mesh = Sight2.GetComponent<MeshRenderer>();
            Sight3Mesh = Sight3.GetComponent<MeshRenderer>();
            ReceiverMesh = Receiver.GetComponent<MeshRenderer>();
            HandleMesh = Handle.GetComponent<MeshRenderer>();
            RocketTipMesh = RocketTip.GetComponent<MeshRenderer>();
            RocketBodyMesh = RocketBody.GetComponent<MeshRenderer>();
            RocketBackMesh = RocketBack.GetComponent<MeshRenderer>();
            //ActualHand = Hand.GetComponent<SkinnedMeshRenderer>();


            GunBarrellColl = GunBarrell.GetComponent<BoxCollider>();
            Sight1Coll = Sight1.GetComponent<BoxCollider>();
            Sight2Coll = Sight2.GetComponent<BoxCollider>();
            Sight3Coll = Sight3.GetComponent<BoxCollider>();
            ReceiverColl = Receiver.GetComponent<BoxCollider>();
            HandleColl = Handle.GetComponent<BoxCollider>();
            RocketTipColl = RocketTip.GetComponent<MeshCollider>();
            RocketBodyColl = RocketBody.GetComponent<MeshCollider>();
            RocketBackColl = RocketBack.GetComponent<MeshCollider>();
            // HandColl = Hand.GetComponent<MeshCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        TaDaButton.action.performed += HandGone_F;
    }

    private void HandGone_F(InputAction.CallbackContext obj)
    {
      WhatYaHoldin++;
      if(WhatYaHoldin == 1){ //gun
        GunBarrellMesh.enabled = true;
        Sight1Mesh.enabled = true;
        Sight2Mesh.enabled = true;
        Sight3Mesh.enabled = true;
        ReceiverMesh.enabled = true;
        HandleMesh.enabled = true;
        RocketTipMesh.enabled = false; 
        RocketBodyMesh.enabled = false;
        RocketBackMesh.enabled = false;
        //ActualHand.enabled = false;

        GunBarrellColl.enabled = true;
        Sight1Coll.enabled = true;
        Sight2Coll.enabled = true;
        Sight3Coll.enabled = true;
        ReceiverColl.enabled = true;
        HandleColl.enabled = true;
        RocketTipColl.enabled = false; 
        RocketBodyColl.enabled = false;
        RocketBackColl.enabled = false;
        //HandColl.enabled = false;

      }
      if(WhatYaHoldin == 2){ //rocket
        GunBarrellMesh.enabled = false;
        Sight1Mesh.enabled = false;
        Sight2Mesh.enabled = false;
        Sight3Mesh.enabled = false;
        ReceiverMesh.enabled = false;
        HandleMesh.enabled = false;
        RocketTipMesh.enabled = true; 
        RocketBodyMesh.enabled = true;
        RocketBackMesh.enabled = true;
        //ActualHand.enabled = false;


        GunBarrellColl.enabled = false;
        Sight1Coll.enabled = false;
        Sight2Coll.enabled = false;
        Sight3Coll.enabled = false;
        ReceiverColl.enabled = false;
        HandleColl.enabled = false;
        RocketTipColl.enabled = true; 
        RocketBodyColl.enabled = true;
        RocketBackColl.enabled = true;
        //HandColl.enabled = false;

        WhatYaHoldin = 0; 

      }
      // if(WhatYaHoldin == 3){ //hand
      //   GunBarrellMesh.enabled = false;
      //   Sight1Mesh.enabled = false;
      //   Sight2Mesh.enabled = false;
      //   Sight3Mesh.enabled = false;
      //   ReceiverMesh.enabled = false;
      //   HandleMesh.enabled = false;
      //   RocketTipMesh.enabled = false; 
      //   RocketBodyMesh.enabled = false;
      //   RocketBackMesh.enabled = false;
      //   ActualHand.enabled = true;

      //    GunBarrellColl.enabled = false;
      //   Sight1Coll.enabled = false;
      //   Sight2Coll.enabled = false;
      //   Sight3Coll.enabled = false;
      //   ReceiverColl.enabled = false;
      //   HandleColl.enabled = false;
      //   RocketTipColl.enabled = false; 
      //   RocketBodyColl.enabled = false;
      //   RocketBackColl.enabled = false;
      //   HandColl.enabled = true;


      // }
    }

}

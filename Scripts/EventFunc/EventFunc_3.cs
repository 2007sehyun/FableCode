using Cinemachine.Utility;
using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventFunc_3 : EventFuncs
{
    [SerializeField] private GameObject fairyParticle;
   
    public override void Event_1(int noteIndex)
    {
        GameObject newFairyParticle = Instantiate(fairyParticle, player.transform.position, Quaternion.identity);
        newFairyParticle.transform.SetParent(player.transform);
    }


    public override void Event_2(int noteIndex)
    {
    }

    public override void Event_3(int noteIndex)
    {
    }
}
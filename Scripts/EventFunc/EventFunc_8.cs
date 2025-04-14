using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFunc_8 : EventFuncs
{
    [SerializeField] private GameObject _levelUpEffect;
    public override void Event_1(int noteIndex)
    {
        GameObject newFairyParticle = Instantiate(_levelUpEffect, player.transform.position, Quaternion.identity);
        newFairyParticle.transform.SetParent(player.transform);
    }
    public override void Event_2(int noteIndex)
    {
    }
    public override void Event_3(int noteIndex)
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFunc_4 : EventFuncs
{

    [SerializeField] private GameObject RockPre;

    public override void Event_1(int noteIndex)
    {
        GameObject rock = Instantiate(RockPre,player.noteQ.GetNote(1).transform.position + new Vector3(0,6,-1f) , Quaternion.identity);

        rock.transform.localScale *= 3f;
        rock.AddComponent<BoxCollider>();
        rock.AddComponent<Rigidbody>().mass = 4;

        Destroy(rock, 2);
    }

    public override void Event_2(int noteIndex)
    {
    }

    public override void Event_3(int noteIndex)
    {
    }
}

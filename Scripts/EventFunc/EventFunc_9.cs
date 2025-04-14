using System.Collections;
using UnityEngine;

public class EventFunc_9 : EventFuncs
{
    [SerializeField] private GameObject pocJuc;

    private PoolManager poolManager;

    private void Start()
    {
        poolManager = FindObjectOfType<PoolManager>();
    }

    public override void Event_1(int noteIndex)
    {
        Note note;
        int cnt = 1;
        do
        {
            note = player.noteQ.GetNote(cnt);
            cnt++;
        }
        while (note is TurnNote);
        GameObject fanfare = poolManager.GetObject("Fanfare");
        fanfare.transform.position = note.transform.position;
        fanfare.GetComponentInChildren<ParticleSystem>().Play(); //풀매니저에 오브젝트 넣어놔라
        //fanfare.transform.position = player.transform.position;
        //fanfare.transform.rotation = player.transform.rotation;

        if(Random.Range(0, 2) == 0)
        {
            if (note.transform.eulerAngles.y == 270 || note.transform.eulerAngles.y == 90)
            {
                fanfare.transform.position += new Vector3(0f, 0f, 2f);
                fanfare.transform.eulerAngles = new Vector3(0, 45f, 0);
            }
            else
            {
                fanfare.transform.position += new Vector3(2f, 0f, 0f);
                fanfare.transform.eulerAngles = new Vector3(0, 135f, 0);
            }
        }
        else
        {
            if (note.transform.eulerAngles.y == 270 || note.transform.eulerAngles.y == 90)
            {
                fanfare.transform.position += new Vector3(0f, 0f, -2f);
                fanfare.transform.eulerAngles = new Vector3(0, 135f, 0);
            }
            else
            {
                fanfare.transform.position += new Vector3(-2f, 0f, 0f);
                fanfare.transform.eulerAngles = new Vector3(0, -135f, 0);
            }
        }

        StartCoroutine(DestroyFanfare(fanfare));
    }

    private IEnumerator DestroyFanfare(GameObject fanfare)
    {
        yield return new WaitForSeconds(1f);
        poolManager.SetObject("Fanfare", fanfare);
    }

    public override void Event_2(int noteIndex)
    {
        
    }
    public override void Event_3(int noteIndex)
    {
    }
}

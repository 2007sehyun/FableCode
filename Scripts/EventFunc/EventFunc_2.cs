using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

public class EventFunc_2 : EventFuncs
{
    [SerializeField] private GameObject rabbit;
    public override void Event_1(int noteIndex)
    {
        float eventTime = 0f;
        if (Information.Instance.currentDiff == DifficultType.Dream || Information.Instance.currentDiff == DifficultType.Fairy)
        {
            eventTime = 120f / Information.Instance.currentSong.SongBPM;
        }
        else
        {
            eventTime = 60f / Information.Instance.currentSong.SongBPM;
        }

        Vector3 center = player.noteQ.GetNote(1).transform.position;
        Vector3 startPos = new Vector3();
        Vector3 endPos = new Vector3();



        if (player.transform.rotation.y == 0)
        {
            startPos = center + new Vector3(3f, 0, 0);
            endPos = center + new Vector3(-3f, 0, 0);
        }
        else
        {
            startPos = center + new Vector3(0, 0, 3f);
            endPos = center + new Vector3(0, 0, -3f);
        }

        RabbitCreateJump(eventTime, ref startPos, ref endPos);
    }

    private void RabbitCreateJump(float eventTime, ref Vector3 startPos, ref Vector3 endPos)
    {
        if (Random.Range(0, 2) == 1)
        {
            Vector3 temp = startPos;
            startPos = endPos;
            endPos = temp;
        }

        GameObject rabbitpre = Instantiate(rabbit, startPos, Quaternion.identity);
        rabbitpre.transform.localScale = Vector3.one * 0.25f;
        Vector3 direction = endPos - startPos;
        rabbitpre.transform.rotation = Quaternion.LookRotation(direction);
        rabbitpre.transform.DOJump(endPos, 4.5f, 1, eventTime).OnComplete(() =>
        {
            Destroy(rabbitpre, 2f);
            rabbitpre.transform.DOMoveY(rabbitpre.transform.position.y - 10f, 2f);
        });
    }

    public override void Event_2(int noteIndex)
    {
        float eventTime = 0f;
        if (Information.Instance.currentDiff == DifficultType.Dream || Information.Instance.currentDiff == DifficultType.Fairy)
        {
            eventTime = 120f / Information.Instance.currentSong.SongBPM;
        }
        else
        {
            eventTime = 60f / Information.Instance.currentSong.SongBPM;
        }
        Vector3 center = player.noteQ.GetNote(6).transform.position;
        center.y += 0.5f;
        Vector3 startPos = new Vector3();
        Vector3 endPos = new Vector3();



        if (player.transform.rotation.y == 0)
        {
            startPos = center + new Vector3(2f, 0, 0);
            endPos = center + new Vector3(-2f, 0, 0);
        }
        else
        {
            startPos = center + new Vector3(0, 0, 2f);
            endPos = center + new Vector3(0, 0, -2f);
        }
        RabbitJumpStay(eventTime , startPos , endPos, center);
    }

    private void RabbitJumpStay(float eventTime , Vector3 startPos, Vector3 endPos, Vector3 center)
    {
        if (Random.Range(0, 2) == 1)
        {
            Vector3 temp = startPos;
            startPos = endPos;
            endPos = temp;
        }

        GameObject rabbitpre = Instantiate(rabbit, startPos, Quaternion.identity);
        rabbitpre.transform.localScale = Vector3.one * 0.25f;
        Vector3 direction = endPos - startPos;
        Vector3 playerDir = player.transform.position - rabbitpre.transform.position;
        Quaternion lookDir = Quaternion.LookRotation(playerDir);
        Quaternion originDir = Quaternion.LookRotation(direction);

        Sequence seq = DOTween.Sequence();
        rabbitpre.transform.rotation = Quaternion.LookRotation(direction.normalized);
        seq.Append(rabbitpre.transform.DOJump(center, 2f, 1, eventTime));
        //seq.Append(rabbitpre.transform.DORotateQuaternion(lookDir, eventTime/2f));
        seq.AppendInterval(eventTime);
        //seq.Append(rabbitpre.transform.DORotateQuaternion(originDir, eventTime/2f));
        seq.Append(rabbitpre.transform.DOJump(endPos, 2f, 1, eventTime));

        seq.Append(rabbitpre.transform.DOMoveY(rabbitpre.transform.position.y - 10f, 2f));
        seq.JoinCallback(()=> Destroy(rabbitpre, 2f));
    }

    public override void Event_3(int noteIndex)
    {
    }
}

using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class EventFunc_1 : EventFuncs
{
    public List<GameObject> cookiePositions { get; private set; } = new List<GameObject>();

    private PoolManager poolManager;
    private float moveTime;

    private void Start()
    {
        poolManager = FindObjectOfType<PoolManager>();
        moveTime = Information.Instance.currentDiff == DifficultType.Nightmare ? 0.1f : 0.2f;
    }

    // 쿠키 생성 및 이동 함수
    private void CreateAndMoveCookies()
    {
        GameObject ginger = poolManager.GetObject("Cookie");
        ginger.transform.forward = player.transform.forward;
        ginger.transform.position = player.transform.position + new Vector3(0, 1, 0);
        cookiePositions.Add(ginger);

        foreach (GameObject cookie in cookiePositions)
        {

            cookie.transform.DOMove(cookie.transform.position -= cookie.transform.forward * 0.2f, moveTime); // duratino = song BPM 넣기 ../ 뭐시기
        }
    }

    public void Pusback(GameObject obj)
    {
        cookiePositions.Remove(obj);
    }

    public override void Event_1(int noteIndex)
    {
        CreateAndMoveCookies();
    }

    public override void Event_2(int noteIndex)
    {
    }

    public override void Event_3(int noteIndex)
    {
    }
}

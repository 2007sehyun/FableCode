using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class EndEvent : MonoBehaviour
{
    protected PlayerInput player;
    protected CamManager cam;
    protected RhythmGameManager rhythmGameManager;

    [SerializeField] private GameObject fableLaserPre;
    [SerializeField] private GameObject golemPre;
    [SerializeField] private GameObject blinkPre;
    [SerializeField] private GameObject Witch;
    [SerializeField] private GameObject popEffect;
    [SerializeField] private Light directionalLight2;


    private void Awake()
    {
        player = FindObjectOfType<PlayerInput>();
        cam = FindObjectOfType<CamManager>();
        rhythmGameManager = FindObjectOfType<RhythmGameManager>();
    }

    public void EndEventHandle()
    {
        switch (Information.Instance.currentSong.SongID)
        {
            case 0:
                StartCoroutine(EndEvent_0());
                break;
            case 1:
                StartCoroutine(EndEvent_1());
                break;
            case 2:
                StartCoroutine(EndEvent_2());
                break;
            case 3:
                StartCoroutine(EndEvent_3());
                break;
            case 4:
                StartCoroutine(EndEvent_4());
                break;
            case 5:
                StartCoroutine(EndEvent_5());
                break;
            case 6:
                StartCoroutine(EndEvent_6());
                break;
            case 7:
                StartCoroutine(EndEvent_7());
                break;
            case 8:
                StartCoroutine(EndEvent_8());
                break;
            case 9:
                StartCoroutine(EndEvent_9());
                break;
        }
    }

    private IEnumerator EndEvent_0()
    {
        yield return null;
        rhythmGameManager.GoResultScene();
    }

    private IEnumerator EndEvent_1()
    {
        Vector3 targetPlayerPos = player.transform.position + player.transform.forward * 5;
        Vector3 leftRot = new Vector3((cam.transform.localEulerAngles.x - 18), (cam.transform.localEulerAngles.y - 16), 0);
        Vector3 rightRot = new Vector3((cam.transform.localEulerAngles.x - 18), (cam.transform.localEulerAngles.y + 32), 0);

        Sequence sq1 = DOTween.Sequence();
        sq1.Append(cam.transform.DOMove(targetPlayerPos, 2f));
        sq1.Append(cam.transform.DOLocalRotate(leftRot, 2f).SetEase(Ease.OutFlash));
        sq1.Append(cam.transform.DOLocalRotate(rightRot, 2f).SetEase(Ease.OutFlash));

        yield return new WaitForSeconds(6f);
        rhythmGameManager.GoResultScene();
    }

    private IEnumerator EndEvent_2()
    {
        Vector3 targetPlayerPos = player.transform.position + player.transform.forward * 4;

        Vector3 targetCamPos = cam.transform.position + new Vector3(0, 0, 8);
        Vector3 targetCamRot = new Vector3(-35, 0, 0);

        Sequence sq2 = DOTween.Sequence();
        // sq2.Append(player.transform.DOMove(targetPlayerPos, 4f));
        sq2.Append(cam.transform.DOMove(targetCamPos, 4f));
        sq2.Join(cam.transform.DORotate(targetCamRot, 4f));

        yield return new WaitForSeconds(5f);
        rhythmGameManager.GoResultScene();
    }



    private IEnumerator EndEvent_3()
    {
        //°ñ·½ º¸¿©Áö±â

        Vector3 targetCamPos = cam.transform.position + cam.transform.forward * -4 + cam.transform.up * 6;
        Vector3 targetCamRot = new Vector3(-40, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);

        Sequence sq2 = DOTween.Sequence();
        sq2.Append(cam.transform.DOMove(targetCamPos, 4f));
        sq2.Join(cam.transform.DORotate(targetCamRot, 4f));



        yield return new WaitForSeconds(5f);
        rhythmGameManager.GoResultScene();
    }

    private IEnumerator EndEvent_4()
    {
        Instantiate(golemPre, player.transform.position + player.transform.forward * 12, Quaternion.Euler(0, player.transform.localEulerAngles.y + 180, 0));
        Vector3 targetCamPos = cam.transform.position + new Vector3(0, 6, 0) + cam.transform.forward * -4;
        Vector3 targetCamRot = new Vector3(-40, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);


        Sequence sq2 = DOTween.Sequence();
        sq2.Append(cam.transform.DOLocalMove(targetCamPos, 4f));
        sq2.Join(cam.transform.DORotate(targetCamRot, 4f));
        yield return new WaitForSeconds(6.5f);
        sq2.Append(cam.transform.DOShakePosition(1f, 2));
        player.transform.GetChild(3).gameObject.SetActive(false);
        sq2.Join(player.transform.DOMove(player.transform.position + new Vector3(0, 80, 0) + player.transform.forward * -4, 1.5f));
        cam.GetComponentInChildren<CinemachineVirtualCamera>().LookAt = player.transform;
        yield return new WaitForSeconds(1.5f);                                                // »ç¿îµå ³Ö¾îÁà 
        Instantiate(blinkPre, player.transform.position, Quaternion.identity);
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        rhythmGameManager.GoResultScene();
    }

    private IEnumerator EndEvent_5()
    {
        Vector3 targetCamRot = new Vector3(-30, cam.transform.localEulerAngles.y + 90f, cam.transform.localEulerAngles.z);
        Sequence sq = DOTween.Sequence();
        sq.Append(cam.transform.DORotate(targetCamRot, 1f));
        sq.Join(player.transform.DORotate(new Vector3(0, 90, 0), 3f));
        sq.Join(cam.transform.DOMoveY(cam.transform.position.y + 3f, 3f));
        sq.Append(cam.transform.DOMoveX(cam.transform.position.x + 3f, 3f));

        yield return new WaitForSeconds(7f);
        rhythmGameManager.GoResultScene();
    }

    private IEnumerator EndEvent_6()
    {
        yield return null;
        rhythmGameManager.GoResultScene();
    }

    private IEnumerator EndEvent_7()
    {
        yield return null;
        rhythmGameManager.GoResultScene();
    }

    private IEnumerator EndEvent_8()
    {
        GameObject witch = Instantiate(Witch, player.transform.position + new Vector3(0, 4.2f, 27.7f), player.transform.rotation);


        List<Vector3> posList = new List<Vector3>();
        List<Quaternion> quatList = new List<Quaternion>();

        posList.Add(new Vector3(player.transform.position.x, player.transform.position.y + 2f, player.transform.position.z));
        posList.Add(new Vector3(player.transform.position.x + 21, player.transform.position.y + 1f, player.transform.position.z + 12));
        posList.Add(new Vector3(player.transform.position.x + 5, player.transform.position.y + 4f, player.transform.position.z + 24));

        quatList.Add(Quaternion.Euler(cam.transform.localEulerAngles.x - 48, cam.transform.localEulerAngles.y + 180, cam.transform.localEulerAngles.z));
        quatList.Add(Quaternion.Euler(cam.transform.localEulerAngles.x - 70, cam.transform.localEulerAngles.y - 117, cam.transform.localEulerAngles.z));
        quatList.Add(Quaternion.Euler(cam.transform.localEulerAngles.x - 70, cam.transform.localEulerAngles.y - 57, cam.transform.localEulerAngles.z));



        cam.transform.DOMove(new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + 3), 2f);
        cam.transform.DOLocalRotate(new Vector3(cam.transform.localEulerAngles.x - 50, cam.transform.localEulerAngles.y - 180, cam.transform.localEulerAngles.z), 2f);

        yield return new WaitForSeconds(1.5f);

        Instantiate(fableLaserPre, player.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(2f);

        cam.transform.position = posList[1];
        cam.transform.rotation = quatList[1];

        cam.transform.DOLocalRotate(new Vector3(cam.transform.localEulerAngles.x, cam.transform.localEulerAngles.y + 60, cam.transform.localEulerAngles.z), 1.5f).SetEase(Ease.InOutExpo);
        yield return new WaitForSeconds(2.5f);

        cam.transform.position = posList[2];
        cam.transform.rotation = quatList[2];

        yield return new WaitForSeconds(1.7f);
        Instantiate(popEffect, witch.transform.position + Vector3.up * 2, Quaternion.identity);
        Destroy(witch);
        yield return new WaitForSeconds(1f);
        directionalLight2.DOColor(new Color(1, 1, 1, 1), 2f);
        yield return new WaitForSeconds(3f);
        rhythmGameManager.GoResultScene();
    }

    private IEnumerator EndEvent_9()
    {
        Vector3 targetPlayerPos = player.transform.position + player.transform.forward * 7;
        Vector3 downPos = player.transform.position + new Vector3(0, -10, 0);
        Sequence sq1 = DOTween.Sequence();
        sq1.Append(cam.transform.DOMove(targetPlayerPos, 3f));
        sq1.Join(cam.transform.DOMoveY(targetPlayerPos.y - 4, 3f).SetEase(Ease.Linear));
        sq1.Join(cam.transform.DOLocalRotate(Vector3.zero, 3f).SetEase(Ease.InExpo));
        sq1.Append(cam.transform.DOLocalRotate(new Vector3(-12, 0, 0), 3f));
        sq1.Join(directionalLight2.transform.DORotate(new Vector3(-90, 0, 0), 3f));
        yield return new WaitForSeconds(8f);
        rhythmGameManager.GoResultScene();
    }
}

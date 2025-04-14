using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ArrowShowing : MonoBehaviour
{
    [SerializeField] private RectTransform[] imagetrm;
    [SerializeField] private LeftTurnNote[] leftturn;
    [SerializeField] private RightTurnNote[] rightturn;
    private RhythmGameManager gameManager;
    private PlayerInput player;
    private bool isActive = false;

    private int leftint = 0;
    private int rightint = 0;

    float timing = 0;
    float timeSetting = 0;
    private void Awake()
    {
        gameManager = FindObjectOfType<RhythmGameManager>().GetComponent<RhythmGameManager>();
        player = FindObjectOfType<PlayerInput>().GetComponent<PlayerInput>();
        timeSetting = Information.Instance.currentDiff == DifficultType.Dream ? 120f / Information.Instance.currentSong.SongBPM : 60f / Information.Instance.currentSong.SongBPM;
    }

    public void GetTurnNote()
    {
        leftturn = FindObjectsOfType<LeftTurnNote>();
        rightturn = FindObjectsOfType<RightTurnNote>();
        leftint = leftturn.Length - 1;
        rightint = rightturn.Length - 1;
    }



    private void Update()
    {
        if (leftturn.Length == 0 || rightturn.Length == 0) return;
        if (player.noteQ.GetNote(2) == null)
            return;
        if ( player.noteQ.GetNote(2).noteIndex == leftturn[leftint].noteIndex)
        {
            if (leftint != 0)
                leftint--;
            for (int i = 0; i < 2; i++)
            {
                imagetrm[i].localScale = new Vector3(1, 1, 1);
                imagetrm[i].rotation = Quaternion.Euler(0, 0, 0);
                imagetrm[i].gameObject.SetActive(true);
                isActive = true;
            }
        }
        else if (player.noteQ.GetNote(2).noteIndex == rightturn[rightint].noteIndex)
        {
            if (rightint != 0)
                rightint--;
            for (int i = 0; i < 2; i++)
            {
                imagetrm[i].localScale = new Vector3(1, 1, 1);
                imagetrm[i].rotation = Quaternion.Euler(0, 180, 0);
                imagetrm[i].gameObject.SetActive(true);
                isActive = true;
            }
        }

        if (isActive)
        {
            timing += Time.deltaTime;
            if (timing >= timeSetting)
            {
                timing = 0;
                isActive = false;
                for (int i = 0; i < 2; i++)
                {
                    imagetrm[i].localScale = Vector3.zero;
                }
            }
        }
    }
}
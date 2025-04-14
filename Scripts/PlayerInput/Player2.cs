using UnityEngine;

public class Player2 : MonoBehaviour
{
    Information infomation;
    RhythmGameManager rhythmManager;
    CamManager camManager;
    JudgementText judgementText;


    [Header("SongBPM")]
    [SerializeField]
    int bpm;

    [Header("Player")]
    int moveSpeed;

    [SerializeField]
    LayerMask mask;

    Vector3 dir;

    float x;
    float z;

    float judge = 0;

    bool isStart = false;

    private void Awake()
    {
        camManager = transform.GetChild(0).GetComponent<CamManager>();
        rhythmManager = FindObjectOfType<RhythmGameManager>().GetComponent<RhythmGameManager>();
        infomation = FindObjectOfType<Information>().GetComponent<Information>();
        judgementText = FindObjectOfType<JudgementText>();
    }
    private void OnEnable()
    {
        rhythmManager.GameStartEvent += StartGame;
        rhythmManager.GameStopEvent += StopGame;
    }
    private void OnDisable()
    {
        rhythmManager.GameStartEvent -= StartGame;
        rhythmManager.GameStopEvent -= StopGame;
    }



    private void StartGame()
    {
        isStart = true;
    }

    private void StopGame()
    {
        isStart = false;
    }

    private void Start()
    {
        bpm = Information.Instance.currentSong.SongBPM;

        if (infomation.currentDiff == DifficultType.Dream)
            moveSpeed = bpm / 30;
        else if (infomation.currentDiff == DifficultType.Nightmare)
            moveSpeed = bpm / 15;

    }

    private void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        Vector3 mousePoint = Camera.main.ScreenToViewportPoint(mousePos);


        if (isStart)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        bool rayCastHiting = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 4f, mask);


        if (!rayCastHiting)
        {
            Die();
        }
        if (rayCastHiting)
        {
            if (rayCastHiting && hit.transform.CompareTag("EndPoint"))
            {
               // rhythmManager.GameClear(transform.position, hit.transform.position, moveSpeed);
            }
            else if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; ++i)
                {

                    if (Input.GetTouch(i).phase == TouchPhase.Began) //Input.GetTouch(0).phase == TouchPhase.Moved 
                    {
                        if (hit.transform.tag == "LeftStep")
                        {
                            if (mousePoint.x < 0.5)
                            {
                                TagDown(hit);
                                continue;
                            }
                        }
                        else if (hit.transform.tag == "RightStep")
                        {
                            if (mousePoint.x > 0.5)
                            {
                                TagDown(hit);
                                continue;
                            }
                        }
                    }

                    else if (Input.GetTouch(i).phase == TouchPhase.Moved)
                    {
                        if (hit.transform.tag == "LeftRotate")
                        {
                            if (mousePoint.x < 0.5)
                            {
                                TagDown(hit, transform.position, hit.transform.position, -90);
                                continue;
                            }
                        }
                        else if (hit.transform.tag == "RightRotate")
                        {
                            if (mousePoint.x > 0.5)
                            {
                                TagDown(hit, transform.position, hit.transform.position, 90);
                                continue;

                            }
                        }
                    }
                }
            }
        }
    }







    private void TagDown(RaycastHit hit, Vector3 trmpos, Vector3 hitPos, int i)
    {
        TagDown(hit);

        if (transform.rotation == Quaternion.Euler(0, 90, 0))
        {
            z = hitPos.z - trmpos.z;
            x = trmpos.x - hitPos.x;

            if (i > 0)
            {
                i = 180;
                transform.position = hit.transform.position - new Vector3(z, -transform.position.y, x);
            }
            else
            {
                i = 0;
                transform.position = hit.transform.position + new Vector3(z, transform.position.y, x);
            }
            transform.rotation = Quaternion.Euler(new Vector3(0, i, 0));
        }
        else if (transform.rotation == Quaternion.Euler(0, -90, 0))
        {

            z = hitPos.z - trmpos.z;
            x = trmpos.x - hitPos.x;

            if (i > 0)
            {
                i = 0;
                transform.position = hit.transform.position - new Vector3(z, -transform.position.y, x);
            }
            else
            {
                i = 180;
                transform.position = hit.transform.position + new Vector3(z, transform.position.y, x);
            }
            transform.rotation = Quaternion.Euler(new Vector3(0, i, 0));
        }
        else if (transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            z = hitPos.z - trmpos.z;
            x = hitPos.x - trmpos.x;

            if (i > 0)
                transform.position = hit.transform.position - new Vector3(z, -transform.position.y, x);
            else
                transform.position = hit.transform.position + new Vector3(z, transform.position.y, x);

            transform.rotation = Quaternion.Euler(new Vector3(0, i, 0));
        }
        else
        {
            z = trmpos.z - hitPos.z;
            x = hitPos.x - trmpos.x;

            if (i < 0)
            {
                transform.position = hit.transform.position - new Vector3(z, -transform.position.y, x);
            }
            else
                transform.position = hit.transform.position + new Vector3(z, transform.position.y, x);

            transform.rotation = Quaternion.Euler(new Vector3(0, -i, 0));
        }
    }
    private void AttackDown(RaycastHit hit)
    {
        TagDown(hit);

        //���ñ��� 

    }


    private void Die()
    {
        infomation.bed++;
        rhythmManager.DiePlayer();
    }

    private void TagDown(RaycastHit hit)
    {
        hit.transform.tag = "Untagged";

        judge = hit.transform.position.x - transform.position.x;
        if (Mathf.Abs(judge) <= 0.6f)
        {
            infomation.dream++;
        }
        else if (Mathf.Abs(judge) <= 0.8f)
        {
            infomation.cool++;
        }
        else if (Mathf.Abs(judge) <= 1f)
        {
            infomation.bed++;
        }
        else
        {
        }

    }
}


using System.Collections;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    [SerializeField] private AnimationCurve linear;
    [SerializeField] private AnimationCurve insine;
    [SerializeField] private AnimationCurve outsine;
    [SerializeField] private AnimationCurve inoutsine;

    [SerializeField]
    private float rotSpeed = 3f;

    public float turnRot = 0;

    private Transform playertrm;

    private bool isRotating = false;


    public bool isEnd = false;

    private void Awake()
    {
        playertrm = FindObjectOfType<PlayerInput>().transform.root;
    }

    private void Update()
    {
        if (!isEnd)
            transform.position = playertrm.position;
        if (isRotating == false && !isEnd)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, playertrm.rotation, Time.deltaTime * rotSpeed).normalized;
        }
    }

    public void TurningRot(float time, float rotating, CamCurveType curveType)
    {
        StartCoroutine(TurningCoroutine(time, rotating, curveType));
    }
    public void Return()
    {
        isRotating = false;
    }

    private IEnumerator TurningCoroutine(float lerpTIme, float rotating, CamCurveType curveType)
    {
        isRotating = true;
        Vector3 startRot = transform.eulerAngles;
        Vector3 endRot = new Vector3(startRot.x, startRot.y + rotating, startRot.z);
        float t = 0;
        AnimationCurve curve = null;
        switch (curveType)
        {
            case CamCurveType.Linear:
                curve = linear;
                break;
            case CamCurveType.InSine:
                curve = insine;
                break;
            case CamCurveType.OutSine:
                curve = outsine;
                break;
            case CamCurveType.InOutSine:
                curve = inoutsine;
                break;
        }

        while (t < lerpTIme + 0.02f)
        {
            t += Time.deltaTime;
            transform.eulerAngles = Vector3.Lerp(startRot, endRot, curve.Evaluate(t / lerpTIme));
            yield return null;
        }
        yield return null;
    }

    public void Shake()
    {
        //돌 , 마법 hit 흔들림 구현 ./
    }

}

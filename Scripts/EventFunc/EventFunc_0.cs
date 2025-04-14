using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EventFunc_0 : EventFuncs
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private Light directionalLight2;
    private Volume volume;

    private bool isBright = true;
    private int rotx = -90;
    private void Start()
    {
        if (Information.Instance.currentSong.SongID == 0)
        {
            volume = FindObjectOfType<Volume>();
            directionalLight.DOColor(new Color(1f, 0.99f, 0.8f), 0.1f);
        }
    }

    public override void Event_1(int noteIndex)
    {
        volume.profile.TryGet<Vignette>(out Vignette vig);
        if (isBright == true)
        {
            isBright = false;
            directionalLight.DOColor(new Color(0.14f, 0.16f, 0.6f), 3f);
        }
        else
        {
            isBright = true;
            directionalLight.DOColor(new Color(0.9f, 0.9f, 0.9f), 3f);
        }
        vig.active = !isBright;

        directionalLight2.transform.DORotate(new Vector3( transform.rotation.x + rotx, 0, 0), 3f);
        rotx *= -1;
    }

    public override void Event_2(int noteIndex)
    {


    }

    public override void Event_3(int noteIndex)
    {
    }
}

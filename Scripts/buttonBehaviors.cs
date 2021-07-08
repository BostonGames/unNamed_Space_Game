using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonBehaviors : MonoBehaviour
{
    private AudioSource buttonAudio;
    [SerializeField] AudioClip deniedSound;
    [SerializeField] TextMeshProUGUI pointsText;
    private int pointsRequired;

    void Start()
    {
        buttonAudio = GetComponent<AudioSource>();
        pointsRequired = int.Parse(pointsText.text);

    }

    // Start is called before the first frame update
    public void DenialSoundActive()
    {
        if(GameManager.instance.points < pointsRequired)
        {
            buttonAudio.PlayOneShot(deniedSound);
        }
    }
}

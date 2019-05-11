using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public AudioClip[] soundList;
    public Text text1;
    public Text text2;
    public RawImage darkness;
    public GameObject logo;
    public GameObject otherText;
    private AudioSource audioSource;
    private float timer;
    private bool isFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(soundList[0]);
        otherText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Rooftops");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

            if (isFinished == false)
        {
            if (timer < 1.5f)   // Fade in (if smaller than)
            {
                var tempColor = text1.color;
                tempColor.a = (tempColor.a + (Time.deltaTime / 1.5f));
                text1.color = tempColor;
            }
            if (timer > 3.5f && timer < 5f)   // Fade out (if larger then if smaller than)
            {
                var tempColor = text1.color;
                tempColor.a = (tempColor.a - (Time.deltaTime / 1.5f));
                text1.color = tempColor;
            }
            if (timer > 5f && timer < 6.5f)   // Fade in (if larger then if smaller than)
            {
                var tempColor = text2.color;
                tempColor.a = (tempColor.a + (Time.deltaTime / 1.5f));
                text2.color = tempColor;
            }
            if (timer > 8.5f && timer < 10f)   // Fade out (if larger then if smaller than)
            {
                var tempColor = text2.color;
                tempColor.a = (tempColor.a - (Time.deltaTime / 1.5f));
                text2.color = tempColor;
            }
            if (timer > 10f)
            {
                var tempColor = darkness.color;
                tempColor.a = (tempColor.a - (Time.deltaTime / 2f));
                darkness.color = tempColor;

                if (logo.transform.rotation.x <= 0.0f)
                {
                    logo.transform.Rotate(0.5f, transform.rotation.y, transform.rotation.z, Space.Self);
                }
                else
                {
                    audioSource.PlayOneShot(soundList[1]);
                    otherText.SetActive(true);
                    isFinished = true;
                }
            }
        }
    }
}

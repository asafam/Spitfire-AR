using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;


public class Score : MonoBehaviour
{
    public Camera mainCamera;
    public TMPro.TextMeshProUGUI text;
    public string elapsedTimeText { get; private set; }
    private float timer;

    // Update is called once per frame
    void Update()
    {
        // keep the scores canvas aligned with the camera
        transform.position = mainCamera.transform.position;

        // present elapsed time
        timer += Time.deltaTime;
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        elapsedTimeText = string.Format("{0}:{1}", minutes, seconds);
        text.text = elapsedTimeText;
    }

    public void ResetTimer()
    {
        timer = 0;
    }
}

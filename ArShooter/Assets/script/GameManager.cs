using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int score = 0;
    private int g_score = 0;
    int frame = 0;
    public Text score_text;
    public GameObject Ennemi;

    void Start()
    {
        score_text.text = "score = " + score + " / 50";
    }

    void Update()
    {
        if (score >= 50)
        {
            score_text.text = "You WIN !!!";
            StartCoroutine(WaitReset(5.0f));
        }
    }
    private IEnumerator WaitReset(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Shooter", LoadSceneMode.Single);
    }

    public void ScorePlus()
    {
        score += 1;
        score_text.text = "score = " + score + " / 50";
        SpawnEnnemi();
    }

    void SpawnEnnemi()
    {
        Instantiate(Ennemi, RandomPos(), Quaternion.identity);
    }

    Vector3 RandomPos()
    {
        Vector3 RdmTransform;
        float x, y, z;

        x = Random.Range(-10, 10);
        y = Random.Range(-10, 10);
        z = Random.Range(2, 10);
        RdmTransform = new Vector3(x, y, z);

        return RdmTransform;
    }
}
    // Scene HackHub
    /*void Update()
    {
        if (isTrackingMarker("guilhem_card") && g_score == 0)
        {
            score++;
            g_score = 1;
        }
        score_text.text = "score = " + score + " / 50";
    }

    private bool isTrackingMarker(string imageTargetName)
    {
        var imageTarget = GameObject.Find(imageTargetName);
        var trackable = imageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status == TrackableBehaviour.Status.TRACKED;
    }
}*/

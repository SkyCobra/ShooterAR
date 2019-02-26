﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AddScore : MonoBehaviour, ITrackableEventHandler
{
    public GameManager gameManager;
    private TrackableBehaviour mTrackableBehaviour;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            gameManager.score++;
            Debug.Log("Triggered " + this.name);
            Destroy(this);
            
        }
    }
}
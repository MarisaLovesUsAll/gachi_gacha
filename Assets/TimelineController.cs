using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public LockerController lockerController;
    public PlayableDirector playableDirector;
    public OperatorLibrary operatorLibrary;
    public OperatorViewController operatorView;
    public AudioController audioController;

    public enum States
    {
        Bringing,
        Touching,
        Opening,
        AfterOpening
    }

    States state = States.Bringing;

    // Start is called before the first frame update
    void Start()
    {

    }

    TouchHelper touchHelper = new TouchHelper();


    public BGController bgController;

    // public void BringingStarted()
    // {
    // }

    // public void OpeningStarted()
    // {
    // }


    public void SetBringing()
    {
        SetState(States.Bringing);
    }
    public void SetTouching()
    {
        SetState(States.Touching);
    }
    public void SetAfterOpening()
    {
        SetState(States.AfterOpening);
    }

    public void SetState(States state)
    {
        this.state = state;

        switch (state)
        {
            default:
            case States.Bringing:
                // Reset everything
                touchHelper = new TouchHelper();

                var op = operatorLibrary.GetRandomOperator();
                lockerController.currentRarity = op.rarity;
                operatorView.SetInfo(op);
                audioController.SetInfo(op);

                break;
            case States.Touching:
                playableDirector.Pause();
                break;
            case States.Opening:
                playableDirector.Resume();
                break;
            case States.AfterOpening:
                playableDirector.Pause();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            default:
            case States.Bringing:
                lockerController.mod = 0;
                break;
            case States.Touching:
                (bool isOpened, float mod) = touchHelper.GetNextMod();
                lockerController.mod = mod;
                if (isOpened)
                {
                    SetState(States.Opening);
                }
                break;
            case States.Opening:
                break;
            case States.AfterOpening:
                if (Input.GetMouseButtonDown(0))
                {
                    playableDirector.Stop();
                    playableDirector.RebuildGraph();
                    playableDirector.Play();
                    SetState(States.Bringing);
                }
                break;

        }

    }
}

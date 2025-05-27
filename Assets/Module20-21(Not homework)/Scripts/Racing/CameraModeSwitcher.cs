using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModeSwitcher : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _cameras;

    private Queue<CinemachineVirtualCamera> _camerasQueue;

    private void Awake()
    {
        _camerasQueue = new Queue<CinemachineVirtualCamera>(_cameras);

        SwitchNextMode();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            SwitchNextMode();
    }

    private void SwitchNextMode()
    {
        CinemachineVirtualCamera nextMode = _camerasQueue.Dequeue();

        foreach (var item in _cameras)
        {
            item.gameObject.SetActive(false);
        }

        nextMode.gameObject.SetActive(true);

        _camerasQueue.Enqueue(nextMode);
    }
}

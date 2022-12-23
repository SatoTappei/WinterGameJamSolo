using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UniRx;
using MessagePipe;
using VContainer;
using VContainer.Unity;

public class SampleController : MonoBehaviour
{
    [Inject] IPublisher<StickData> _publisher;

    void Start()
    {
        
    }

    void Update()
    {
        _publisher.Publish(new StickData(transform));
    }
}

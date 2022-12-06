using UnityEngine;
using Zenject;

public class UpdateSender : MonoBehaviour
{
    private IUpdatable _updatable;

    [Inject]
    private void Construct(IUpdatable updatable)
    {
        _updatable = updatable;
    }

    private void Update()
    {
        _updatable.Tick();
    }
}
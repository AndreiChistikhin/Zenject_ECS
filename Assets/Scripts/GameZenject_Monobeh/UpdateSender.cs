using UnityEngine;
using Zenject;

public class UpdateSender : MonoBehaviour
{
    private IUpdatable _updatable;

    [Inject]
    private void Construct(IUpdatable updatables)
    {
        _updatable = updatables;
    }

    private void Update()
    {
        _updatable.Tick();
    }
}
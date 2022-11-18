using UnityEngine;
using Zenject;

public class PlayerTest : MonoBehaviour
{
    private Input _input;

    [Inject(Id = "HI")]
    private void Construct(Input input)
    {
        _input = input;
        _input.MouseClicked += DoSmth;
    }
    
    private void OnDestroy()
    {
        _input.MouseClicked -= DoSmth;
    }

    private void DoSmth(Vector3 input)
    {
        Debug.Log("PlayerTest");
    }
}
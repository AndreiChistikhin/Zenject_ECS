using System;
using System.IO;
using Zenject;
using UnityEngine;

//Benefits:
//DI can be used to easily swap different implementations of a given interface
//Refactorability, testability when code is loosely coupled
public class ZenjectExamples : MonoInstaller
{
    [SerializeField] private Name _name;
    public override void InstallBindings()
    {
        bool test = true;
        /*Container.Bind<ContractType>()
             .WithId(Identifier)
             .To<ResultType>()
             .FromConstructionMethod()
             .AsScope()
             .WithArguments(Arguments)
             .OnInstantiated(InstantiatedCallback)
             .When(Condition)
             .(Copy|Move)Into(All|Direct)SubContainers()
             .NonLazy()
             .IfNotBound();*/
        Container.Bind<Name>().WithId(1)
            .FromMethod(ReturnGreetings)
            .AsSingle()
            .WithArguments("Andrei")
            .OnInstantiated<Name>(OnNameInstantiated)
            .When(x=>test)
            .NonLazy()
            .IfNotBound();
        Container.Bind<ITickable>().To<Ship>().AsSingle();
        Container.BindInterfacesAndSelfTo<Ship>().AsSingle();
        Container.Bind<Name>().FromComponentInNewPrefab(_name).WithGameObjectName("Privet");
        Container.InstantiatePrefabForComponent<Name>(_name);
    }

    private Name ReturnGreetings()
    {
        Name name=null;
        return name;
    }

    private void OnNameInstantiated(InjectContext context, Name name)
    {
        name.enabled = true;
    }
}

public class Name : MonoBehaviour
{
    private string _name;

    [Inject]
    public void SetName(string name)
    {
        _name = name;
    }
}

public class Ship : ITickable
{
    public void Tick()
    {
        // Perform per frame tasks
    }
}

public class Logger : IInitializable, IDisposable
{
    FileStream _outStream;

    public void Initialize()
    {
        _outStream = File.Open("log.txt", FileMode.Open);
    }

    public void Log(byte msg)
    {
        //_outStream.Write(msg);
    }

    public void Dispose()
    {
        _outStream.Close();
    }
}
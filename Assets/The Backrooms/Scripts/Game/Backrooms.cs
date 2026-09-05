using ModWobblyLife.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Backrooms : ModNetworkBehaviour
{
    public static Backrooms Instance { get; private set; }
    public AIController[] controllers;

    public NoisePrefab noisePrefab;
    public static InterfaceBackroomsGamemode gamemode {get; private set; }
    // RPCs
    private byte _loadSceneClientRpc;
    private byte _noiseClientRpc;
    private void Awake()
    {
        Instance = this;
    }

    protected override void ModRegisterRPCs(ModNetworkObject modNetworkObject)
    {
        base.ModRegisterRPCs(modNetworkObject);
        _loadSceneClientRpc = modNetworkObject.RegisterRPC(ClientLoadScene);
        _noiseClientRpc = modNetworkObject.RegisterRPC(GenerateNoiseClient);
    }
    public static void ServerChangeScene(string sceneName)
    {
        Instance.ServerLoadScene(sceneName);
    }
    private void ServerLoadScene(string sceneName)
    {
        modNetworkObject.SendRPC(_loadSceneClientRpc, ModRPCRecievers.OthersBuffered, sceneName);
        ModScenes.Load(sceneName);
    }
    private void ClientLoadScene(ModNetworkReader reader, ModRPCInfo info)
    {
        Instance.ModScenes.Load(reader.ReadString());
    }

    private void Update()
    {
       foreach(var controller in controllers)
        {
            controller.OnUpdate();
        }
    }
    private void FixedUpdate()
    {
        foreach (var controller in controllers)
        {
            controller.OnFixedUpdate();
        }
    }
    private void LateUpdate()
    {
        foreach (var controller in controllers)
        {
            controller.OnLateUpdate();
        }
    }
    private void GenerateNoiseClient(ModNetworkReader reader, ModRPCInfo info)
    {
        Instantiate(noisePrefab).ModStart(reader.ReadVector3(), reader.ReadSingle());
    }
    public static void GenerateNoise(Vector3 position, float radius = 2f, bool sendFeedback = false)
    {
        radius = radius * 2;
        if(sendFeedback) Instance.GenerateNoiseServer(position, radius);
        foreach (var controller in Instance.controllers)
        {
            if (controller.TryGetEars(out var ears))
            {
                ears.CheckNoise(position, radius);
            }
        }
    }

    private void GenerateNoiseServer(Vector3 position, float radius)
    {
        modNetworkObject.SendRPC(_noiseClientRpc, ModRPCRecievers.All, position, radius);
    }

    public static void StartGame(EnumBackroomsGamemode gamemode)
    {
        switch (gamemode)
        {
            case EnumBackroomsGamemode.CLASSIC:
                Backrooms.gamemode = new ClassicGamemode();
                break;
            case EnumBackroomsGamemode.TESTING:
                Backrooms.gamemode = new TestGamemode();
                break;
            case EnumBackroomsGamemode.DEMO:
                Backrooms.gamemode = new DemoScenesGamemode();
                break;
        }
        Backrooms.gamemode.OnStart();
    }
    public const string ROOT_SCENE = "Assets/The Backrooms/Scenes/Backrooms.unity";
    public static void Exit()
    {
        gamemode.OnExit();
        Instance.ModScenes.Load(ROOT_SCENE);
    }
}

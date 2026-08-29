using ModWobblyLife.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Backrooms : ModNetworkBehaviour
{
    private static Backrooms _instance;
    public AIController[] controllers;

    public NoisePrefab noisePrefab;

    // RPCs
    private byte _noiseClientRpc;
    private void Awake()
    {
        _instance = this;
    }

    protected override void ModRegisterRPCs(ModNetworkObject modNetworkObject)
    {
        base.ModRegisterRPCs(modNetworkObject);
        _noiseClientRpc = modNetworkObject.RegisterRPC(GenerateNoiseClient);
    }

    private void GenerateNoiseClient(ModNetworkReader reader, ModRPCInfo info)
    {
        Instantiate(noisePrefab).ModStart(reader.ReadVector3(), reader.ReadSingle());
    }
    public static void GenerateNoise(Vector3 position, float radius = 2f, bool sendFeedback = false)
    {
        radius = radius * 2;
        if(sendFeedback) _instance.GenerateNoiseServer(position, radius);
        foreach (var controller in _instance.controllers)
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
}

using Cysharp.Threading.Tasks;
using Grpc.Net.Client;
using MagicOnion;
using MagicOnion.Client;
using realtime_game.Shared.Interfaces.Services;
using System;
using UnityEngine;

public class CalculateModel : MonoBehaviour
{
    const string ServerURL = "http:localhost:5244";
    async void Start()
    {
        int result = await Mul(100, 323);
        Debug.Log(result);
    }

    public async UniTask<int> Mul(int x,int y)
    {
        var channel = GrpcChannel.ForAddress(ServerURL);
        var client = MagicOnionClient.Create<ICalculateService>(channel);
        var result = await client.MulAsync(x, y);
        return result;
    }

    public async UnaryResult<int> SumAllAsync(int[] numList)
    {
        throw new NotImplementedException();
    }
}

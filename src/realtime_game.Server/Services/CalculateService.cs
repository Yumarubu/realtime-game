using MagicOnion;
using MagicOnion.Server;
using realtime_game.Shared.Interfaces.Services;

namespace realtime_game.Shared.Interfaces.Services
{
    public class CalculateService:ServiceBase<ICalculateService>, ICalculateService
    {
        // 『乗算API』二つの整数を引数で受け取り乗算値を返す
        public async UnaryResult<int> MulAsync(int x, int y)
        {
            Console.WriteLine("Received:" + x + "," + y);
            return x * y;
        }

        //受け取った配列の値の合計を返す
        public async UnaryResult<int> SumAllAsync(int[] numList)
        {
            throw new NotImplementedException();
        }

        UnaryResult<int[]> ICalculateService.CalcForOperationAsyc(int x, int y)
        {
            throw new NotImplementedException();
        }

        UnaryResult<float> ICalculateService.SumAllNumberAsync(Number numData)
        {
            throw new NotImplementedException();
        }
    }
}

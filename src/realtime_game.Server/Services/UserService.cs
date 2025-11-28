using MagicOnion;
using MagicOnion.Server;
using realtime_game.Shared.Interfaces.Services;
using System.Linq.Expressions;

namespace realtime_game.Server.Services
{
    public class UserService : ServiceBase<IUserService>, IUserService
    {
        public async UnaryResult<int> RegistUserAsync(string name)
        {
            //テーブルにレコードを追加
        }
    }
}

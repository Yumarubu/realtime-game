using MagicOnion;
using MagicOnion.Server;
using realtime_game.Server.Models.Contexts;
using realtime_game.Shared.Interfaces.Services;
using realtime_game.Shared.Models.Entities;
using System.Linq.Expressions;

namespace realtime_game.Server.Services
{
    public class UserService : ServiceBase<IUserService>, IUserService
    {
        public async UnaryResult<int> RegistUserAsync(string name)
        {
            using var context = new GameDbContext();

            //バリデーションチェック（名前登録済みかどうか）
            if(context.Users.Count() > 0 && context.Users.Where(user => user.Name == name).Count() > 0)
            {
                throw new ReturnStatusException(Grpc.Core.StatusCode.InvalidArgument, "");
            }

            //テーブルにレコードを追加
            User user = new User();
            user.Name = name;
            user.Token = "";
            user.Created_at = DateTime.Now;
            user.Updated_at = DateTime.Now;
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user.Id;
        }
    }
}

using MagicOnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realtime_game.Shared.Interfaces.StreamingHubs
{
    /// <summary>
    /// サーバーからクライアントへの通知閉鎖
    /// </summary>

    public interface IRoomHubReceiver
    {
            //[クライアントに実装]
            //[サーバーから呼び出す]

            //ユーザーの入室通知
            void OnJoin(JoinedUser user);
    }
}

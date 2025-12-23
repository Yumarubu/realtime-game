using realtime_game.Shared.Interfaces.StreamingHubs;
using realtime_game.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject characterPrefab;
    Dictionary<Guid, GameObject> characterList = new Dictionary<Guid, GameObject>();
    RoomModel roomModel;
    UserModel userModel;
    
    int userId = 1; //自分のユーザーID
    User myself;    //自分のユーザー情報を保持

    async void Start()
    {
        roomModel = GetComponent<RoomModel>();
        userModel = GetComponent<UserModel>();

        //ユーザーが入室した時にOnJoinedUserメソッドを実行するよう、モデルに登録しておく
        roomModel.OnJoinedUser += this.OnJoinedUser;
        //接続
        await roomModel.ConnectAsync();
        try
        {
            // ユーザー情報を取得
            //myself = await userModel.GetUser(userId);
        }
        catch (Exception e)
        {
            Debug.Log("RegistUser failed");
            Debug.LogException(e);
        }
    }

    public async void JoinRoom()
    {
        //入室
        await roomModel.JoinAsync("sampleRoom", userId);
    }

    //ユーザーが入室した時の処理
    private void OnJoinedUser(JoinedUser user)
    {
        // すでに表示済みのユーザーは追加しない
        if (characterList.ContainsKey(user.ConnectionId))
        {
            return;
        }

        // 自分は追加しない
        if (user.UserData.Id == userId)
        {
            return;
        }

        GameObject characterObject = Instantiate(characterPrefab);  //インスタンス生成
        characterObject.transform.position = new Vector3(0, 0, 0);
        characterList[user.ConnectionId] = characterObject;  //フィールドで保持
    }

    //ユーザーが退室した時の処理
    private void OnLeftUser(Guid connectionId)
    {
        // いない人は退室できない
        if(!characterList.ContainsKey(connectionId))
        {
            return;
        }

        Destroy(characterList[connectionId]);   // 対象のオブジェクトを削除
        characterList.Remove(connectionId);
    }

    public async void LeaveRoom()
    {
        //ルーム名チェック
        Text text =
            GameObject.Find("InputRoomNameText").gameObject.GetComponent<Text>();
        string roomName = text.text;
        if(roomName == "")
        {
            // ルーム名が入力されていない場合は何もしない
            return;
        }

        // 退室
        await roomModel.LeaveAsync();
    }

    // 自分が退室した時の処理
    private void OnLeftUserAll()
    {
        //自分以外のオブジェクトを削除する
        List<Guid> connectionIdList = characterList.Keys.ToList();
        foreach (Guid connectionId in connectionIdList)
        {
            //一人分の退室処理
            OnLeftUser(connectionId);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomList : MonoBehaviourPunCallbacks
{
    private RoomListEntry roomListEntryPrefab = default; // RoomListEntryのPrefabの参照

    private ScrollRect scrollRect;
    private Dictionary<string, RoomListEntry> activeEntries = new Dictionary<string, RoomListEntry>();
    private Stack<RoomListEntry> inactiveEntries = new Stack<RoomListEntry>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (var info in roomList)
        {
            RoomListEntry entry;
            if (activeEntries.TryGetValue(info.Name, out entry))
            {
                if (!info.RemovedFromList)
                {
                    // リスト要素を更新する
                    entry.Activate(info);
                }
                else
                {
                    // リスト要素を削除する
                    activeEntries.Remove(info.Name);
                    entry.Deactivate();
                    inactiveEntries.Push(entry);
                }
            }
            else if (!info.RemovedFromList)
            {
                // リスト要素を追加する
                entry = (inactiveEntries.Count > 0)
                    ? inactiveEntries.Pop().SetAsLastSibling()
                    : Instantiate(roomListEntryPrefab, scrollRect.content);
                entry.Activate(info);
                activeEntries.Add(info.Name, entry);
            }
        }
    }
}

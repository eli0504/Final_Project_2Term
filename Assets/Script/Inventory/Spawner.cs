using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private void Start()
    {
        ItemWorld.SpawnItemWorld(new Vector3(2, 0, 0),
                                 new Items
                                 {
                                     itemType = Items.ItemType.Sword,
                                     amount = 1
                                 });
        ItemWorld.SpawnItemWorld(new Vector3(-2, 0, 0),
                                 new Items
                                 {
                                     itemType = Items.ItemType.HealthPotion,
                                     amount = 1
                                 });
        ItemWorld.SpawnItemWorld(new Vector3(-2, 2, 0),
                                 new Items
                                 {
                                     itemType = Items.ItemType.Apple,
                                     amount = 1
                                 });
        ItemWorld.SpawnItemWorld(new Vector3(0, -3, 0),
                                 new Items
                                 {
                                     itemType = Items.ItemType.Coin,
                                     amount = 1
                                 });
        ItemWorld.SpawnItemWorld(new Vector3(-2, -3, 0),
                                 new Items
                                 {
                                     itemType = Items.ItemType.Coin,
                                     amount = 10
                                 });
    }
}

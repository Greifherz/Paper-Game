using System.Collections.Generic;
using CombatScene;
using CombatScene.Interfaces;
using Inventory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Player
{
    public class PlayerInfo
    {
        public static PlayerInfo CreateFromPersistence()
        {
            var RetPlayerInfo = new PlayerInfo();
            RetPlayerInfo.RetrieveFromPersistence();
            return RetPlayerInfo;
        }
        
        public IPlayerCharacter PlayerCharacter;

        public List<int> OptionTrail;

        public bool RetrieveFromPersistence()
        {
            //if (PlayerCharacter != null) return false;

            var Ret = false;

            var PlayerJson = PlayerPrefs.GetString("PlayerCharacter", "");
            var OptionTrailJson = PlayerPrefs.GetString("OptionTrail", "");
        
            if(PlayerJson != "" && OptionTrailJson != "")
            {
                var PlayerJsonObject = JObject.Parse(PlayerJson);
                PlayerCharacter = new PlayerCharacter
                {
                    Name = (PlayerJsonObject["Name"] ?? "ForgottenOne").Value<string>(),
                    MaxHitPoints = (PlayerJsonObject["MaxHitPoints"] ?? 10).Value<int>(),
                    CurrentHitPoints = (PlayerJsonObject["CurrentHitPoints"] ?? 10).Value<int>(),
                    MaxManaPoints = (PlayerJsonObject["MaxManaPoints"] ?? 5).Value<int>(),
                    CurrentManaPoints = (PlayerJsonObject["CurrentManaPoints"] ?? 5).Value<int>(),
                    Attack = (PlayerJsonObject["Attack"] ?? 1).Value<int>(),
                    Defense = (PlayerJsonObject["Defense"] ?? 0).Value<int>(),
                    Experience = (PlayerJsonObject["Experience"] ?? 0).Value<int>(),
                    Level = (PlayerJsonObject["Level"] ?? 1).Value<int>()
                };

                var EquippedItemsJson = PlayerPrefs.GetString(PlayerCharacter.Name + ".EquippedItems", "");
                if (EquippedItemsJson != "")
                {
                    var PersistedEquippedItems = JsonConvert.DeserializeObject<Dictionary<EquipmentSlot,string>>(EquippedItemsJson);
                    foreach (var Kvp in PersistedEquippedItems)
                    {
                        PlayerCharacter.EquippedItems.Add(Kvp.Key,Resources.Load<EquipmentItem>("Items/Equipment/" + Kvp.Value));
                    }
                }
                
                OptionTrail = JsonConvert.DeserializeObject<List<int>>(OptionTrailJson);
                Ret = true;
            }
            else
            {
                PlayerCharacter = new PlayerCharacter("ForgottenOne");
                OptionTrail = new List<int>();
            }

            return Ret;
        }

        public void PersistIntoPersistence()
        {
            var PlayerJson = JsonConvert.SerializeObject(PlayerCharacter);
            var OptionTrailJson = JsonConvert.SerializeObject(OptionTrail);
            
            // PlayerCharacter.EquippedItems.Add(EquipmentSlot.MainHand,Resources.Load<EquipmentItem>("Items/Equipment/Sword"));

            var PersistableEquippedItems = new Dictionary<EquipmentSlot, string>();
            
            foreach (var Kvp in PlayerCharacter.EquippedItems)
            {
                PersistableEquippedItems.Add(Kvp.Key,Kvp.Value.name);
            }

            var EquippedItemsJson = JsonConvert.SerializeObject(PersistableEquippedItems);

            PlayerPrefs.SetString("PlayerCharacter", PlayerJson);
            PlayerPrefs.SetString("OptionTrail", OptionTrailJson);
            PlayerPrefs.SetString(PlayerCharacter.Name + ".EquippedItems",EquippedItemsJson);
        }

        public void ClearPersistence()
        {
            PlayerPrefs.DeleteAll();
        }

    
    }
}

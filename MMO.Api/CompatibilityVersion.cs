using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MMO.Interfaces;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace MMO.API
{
    /// <summary>
    /// This class defines the routes used by the original MMOKIT version in php
    /// As to say is a retro-compatibilty version.
    /// </summary>
    [Route("php")]
    public class CompatibiltyVersionController : Controller
    {

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            DictionaryKeyPolicy = new LowerCaseNamingPolicy(),
            PropertyNamingPolicy = new LowerCaseNamingPolicy()
        };


        [Route("mmocheckclient.php")]
        [HttpGet]
        public string CheckClient(int userId = -1, string sessionKey = "", int charId = -1)
        {
            MMO.Services.Compatibility.CheckClient(userId, sessionKey, charId);

            return JsonLazyReturn.Status();

        }



        [Route("mmocreatecharacter.php")]
        [HttpGet]
        public string CreateCharacter(int userId, string sessionKey, string name, int classId)
        {
            MMO.Services.Compatibility.CheckClient(userId, sessionKey, null);

            MMO.Services.Compatibility.CreateCharacter(userId, name, classId);

            return JsonLazyReturn.Status();

        }

        [Route("mmodeletecharacter.php")]
        [HttpGet]
        public string DeleteCharacter(int userId = -1, string sessionKey = "", int charId = -1)
        {
            MMO.Services.Compatibility.CheckClient(userId, sessionKey, charId);

            MMO.Services.Compatibility.DeleteCharacter(charId);

            return JsonLazyReturn.Status();

        }




        [Route("mmogetcharacter.php")]
        [HttpGet]
        public string GetCharacter(int charId = -1, int userId = -1)
        {
            //MMO.Services.Compatibility.CheckClient(userId, sessionKey, charId);
            var character = MMO.Services.Compatibility.GetCharacter(charId);
            var jsonresult = JsonSerializer.Serialize<Character>(character);

            return jsonresult;

        }


        [Route("mmogetcharacters.php")]
        [HttpGet]
        public string GetCharacters(int userId = -1, string sessionKey = "")
        {
            MMO.Services.Compatibility.CheckClient(userId, sessionKey, null);
            var character = MMO.Services.Compatibility.GetCharacters(userId);


            var jsonresult = JsonSerializer.Serialize<List<CharacterSimple>>(character);

            return jsonresult;

        }



        [Route("mmogetserver.php")]
        [HttpGet]
        public string GetServer()
        {


           
            var dict = new Dictionary<string, string>();

            dict.Add("status", "OK");
            dict.Add("address", "127.0.0.1");

            var jsonresult = JsonSerializer.Serialize(dict, options);

            return jsonresult;

        }

        [Route("mmologin.php")]
        [HttpGet]
        public string Login(string login, string password)
        {

            var new_session = MMO.Services.Compatibility.Login(login, password);

            var dict = new Dictionary<string, string>();
            dict.Add("status", "OK");
            dict.Add("sessionkey", new_session.SessionKey);
            dict.Add("userid", new_session.User.Id.ToString());

            var jsonresult = JsonSerializer.Serialize(dict, options);

            return jsonresult;

        }

        [Route("mmoregistration.php")]
        [HttpGet]
        public string Registration(string accountname, string accountpassword, string accountemail)
        {

            if (MMO.Services.Compatibility.Register(accountname, accountpassword, accountemail))
            {

                return JsonLazyReturn.Status();

            }
            else
            {
                return JsonLazyReturn.Status("This account already exists or name is taken.");
            }

        }

        [Route("mmosavecharacter.php")]
        [HttpGet]

        //public string SaveCharacter(string charid, string inventory, string quests, string health, string mana, string experience, string level,
        //    string posx, string posy, string posz, string yaw,
        //    string equip_head, string equip_chest, string equip_hands, string equip_legs, string equip_feet,
        //    string hotbar0, string hotbar1, string hotbar2, string hotbar3)
        public string SaveCharacter(Character character)
        {

            if (MMO.Services.Compatibility.SaveCharacter(character))
            {

                return JsonLazyReturn.Status();

            }
            else
            {
                return JsonLazyReturn.Status("Fail to replicate data.");
            }
        }



        [Route("myphpversion.php")]
        [HttpGet]
        public string PHPversion()
        {

            return "yo! this is made in .net :P";

        }




        [Route("mmo_clan_add_character.php")]
        [HttpGet]
        public string ClanAddCharacter(string character_name, int clan_id)
        {

            if (MMO.Services.Compatibility.ClanAdd(character_name, clan_id))
            {

                return JsonLazyReturn.Status();

            }
            else
            {
                return JsonLazyReturn.Status("User already in another clan");
            }

        }

        [Route("mmo_clan_create.php")]
        [HttpGet]
        public string ClanCreate(string clan_name, string character_name)
        {

            if (MMO.Services.Compatibility.ClanCreate(character_name, clan_name))
            {

                return JsonLazyReturn.Status();

            }
            else
            {
                return JsonLazyReturn.Status("User already in another clan");
            }

        }


        [Route("mmo_clan_disband.php")]
        [HttpGet]
        public string ClanDisband(int character_id)
        {


            if (MMO.Services.Compatibility.ClanDisband(character_id))
            {

                return JsonLazyReturn.Status();

            }
            else
            {
                return JsonLazyReturn.Status("Unable to disband clan.");
            }

        }


        [Route("mmo_clan_list.php")]
        [HttpGet]
        public string ClanList()
        {
            var clanlist = MMO.Services.Compatibility.GetClans();
            var jsonresult = JsonSerializer.Serialize<List<Clan>>(clanlist);

            return jsonresult;

        }


        [Route("mmo_clan_remove_character.php")]
        [HttpGet]
        public string ClanRemoveCharacter(int character_id)
        {

            if (MMO.Services.Compatibility.ClanRemove(character_id))
            {

                return JsonLazyReturn.Status();

            }
            else
            {
                return JsonLazyReturn.Status("Fail to leave clan.");
            }

        }
    }


    public static class JsonLazyReturn
    {

        public static string Status(string statusMessage = "OK")
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                DictionaryKeyPolicy = new LowerCaseNamingPolicy(),
                PropertyNamingPolicy = new LowerCaseNamingPolicy()
            };

            var dict = new Dictionary<string, string>();
            dict.Add("status", statusMessage);

            var jsonresult = JsonSerializer.Serialize(dict, options);

            return jsonresult;
        }

    }
}

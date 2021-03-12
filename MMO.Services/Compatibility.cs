using System;
using System.Collections.Generic;
using System.Text;
using MMO.Data;
using MMO.Interfaces;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MMO.Services
{
    public static class Compatibility
    {


        public static void CheckClient(int userId, string sessionKey, int? charId)
        {
            try
            {
                string dbSessionKey = "";

                using (var db = new DatabaseContext())
                {


                    if (charId == null)
                    {
                        dbSessionKey = db.ActiveLogin.Where(x => x.User.Id == userId).FirstOrDefault().SessionKey;
                    }
                    else
                    {
                        dbSessionKey = db.ActiveLogin.Where(x => x.User.Id == userId && x.Character.Id == charId).FirstOrDefault().SessionKey;
                    }
                }

                if (string.IsNullOrEmpty(sessionKey) || (sessionKey != dbSessionKey))
                {
                    throw new Exception("Unauthorized");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CreateCharacter(int userId, string name, int classId)
        {
            try
            {

                var newchar = new Interfaces.Character();
                newchar.Name = name;
                newchar.Health = 300;
                newchar.Mana = 150;
                newchar.Level = 1;
                newchar.PosX = 6890;
                newchar.PosY = -3370;
                newchar.PosZ = 20692;
                newchar.RotationYaw = 0;
                newchar.Gender = 0;
                newchar.Experience = 0;
                newchar.Class = classId;
                newchar.Hotbar0 = "/Game/MMO/Abilities/DA_Heal.DA_Heal";
                newchar.Hotbar1 = "/Game/MMO/Abilities/DA_FireBlast.DA_FireBlast";



                using (var db = new DatabaseContext())
                {
                    if (db.Character.Where(x => x.Name == name).Any())
                    {
                        throw new Exception("This name is unavailable");
                    }

                    var user = db.User.Find(userId);

                    user.Characters.Add(newchar);

                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteCharacter(int charId)
        {
            try
            {

                using (var db = new DatabaseContext())
                {

                    var character = db.Character.Find(charId);
                    db.Character.Remove(character);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static Character GetCharacter(int charId)
        {
            try
            {
                var character = new Character();

                using (var db = new DatabaseContext())
                {

                    character = db.Character
                        .Include(i => i.Quests)
                        .Include(i => i.Inventory)
                        .Where(x => x.Id == charId).First();

                }

                return character;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<CharacterSimple> GetCharacters(int userId)
        {
            try
            {


                var characterList = new List<Character>();
                var characterSimpleList = new List<CharacterSimple>();

                using (var db = new DatabaseContext())
                {

                    characterList = db.Character
                        .Where(x => x.User.Id == userId).ToList();

                }


                foreach (var item in characterList)
                {

                    characterSimpleList.Add(new CharacterSimple() { Id = item.Id, Name = item.Name, Class = item.Class, Gender = item.Gender, Level = item.Level });
                }

                return characterSimpleList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static ActiveLogin Login(string login, string password)
        {

            try
            {
                var new_session = new ActiveLogin();


                using (var db = new DatabaseContext())
                {

                    var user = db.User.Where(x => x.UserName == login && x.Password == password).First();

                    var old_session = (ActiveLogin)db.ActiveLogin.Where(x => x.User.Id == user.Id);
                    db.ActiveLogin.Remove(old_session);

                    new_session.SessionKey = DateTime.Now.ToString();
                    new_session.User = user;


                    db.ActiveLogin.Add(new_session);

                    db.SaveChanges();

                }

                return new_session;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static bool Register(string username, string password, string email)
        {
            try
            {

                using (var db = new DatabaseContext())
                {
                    //check if the name or email is already in use.
                    var validade = db.User.Where(x => x.UserName == username || x.Email == email).Count();

                    if (validade == 0)
                    {
                        //todo: encrypt password later
                        db.User.Add(new User() { UserName = username, Email = email, Password = password });
                        db.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }



                }

            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }

        }


        public static bool SaveCharacter(Character character)
        {
            try
            {

                using (var db = new DatabaseContext())
                {

                    var old_char = db.Character.Find(character.Id);
                    old_char = character;

                    db.Entry(old_char).State = EntityState.Modified;
                    db.SaveChanges();

                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }

        }


        public static bool ClanAdd(string character_name, int clan_id)
        {
            try
            {

                using (var db = new DatabaseContext())
                {
                    var character = db.Character.Where(x => x.Name == character_name && x.Clan == null).First();

                    character.Clan = db.Clan.Find(clan_id);


                    db.SaveChanges();

                    return true;

                }

            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }

        }

        public static bool ClanCreate(string character_name, string clan_name)
        {
            try
            {

                using (var db = new DatabaseContext())
                {
                    var character = db.Character.Where(x => x.Name == character_name && x.Clan == null).First();

                    character.Clan = new Clan() { Leader = character.User, Name = clan_name };


                    db.SaveChanges();

                    return true;

                }

            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }

        }




        public static bool ClanRemove(int character_id)
        {
            try
            {

                using (var db = new DatabaseContext())
                {
                    var character = db.Character.Where(x => x.Id == character_id).First();

                    character.Clan = null;


                    db.SaveChanges();

                    return true;

                }

            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }

        }


        public static bool ClanDisband(int character_id)
        {
            try
            {

                using (var db = new DatabaseContext())
                {
                    var user = db.Character.Find(character_id).User;

                    var clan = db.Clan.Where(x => x.Leader.Id == user.Id).First();

                    foreach (var item in db.Character.Where(x => x.Clan.Id == clan.Id))
                    {
                        item.Clan = null;
                    }


                    db.Clan.Remove(clan);

                    db.SaveChanges();

                    return true;

                }

            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }

        }



        public static List<Clan> GetClans()
        {
            try
            {
                var db = new DatabaseContext();

                var clanlist = db.Clan.ToList();

                return clanlist;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

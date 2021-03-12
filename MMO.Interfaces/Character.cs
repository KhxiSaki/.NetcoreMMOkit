using System;
using System.Collections.Generic;
using System.Text;

namespace MMO.Interfaces
{
    public class Character
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }


        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public int Gender { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public Clan Clan { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int PosZ { get; set; }
        public float RotationYaw { get; set; }
        public string EquipHead { get; set; }
        public string EquipChest { get; set; }
        public string EquipHands { get; set; }
        public string EquipLegs { get; set; }
        public string EquipFeet { get; set; }
        public string Hotbar0 { get; set; }
        public string Hotbar1 { get; set; }
        public string Hotbar2 { get; set; }
        public string Hotbar3 { get; set; }

        public List<Quest> Quests { get; set; }

        public List<Inventory> Inventory { get; set; }


    }


    public class CharacterSimple
    {
           
        public int Id { get; set; }
      
        public string Name { get; set; }
        public int Class { get; set; }
        public int Gender { get; set; }
        
        public int Level { get; set; }       

    }
}





//--
//--
//-- Table structure for table `characters`
//--

//CREATE TABLE `characters` (
//  `id` int (11) NOT NULL,
//  `user_id` int (11) NOT NULL,
//  `name` varchar(20) NOT NULL,
//  `class` int (11) NOT NULL,
//  `gender` int (11) NOT NULL,
//  `health` int (11) NOT NULL,
//  `mana` int (11) NOT NULL,
//  `level` int (11) NOT NULL,
//  `experience` int (11) NOT NULL,
//  `clan` int (11) NOT NULL,
//  `posx` int (11) DEFAULT NULL,
//  `posy` int (11) DEFAULT NULL,
//  `posz` int (11) DEFAULT NULL,
//  `rotation_yaw` float NOT NULL,
//  `equip_head` varchar(100) DEFAULT NULL,
//  `equip_chest` varchar(100) DEFAULT NULL,
//  `equip_hands` varchar(100) DEFAULT NULL,
//  `equip_legs` varchar(100) DEFAULT NULL,
//  `equip_feet` varchar(100) DEFAULT NULL,
//  `hotbar0` varchar(100) DEFAULT NULL,
//  `hotbar1` varchar(100) DEFAULT NULL,
//  `hotbar2` varchar(100) DEFAULT NULL,
//  `hotbar3` varchar(100) DEFAULT NULL
//) ENGINE=MyISAM DEFAULT CHARSET=utf8;

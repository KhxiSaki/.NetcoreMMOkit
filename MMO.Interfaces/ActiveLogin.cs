using System;
using System.Collections.Generic;
using System.Text;

namespace MMO.Interfaces
{
    public class ActiveLogin
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string SessionKey { get; set; }
        public Character Character { get; set; }
    }
}




//CREATE TABLE `active_logins` (
//  `user_id` int (11) NOT NULL,
//  `session_key` varchar(20) NOT NULL,
//  `character_id` int (11) DEFAULT NULL
//) ENGINE=MyISAM DEFAULT CHARSET=utf8;

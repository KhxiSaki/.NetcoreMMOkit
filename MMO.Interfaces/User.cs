using System;
using System.Collections.Generic;
using System.Text;

namespace MMO.Interfaces
{
   public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }

       public List<Character> Characters { get; set; }
    }
}


//-- --------------------------------------------------------

//--
//-- Table structure for table `users`
//--

//CREATE TABLE `users` (
//  `id` int (11) NOT NULL,
//  `username` varchar(15) NOT NULL,
//  `password` varchar(255) NOT NULL,
//  `email` varchar(32) NOT NULL,
//  `role` int (11) DEFAULT NULL
//) ENGINE=MyISAM DEFAULT CHARSET=utf8;

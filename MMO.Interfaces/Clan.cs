using System;
using System.Collections.Generic;
using System.Text;

namespace MMO.Interfaces
{
    public class Clan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Leader { get; set; }
    }
}




//-- --------------------------------------------------------

//--
//-- Table structure for table `clans`
//--

//CREATE TABLE `clans` (
//  `id` int (11) NOT NULL,
//  `name` varchar(24) NOT NULL,
//  `leader_id` int (11) NOT NULL
//) ENGINE=InnoDB DEFAULT CHARSET=utf8;

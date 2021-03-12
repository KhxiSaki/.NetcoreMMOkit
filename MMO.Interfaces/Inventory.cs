using System;
using System.Collections.Generic;
using System.Text;

namespace MMO.Interfaces
{
   public class Inventory
    {
        public int Id { get; set; }
        public Character Character { get; set; }
        public int Slot { get; set; }
        public string Item { get; set; }
        public int Ammount { get; set; }

    }
}



//-- --------------------------------------------------------

//--
//-- Table structure for table `inventory`
//--

//CREATE TABLE `inventory` (
//  `id` int (11) NOT NULL,
//  `character_id` int (11) NOT NULL,
//  `slot` int (11) NOT NULL,
//  `item` varchar(100) NOT NULL,
//  `amount` int (11) NOT NULL
//) ENGINE=MyISAM DEFAULT CHARSET=utf8;

using System;
using System.Collections.Generic;
using System.Text;

namespace MMO.Interfaces
{
    public class Quest
    {
        public int Id { get; set; }
        public Character Character { get; set; }
        public string QuestName { get; set; }
        public bool Completed { get; set; }
        public int Task1 { get; set; }
        public int Task2 { get; set; }
        public int Task3 { get; set; }
        public int Task4 { get; set; }
    }
}



//-- --------------------------------------------------------

//--
//-- Table structure for table `quests`
//--

//CREATE TABLE `quests` (
//  `id` int (11) NOT NULL,
//  `character_id` int (11) NOT NULL,
//  `quest` varchar(70) NOT NULL,
//  `completed` tinyint(4) NOT NULL,
//  `task1` int (11) NOT NULL,
//  `task2` int (11) NOT NULL,
//  `task3` int (11) NOT NULL,
//  `task4` int (11) NOT NULL
//) ENGINE=InnoDB DEFAULT CHARSET=utf8;

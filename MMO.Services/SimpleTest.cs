using System;
using System.Collections.Generic;
using System.Text;
using MMO.Data;

namespace MMO.Services
{
    public static class SimpleTest
    {

        public static void SeedTestData()
        {

            using (var  db = new DatabaseContext())
            {

                db.SimpleValues.Add(new Interfaces.SimpleValues() { Value1 = "teste1", Value2 = "teste1" });
                db.SaveChanges();
            }
        }
    }
}

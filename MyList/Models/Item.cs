using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyList.Models
{
    [Table("MyListItems")]
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ItemId { get; set; }
        public string ItemDescr { get; set; }
        public string ItemType { get; set; }
        public bool Done { get; set; }
    }
}

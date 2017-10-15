using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ToDoListContainer
    {
        public Guid ID { get; set; }
        public string ListName { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ToDoListItem> ItemsToDo { get; set; }
        public string CreatorFullName { get; set; }
    }
}

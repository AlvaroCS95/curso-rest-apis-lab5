using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetWebApi.Entities
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }

        //[Column]
        public string Title { get; set; }

        public bool IsComplete { get; set; }
    }
}
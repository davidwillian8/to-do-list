using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Api.ViewModels
{
    public class BoardViewModel
    {
        public Guid Id { get; set; }

        [Required, Range(1, 30)]
        public string Name { get; set; }
    }
}
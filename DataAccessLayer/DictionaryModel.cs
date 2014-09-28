using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DictionaryModel
    {
        [Key]
        public int DictionaryId { get; set; } 
        public string Word { get; set; }
        public string Language { get; set; } 
    }
}

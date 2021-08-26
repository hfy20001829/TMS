using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
   public class EntryManage
    {
        public int EntryId    { get; set; }
        public string EntrtName  { get; set; }
        public int UserId     { get; set; }
        public string EntryPost  { get; set; }
        public string EntryUP    { get; set; }
        public DateTime EntryTime  { get; set; }
        public DateTime EntryCTime { get; set; }
        public string EntryState { get; set; }
        public string EntryAppr { get; set; }
    }
}

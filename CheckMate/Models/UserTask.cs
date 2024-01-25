using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate.Models
{
    public class UserTask
    {
        // Primary key and auto-incrementing identifier for the task
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime completionTime { get; set; }
        public int timerHour {  get; set; }
        public int timerMinute { get; set; }
        public int timerSecond {  get; set; }
        public int Priority { get; set; }
        public string Description {  get; set; }

        // Creates a shallow copy (clone) of the UserTask object
        public UserTask Clone() => MemberwiseClone() as UserTask;
    }
}

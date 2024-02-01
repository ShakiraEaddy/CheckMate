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

        public (bool isValid, string? errorMessage) Validate()
        {
            if(string.IsNullOrWhiteSpace(Name))
            {
                return (false, $"{nameof(Name)} is required.");
            }
            else if(Priority <= 0)
            {
                return (false, $"{nameof(Priority)} must be greater than 0.");
            }
           /* else if(timerHour <= 0)
            {
                return (false, $"Invalid value for {nameof(timerHour)}. Value must be greater than 0.");
            }
            else if (timerMinute <= 0)
            {
                return (false, $"Invalid value for {nameof(timerMinute)}. Value must be greater than 0.");
            }
            else if (timerSecond <= 0)
            {
                return (false, $"Invalid value for {nameof(timerSecond)}. Value must be greater than 0.");
            } */
            return (true, null);
        }
    }
}

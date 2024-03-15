using SQLite;

namespace CheckMate.Models
{
    public class UserTask
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CompletionTime { get; set; }
        public TimeSpan TimerDuration { get; set; }
        public int TimerHour { get; set; }
        public int TimerMinute { get; set; }
        public int TimerSecond { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }

        public UserTask Clone() => MemberwiseClone() as UserTask;
    }
}

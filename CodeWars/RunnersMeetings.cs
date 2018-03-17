using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    public partial class Kata
    {
        public int RunnersMeetings(int[] startPositions, int[] speeds)
        {
            var orderedRunners = GetRunnersInOrderByStartPosition(startPositions, speeds);
            var meetings = GetMeetings(orderedRunners);
            return GetMaxMeetingCardinality(meetings);
        }

        private int GetMaxMeetingCardinality(Dictionary<Meeting, HashSet<Runner>> meetings)
        {
            return meetings.Values.Count > 0 ? meetings.Values.Max(runners => runners.Count) : -1;
        }

        private Dictionary<Meeting, HashSet<Runner>> GetMeetings(Runner[] orderedRunners)
        {
            var meetings = new Dictionary<Meeting, HashSet<Runner>>();
            for (int i = 0; i < orderedRunners.Length - 1; i++)
            {
                var behindRunner = orderedRunners[i];
                for (int j = i + 1; j < orderedRunners.Length; j++)
                {
                    var leadingRunner = orderedRunners[j];
                    if (TwoRunnersCanMeet(behindRunner, leadingRunner))
                        AddMeeting(meetings, behindRunner, leadingRunner);
                }
            }
            return meetings;
        }

        private void AddMeeting(Dictionary<Meeting, HashSet<Runner>> meetings, Runner behindRunner, Runner leadingRunner)
        {
            var meeting = new Meeting(behindRunner, leadingRunner);
            if (!meetings.ContainsKey(meeting))
                meetings[meeting] = new HashSet<Runner>();

            if (!meetings[meeting].Contains(behindRunner))
                meetings[meeting].Add(behindRunner);
            if (!meetings[meeting].Contains(leadingRunner))
                meetings[meeting].Add(leadingRunner);
        }

        private static bool TwoRunnersCanMeet(Runner behindRunner, Runner leadingRunner)
        {
            return behindRunner.Speed > leadingRunner.Speed;
        }

        private static Runner[] GetRunnersInOrderByStartPosition(int[] startPositions, int[] speeds)
        {
            var runners = new Runner[speeds.Length];
            for (int i = 0; i < speeds.Length; i++)
                runners[i] = new Runner(startPositions[i], speeds[i]);

            return runners.OrderBy(r => r.StartPosition).ToArray();
        }

    }

    public class Runner
    {
        public Runner(int startPosition, int speed)
        {
            StartPosition = startPosition;
            Speed = speed;
        }

        public int StartPosition { get; }
        public int Speed { get; }
    }

    public struct Meeting
    {
        public Meeting(Runner behindRunner, Runner leadingRunner)
        {
            Time = (leadingRunner.StartPosition - behindRunner.StartPosition) / (double)(behindRunner.Speed - leadingRunner.Speed);
            Position = behindRunner.StartPosition + Time * behindRunner.Speed;
        }

        public double Time { get; }
        public double Position { get; }
    }
}
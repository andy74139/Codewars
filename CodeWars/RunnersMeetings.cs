using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    public partial class Kata
    {
        private Dictionary<Meeting, HashSet<Runner>> _Meetings;

        public int RunnersMeetings(int[] startPositions, int[] speeds)
        {
            ResetMeetings();
            var orderedRunners = GetRunnersInOrderByStartPosition(startPositions, speeds);
            CalculateMeetingCardinality(orderedRunners);
            return GetMaxMeetingCardinality();
        }

        private int GetMaxMeetingCardinality()
        {
            return _Meetings.Values.Count > 0 ? _Meetings.Values.Max(runners => runners.Count) : -1;
        }

        private void CalculateMeetingCardinality(Runner[] orderedRunners)
        {
            for (int i = 0; i < orderedRunners.Length - 1; i++)
            {
                var behindRunner = orderedRunners[i];
                for (int j = i + 1; j < orderedRunners.Length; j++)
                {
                    var leadingRunner = orderedRunners[j];
                    if (TwoRunnersCanMeet(behindRunner, leadingRunner))
                    {
                        var meeting = GetMeeting(behindRunner, leadingRunner);
                        AddMeeting(meeting, behindRunner, leadingRunner);
                    }
                }
            }
        }

        private static bool TwoRunnersCanMeet(Runner behindRunner, Runner leadingRunner)
        {
            return behindRunner.Speed > leadingRunner.Speed;
        }

        private void ResetMeetings()
        {
            _Meetings = new Dictionary<Meeting, HashSet<Runner>>();
        }

        private void AddMeeting(Meeting meeting, Runner runner1, Runner runner2)
        {
            if (!_Meetings.ContainsKey(meeting))
                _Meetings[meeting] = new HashSet<Runner>();

            if (!_Meetings[meeting].Contains(runner1))
                _Meetings[meeting].Add(runner1);
            if (!_Meetings[meeting].Contains(runner2))
                _Meetings[meeting].Add(runner2);
        }

        private Meeting GetMeeting(Runner runnerOnBack, Runner runnerOnFront)
        {
            var time = (runnerOnFront.StartPosition - runnerOnBack.StartPosition) / (double)(runnerOnBack.Speed - runnerOnFront.Speed);
            var position = runnerOnBack.StartPosition + time * runnerOnBack.Speed;
            return new Meeting(time, position);
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
        public Meeting(double time, double position)
        {
            Time = time;
            Position = position;
        }

        public double Time { get; }
        public double Position { get; }
    }
}
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
            var orderedRunners = GetOrderedRunners(startPositions, speeds);
            return CalculateMeetingCardinality(orderedRunners);
        }

        private int CalculateMeetingCardinality(Runner[] orderedRunners)
        {
            for (int i = 0; i < orderedRunners.Length - 1; i++)
            {
                var runnerOnBack = orderedRunners[i];
                for (int j = i + 1; j < orderedRunners.Length; j++)
                {
                    var runnerOnFront = orderedRunners[j];
                    if (runnerOnBack.Speed > runnerOnFront.Speed)
                    {
                        var meeting = GetMeeting(runnerOnBack, runnerOnFront);
                        AddMeeting(meeting, runnerOnBack, runnerOnFront);
                    }
                }
            }
            return _Meetings.Values.Count > 0 ? _Meetings.Values.Max(runners => runners.Count) : -1;
        }

        private void ResetMeetings()
        {
            _Meetings = new Dictionary<Meeting, HashSet<Runner>>();
        }

        private void AddMeeting(Meeting meeting, Runner runner1, Runner runner2)
        {
            var hashCode = meeting;
            if (!_Meetings.ContainsKey(hashCode))
                _Meetings[hashCode] = new HashSet<Runner>();

            if (!_Meetings[hashCode].Contains(runner1))
                _Meetings[hashCode].Add(runner1);
            if (!_Meetings[hashCode].Contains(runner2))
                _Meetings[hashCode].Add(runner2);
        }

        private Meeting GetMeeting(Runner runnerOnBack, Runner runnerOnFront)
        {
            var time = (runnerOnFront.StartPosition - runnerOnBack.StartPosition) / (double)(runnerOnBack.Speed - runnerOnFront.Speed);
            var position = runnerOnBack.StartPosition + time * runnerOnBack.Speed;
            return new Meeting(time, position);
        }

        private static Runner[] GetOrderedRunners(int[] startPositions, int[] speeds)
        {
            var runners = new Runner[speeds.Length];
            for (int i = 0; i < speeds.Length; i++)
            {
                runners[i] = new Runner(startPositions[i], speeds[i]);
            }

            var orderedRunners = runners.OrderBy(r => r.StartPosition).ToArray();
            return orderedRunners;
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
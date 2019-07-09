using KP.BackEnd.Core.DTOs.Shared.Course;

namespace KP.BackEnd.Core.DTOs.Student.Analysis
{
    public class WeeklyAnalysisGetDto
    {
        private CourseGetDto _course;
        private long _totalTime;
        private long _totalDoneTime;

        public CourseGetDto Course
        {
            get => _course;
            set => _course = value;
        }

        public long TotalTime
        {
            get => _totalTime;
            set => _totalTime = value;
        }

        public long TotalDoneTime
        {
            get => _totalDoneTime;
            set => _totalDoneTime = value;
        }
    }
}
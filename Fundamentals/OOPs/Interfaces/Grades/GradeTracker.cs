using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter Destination);
        protected string _name;
        public event NameChangedDelegate NameChanged;

        public string Name
        {
            get { return _name; }
            set
            {
                //if (!String.IsNullOrEmpty(value))
                //{
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name should not be null");
                }
                if (_name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.existingName = _name;
                    args.newName = value;

                    NameChanged(this, args);
                }
                _name = value;
                //}
            }
        }
    }
}

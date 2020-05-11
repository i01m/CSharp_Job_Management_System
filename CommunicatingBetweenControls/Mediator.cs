using CommunicatingBetweenControls.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicatingBetweenControls
{
    public sealed class Mediator
    {
        //static members
        private static readonly Mediator _Instance = new Mediator();
        private Mediator() { }

        public static Mediator GetInstance()
        {
            return _Instance;
        }

        //Instance funtionality
        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {
            //--option 1 with using delegate
            //var JobChangedDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
            //if (JobChangedDelegate != null)
            //{
            //    JobChangedDelegate(sender, new JobChangedEventArgs { Job = job });
            //}

            //--option 2 - using only event
            if (JobChanged != null)
            {
                JobChanged(sender, new JobChangedEventArgs { Job = job });
            }
        }
    }
}

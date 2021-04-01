using CommonServiceLocator;
using Data;
using GalaSoft.MvvmLight;
using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Media;
using System.Windows.Threading;

namespace SmartBellClient.VM
{
    internal class MainViewModel : ViewModelBase
    {
        private System.Threading.Timer timer;
        private IReadLogic readLogic;
        private ITimeLogic timeLogic;
        public ObservableCollection<BellRing> BellRings { get; private set; }
        public ObservableCollection<OutputPath> Outputs { get; private set; }
        private BellRing nextBellRingTime;
        public BellRing NextBellRingTime
        {
            get { return nextBellRingTime; }
            private set { Set(ref this.nextBellRingTime, value); }
        }
        private DateTime clock;
        public DateTime Clock {
            get { return clock; }
            private set { Set(ref this.clock,value); }
        }
        public MainViewModel(IReadLogic readLogic,ITimeLogic timeLogic)
        {
            this.readLogic = readLogic;
            this.timeLogic = timeLogic; 

            if (!this.IsInDesignMode)
            {
                Clock = timeLogic.GetNetworkTime();
                startClock();
                NextBellRingTime = timeLogic.GetNextBellRingTime(Clock);
                BellRingUpdate(NextBellRingTime);
                this.BellRings = new ObservableCollection<BellRing>(readLogic.GetBellRingsForDay(Clock.Date).OrderBy(x=>x.BellRingTime)); // We must implement getting time from the server
                this.Outputs = new ObservableCollection<OutputPath>(readLogic.GetAllOutputPathsForDay(Clock.Date));
                readLogic.GetAllFiles(Outputs);
            }
            else
            {
                this.BellRings = FillWithSamples();
                NextBellRingTime = new BellRing();
                NextBellRingTime.BellRingTime = new DateTime(2069, 04, 20, 12, 34, 56); //This is the only part wich is displayed for the moment
                Clock = new DateTime(1999, 07, 18, 12, 34, 56);
            }
        }
        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IReadLogic>(), IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<ITimeLogic>()) // IoC
        {
        }

        private static ObservableCollection<BellRing> FillWithSamples()
        {
            ObservableCollection<BellRing> brings = new ObservableCollection<BellRing>();
            BellRing br1 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 8, 0, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.Start,
            };
            BellRing br2 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 8, 45, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.End,
            };
            BellRing br3 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 8, 55, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.Start,
            };
            BellRing br4 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 9, 40, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.End,
            };
            BellRing br5 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 9, 55, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.Start,
            };
            BellRing br6 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 10, 40, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.End,
            };
            BellRing br7 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 10, 50, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.Start,
            };
            BellRing br8 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 11, 35, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.End,
            };
            BellRing br9 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 11, 55, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.Start,
            };
            BellRing br10 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 12, 40, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.End,
            };
            BellRing br11 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 12, 50, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.Start,
            };
            BellRing br12 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 13, 35, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.End,
            };
            BellRing br13 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 13, 40, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.Start,
            };
            BellRing br14 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 14, 25, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.End,
            };
            BellRing br15 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 14, 35, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.Start,
            };
            BellRing br16 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 15, 20, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.End,
            };
            BellRing br17 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 15, 25, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.Start,
            };
            BellRing br18 = new BellRing()
            {
                Description = "Automatic generated description",
                BellRingTime = new DateTime(1, 1, 1, 16, 10, 0),
                Interval = new TimeSpan(0, 0, 10),
                Type = BellRingType.End,
            };
            brings.Add(br1);
            brings.Add(br2);
            brings.Add(br3);
            brings.Add(br4);
            brings.Add(br5);
            brings.Add(br6);
            brings.Add(br7);
            brings.Add(br8);
            brings.Add(br9);
            brings.Add(br10);
            brings.Add(br11);
            brings.Add(br12);
            brings.Add(br13);
            brings.Add(br14);
            brings.Add(br15);
            brings.Add(br16);
            brings.Add(br17);
            brings.Add(br18);
            return brings;
        }
        private void BellRingUpdate(BellRing nextbellring)
        {
            if (nextbellring == null)
            {
                return;
            }
            DateTime calledForTime = Clock;
            TimeSpan scheduledTime = new TimeSpan(nextbellring.BellRingTime.Hour, nextbellring.BellRingTime.Minute, nextbellring.BellRingTime.Second)-clock.TimeOfDay;
            //TimeSpan scheduledTime = nextbellring.BellRingTime;
            //if (calledForTime > scheduledTime)
                //throw new Exception("This method should never be called for other than the current day.");

            //double tickTime = (double)(scheduledTime - Clock).TotalMilliseconds;
            this.timer = new System.Threading.Timer(x =>
            {
                
                this.PlayAudio();
            }, null, scheduledTime, Timeout.InfiniteTimeSpan);
        }
        private void PlayAudio()
        {
            MediaPlayer mplayer = new MediaPlayer();

            mplayer.Open(new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Output" + @"\default.mp3"));
            this.NextBellRingTime = this.timeLogic.GetNextBellRingTime(Clock.AddSeconds(5));
            BellRingUpdate(NextBellRingTime);
            mplayer.Play();
            
        }
        private void startClock()
        {
            DispatcherTimer clock = new DispatcherTimer();
            clock.Interval = TimeSpan.FromSeconds(1);
            clock.Tick += this.TicksOfClock;
            clock.Start();
        }
        private void TicksOfClock(object sender, EventArgs e)
        {
            this.Clock = this.Clock.AddSeconds(1);
        }

    }
}

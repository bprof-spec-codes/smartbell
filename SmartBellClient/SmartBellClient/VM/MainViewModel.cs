using CommonServiceLocator;
using Data;
using GalaSoft.MvvmLight;
using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBellClient.VM
{
    internal class MainViewModel : ViewModelBase
    {
        private IReadLogic readLogic;
        public ObservableCollection<BellRing> BellRings { get; private set; }
        public MainViewModel(IReadLogic readLogic)
        {
            this.readLogic = readLogic;

            if (!this.IsInDesignMode)
            {
                this.BellRings = new ObservableCollection<BellRing>(readLogic.GetBellRingsForDay(new DateTime())); // We must implement getting time from the server
            }
            else
            {
                this.BellRings = FillWithSamples();
            }
        }
        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IReadLogic>()) // IoC
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
    }
}

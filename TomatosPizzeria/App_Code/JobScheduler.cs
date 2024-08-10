using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
/// <summary>
/// Summary description for JobScheduler
/// </summary>
public class JobScheduler
{
    public JobScheduler()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static void Start()
    {
        try
        {
            //IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            //scheduler.Start();

            //IJobDetail job = JobBuilder.Create<EmailJob>().Build();

            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithDailyTimeIntervalSchedule
            //      (s =>
            //         s.WithIntervalInMinutes(2)
            //        .OnEveryDay()
            //        .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(0, 00))
            //      )
            //    .Build();

            //scheduler.ScheduleJob(job, trigger);

            //IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            //scheduler.Start();
            //IJobDetail job = JobBuilder.Create<EmailJob>().Build();
            //ITrigger trigger = TriggerBuilder.Create().WithIdentity("trigger1", "group1").StartNow().WithSimpleSchedule(s => s.WithIntervalInMinutes(60).RepeatForever()).Build(); scheduler.ScheduleJob(job, trigger); 

            DateTimeOffset targetTime;
            DateTime sourceDate = new DateTime(2008, 5, 1, 00, 00, 0);
            targetTime = sourceDate;
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<EmailJob>().Build();
            //TimeOfDay dat = TimeOfDay.HourAndMinuteOfDay(12, 06);
            ITrigger trigger = TriggerBuilder.Create().WithIdentity("trigger1", "group1").StartAt(targetTime).WithSimpleSchedule(s => s.WithIntervalInHours(24).RepeatForever()).Build();
            scheduler.ScheduleJob(job, trigger);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteError(ex);
        }
    }
}
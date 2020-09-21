using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Api.Controllers.MeetingBotFunctions
{
    public class SchedulingMeeting
    {

        public string[] Schedule(string day, string date)
        {
            string[] Reunion = new string[2];
            Reunion[0] = date;

            var dia = "";
            if (day.IndexOf("lunes", 0) == 0)
            {
                dia = "MON";
            }
            else if (day.IndexOf("martes", 0) == 0)
            {
                dia = "TUE";
            }
            else if (day.IndexOf("miercoles", 0) == 0)
            {
                dia = "WED";
            }
            else if (day.IndexOf("jueves", 0) == 0)
            {
                dia = "THU";
            }
            else if (day.IndexOf("viernes", 0) == 0)
            {
                dia = "FRI";
            }
            else if (day.IndexOf("sabado", 0) == 0)
            {
                dia = "SAT";
            }
            else if (day.IndexOf("domingo", 0) == 0)
            {
                dia = "SUN";
            }
            else
            {
                dia = "*";
            }


            List<string> days = new List<string>() {
             "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN","*"};

            var parseDate = DateTime.Parse(date);
            var hora = parseDate.Hour;
            var min = parseDate.Minute;

            hora = hora + 6;
            if (hora > 24)
            {
                // 23 + 6 = 29 
                hora = hora - 24;
                // 29 - 24 = 5
                int tmp = days.FindIndex(a => a.Contains(dia));
                if (tmp > 6)
                {
                    tmp = 0;
                }
                dia = days[tmp];
            }

            string cron = ("0 " + min.ToString() + " " + hora.ToString() + " ? * " + dia.ToString());
            Reunion[1] = cron;
            return Reunion;
        }
    }
}

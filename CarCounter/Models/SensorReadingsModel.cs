using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarCounter.Models
{
    public class SensorReadingsModel
    {
        public int Id { get; set; }
        public string sensor { get; set; }

        public string storedReadingsString { get; set; }

        public int[] readings
        {
            get
            {
                if (storedReadingsString != null)
                {
                    return Array.ConvertAll(storedReadingsString.Split(';'), int.Parse);
                }
                else
                {
                    return new int[] {};
                }
                
            }
            set
            {
                var _data = value;
                storedReadingsString = String.Join(";", _data.Select(p => p.ToString()).ToArray());
            }
        }

        //public int[] readings { get; set; }


        public int interval { get; set; }
    }

}
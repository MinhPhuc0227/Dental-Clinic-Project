using DentalClinic.BLL;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class UC_Doctor_Appointment : UserControl
    {
        private readonly Appointment_BLL _appointmentBLL;
        private readonly int _doctorId;
        public UC_Doctor_Appointment(Appointment_BLL appointmenttBLL, int doctorId)
        {
            InitializeComponent();
            _appointmentBLL = appointmenttBLL;
            _doctorId = doctorId;
        }
    }
}

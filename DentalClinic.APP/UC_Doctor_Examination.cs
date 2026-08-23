using DentalClinic.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DentalClinic.APP
{
    public partial class UC_Doctor_Examination : UserControl
    {
        private readonly Visit_BLL _visitBLL;
        private readonly int _doctorId;
        public UC_Doctor_Examination(Visit_BLL visitBLL, int doctorId)
        {
            InitializeComponent();
            _visitBLL = visitBLL;
            _doctorId = doctorId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PurplePen
{
    public partial class LetterAssignament : OkCancelDialog
    {
        public LetterAssignament(EventDB eventDB)
        {
            InitializeComponent();
            courseSelector1.EventDB = eventDB;
        }


        public string FirstLetter
        {
            get
            {
                return firstLetter_box.Text;
            }
            set
            {
                if(value.Length > 1)
                {
                    firstLetter_box.Text = "A";
                } else
                {
                    firstLetter_box.Text = value;
                }
            }
        }

        public Id<Course> SelectedCourses
        {
            get
            {
                return courseSelector1.SelectedCourses.FirstOrDefault();
            }
        }
    }
}

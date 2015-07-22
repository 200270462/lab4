﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference the EF models
using comp2007_lesson10_wed1.Models;
using System.Web.ModelBinding;

namespace comp2007_lesson10_wed1
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading the page for the first time, populate student grid
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        protected void GetStudents()
        {
            try
            {

                //connect to EF
                using (comp2007Entities db = new comp2007Entities())
                {

                    //query the students table using EF and LINQ
                    var Students = from s in db.Students
                                   select s;

                    //bind the result to the gridview
                    grdStudents.DataSource = Students.ToList();
                    grdStudents.DataBind();

                }
            }
            catch
            {
                Response.Redirect("/errors.aspx");
            }
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked
            Int32 selectedRow = e.RowIndex;

            //get the selected StudentID using the grid's Data Key collection
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[selectedRow].Values["StudentID"]);
            try
            {

                //use EF to remove the selected student from the db
                using (comp2007Entities db = new comp2007Entities())
                {

                    Student s = (from objS in db.Students
                                 where objS.StudentID == StudentID
                                 select objS).FirstOrDefault();

                    //do the delete
                    db.Students.Remove(s);
                    db.SaveChanges();
                }
            }
            catch
            {
                Response.Redirect("/errors.aspx");
            }

            //refresh the grid
            GetStudents();
        }
    }
}
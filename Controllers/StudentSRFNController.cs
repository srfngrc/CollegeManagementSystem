using CollegeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeManagementSystem.Controllers
{
    public class StudentSRFNController : Controller
    {
        // GET: StudentSRFN
        public ActionResult IndexStudent()
        {
            List<StudentSRFN> allStudentsListed = new List<StudentSRFN>();
            allStudentsListed = ReadAllStudentsFromDB();
            return View("IndexStudent", allStudentsListed);
        }


        static List<StudentSRFN> ReadAllStudentsFromDB()
        {
            List<StudentSRFN> myStudents = new List<StudentSRFN>();
            SqlConnection myConnStu = new SqlConnection();
            try
            {
                myConnStu.ConnectionString = ConfigurationManager.ConnectionStrings["ExamConnectionSRFN"].ConnectionString;
                myConnStu.Open();

                string queryStu = "SELECT StudentId,FirstName,LastName,BirthDate,EmailAddr,Country FROM Students;";
                SqlCommand commandStu = new SqlCommand(queryStu, myConnStu);

                SqlDataReader myUsersResults = commandStu.ExecuteReader();
                while (myUsersResults.Read())
                {
                    StudentSRFN newStudent = new StudentSRFN();
                    newStudent.StudentId = int.Parse(myUsersResults["StudentId"].ToString());
                    newStudent.FirstName = myUsersResults["FirstName"].ToString();
                    newStudent.LastName = myUsersResults["LastName"].ToString();
                    newStudent.BirthDate = (DateTime)myUsersResults["BirthDate"]; 
                    newStudent.EmailAddr = myUsersResults["EmailAddr"].ToString();
                    newStudent.Country = myUsersResults["Country"].ToString();
                    myStudents.Add(newStudent);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                myConnStu.Close();
            }
            return myStudents;
        }

        // GET: StudentSRFN/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentSRFN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentSRFN/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentSRFN/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentSRFN/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentSRFN/Delete/5
        public ActionResult Delete(int id)
        {
            SqlConnection connDELETEstudent = new SqlConnection();
            connDELETEstudent.ConnectionString = ConfigurationManager.ConnectionStrings["ExamConnectionSRFN"].ConnectionString;

            try
            {
                connDELETEstudent.Open();
                SqlCommand commDELETE = new SqlCommand("DELETE FROM Students WHERE StudentId = " + id + ";", connDELETEstudent);
                commDELETE.ExecuteNonQuery();
            }
            catch
            {
                return null;
            }
            finally
            {
                connDELETEstudent.Close();
            }

            return RedirectToAction("IndexStudent");
        }

        //// POST: StudentSRFN/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

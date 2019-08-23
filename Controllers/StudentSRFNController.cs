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
            return View("");
        }

        // POST: StudentSRFN/Create
        [HttpPost]
        public ActionResult Create(FormCollection collectionExam)
        {
            StudentSRFN newStudent = new StudentSRFN();
            SqlConnection connCREATEpost = new SqlConnection();
            try
            {
                connCREATEpost.ConnectionString = ConfigurationManager.ConnectionStrings["ExamConnectionSRFN"].ConnectionString;

                newStudent.FirstName = collectionExam["FirstName"];
                newStudent.LastName = collectionExam["LastName"];
                newStudent.BirthDate = Convert.ToDateTime(collectionExam["BirthDate"].ToString());
                newStudent.EmailAddr = collectionExam["EmailAddr"];
                newStudent.Country = collectionExam["Country"];

                string queryCREATEnew = "INSERT INTO Students (FirstName,LastName,BirthDate,EmailAddr,Country)" +
                    " VALUES ('" +
                    newStudent.FirstName + "','" +
                    newStudent.LastName + "','" +
                    newStudent.BirthDate + "','" +
                    newStudent.EmailAddr + "','" +
                    newStudent.Country + "');";

                connCREATEpost.Open();

                SqlCommand commCREATEpost = new SqlCommand(queryCREATEnew, connCREATEpost);
                commCREATEpost.ExecuteNonQuery();

                return RedirectToAction("IndexStudent");
            }
            catch (Exception ex)
            {
                return View();
            }
            finally
            {
                connCREATEpost.Close();
            }

        }
        // GET: StudentSRFN/Edit/5
        public ActionResult Edit(int id)
        {
            SqlConnection connEditGet = new SqlConnection();
            connEditGet.ConnectionString = ConfigurationManager.ConnectionStrings["ExamConnectionSRFN"].ConnectionString;
            StudentSRFN OperationToEdit = new StudentSRFN();

            try
            {
                connEditGet.Open();
                string queryEDITgetExam = "SELECT * FROM Students WHERE StudentId =" + id + ";";
                SqlCommand commEditGetOperations = new SqlCommand(queryEDITgetExam, connEditGet);
                SqlDataReader DReditGetOp = commEditGetOperations.ExecuteReader();

                while (DReditGetOp.Read())
                {
                    OperationToEdit.FirstName = DReditGetOp["FirstName"].ToString();
                    OperationToEdit.LastName = DReditGetOp["LastName"].ToString();
                    OperationToEdit.BirthDate = Convert.ToDateTime(DReditGetOp["BirthDate"]);
                    OperationToEdit.EmailAddr = DReditGetOp["EmailAddr"].ToString();
                    OperationToEdit.Country = DReditGetOp["Country"].ToString();
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connEditGet.Close();
            }
            return View(OperationToEdit);
        }

        // POST: StudentSRFN/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collectionExam)
        {
            SqlConnection connEditPostStu = new SqlConnection();
            connEditPostStu.ConnectionString = ConfigurationManager.ConnectionStrings["ExamConnectionSRFN"].ConnectionString;
            StudentSRFN Modifiedstudent = new StudentSRFN();

            try
            {
                connEditPostStu.Open();

                string queryEDITexam = "UPDATE Students SET " +
                "FirstName = '" + collectionExam["FirstName"] + "', " +
                "LastName = '" + collectionExam["LastName"] + "', " +
                "BirthDate = '" + Convert.ToDateTime(collectionExam["BirthDate"]) + "', " +
                "EmailAddr = '" + collectionExam["EmailAddr"] + "', " +
                "Country = '" + collectionExam["Country"] + "' " +
                "WHERE StudentId = " + id + ";";

                SqlCommand commandEDITpostOp = new SqlCommand(queryEDITexam, connEditPostStu);
                commandEDITpostOp.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connEditPostStu.Close();
            }
            return RedirectToAction("IndexStudent");
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

    }
}

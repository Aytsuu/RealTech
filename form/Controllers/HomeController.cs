using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace form.Controllers
{
    public class HomeController : Controller
    {

        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\patty\source\repos\form\form\App_Data\UPDRAFT_DATABASE.mdf;Integrated Security=True";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AdminProductsList()
        {
            return View();
        }

        public ActionResult AdminEditProduct()
        {
            return View();
        }

        public ActionResult AdminSignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminProductsList(FormCollection col, HttpPostedFileBase img)
        {

            string image = Path.GetFileName(img.FileName);

            string logpath = "C:\\ASPIMAGES";
            string filepath = Path.Combine(logpath, image);
            img.SaveAs(filepath);

            var pname = col["prod-name"].ToLower();
            var pdescription = col["prod-desc"].ToLower();
            float price = float.Parse(col["prod-price"]);
            var pStock = col["prod-stock"];

            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO PRODUCT_ENTRY (PROD_NAME, PROD_DESCRIPTION, PROD_PRICE, PROD_STOCK, PROD_IMG) VALUES (@pname, @pdesc, @price, @pstock, @pimg)";
                    cmd.Parameters.AddWithValue("@pname", pname);
                    cmd.Parameters.AddWithValue("@pdesc", pdescription);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@pstock", pStock);
                    cmd.Parameters.AddWithValue("@pimg", image);
                    cmd.ExecuteNonQuery();
                }
   
            }

            return View();
        }

        [HttpPost]
        public ActionResult AdminEditProduct(FormCollection col, HttpPostedFileBase img)
        {

            string image;
            var pid = col["prod-id"];
            var pname = col["prod-name"].ToLower();
            var pdescription = col["prod-desc"].ToLower();
            float price = float.Parse(col["prod-price"]);
            var pStock = col["prod-stock"];

            if (img == null)
            {
                image = col["prod-img"];
            }
            else
            {
                image = Path.GetFileName(img.FileName);
                string logpath = "C:\\ASPIMAGES";
                string filepath = Path.Combine(logpath, image);
                img.SaveAs(filepath);
            }

            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE PRODUCT_ENTRY SET PROD_NAME = '" + pname + "', PROD_DESCRIPTION = '" + pdescription 
                        + "', PROD_PRICE = " + price + ", PROD_STOCK = '" + pStock + "', PROD_IMG = '" + image 
                        + "' WHERE PROD_ID = '" + pid +"'";
                    cmd.ExecuteNonQuery();
                }

            }

            return View();
        }

        public ActionResult CustomerView()
        {
            return View();
        }

        public ActionResult CustomerViewProducts()
        {
            return View();
        }

        public ActionResult CustomerViewCart()
        {
            return View();
        }

        public ActionResult SignInView()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult SignUpView()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            return View();
        }

        public ActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfile(FormCollection col)
        {

            var username = col["username"].ToLower();
            int userid = getUserId(username);

            var firstname = col["fname"].ToUpper();
            var lastname = col["lname"].ToUpper();
            var dateofbirth = col["dateofbirth"];
            var sex = col["sex"];
            var status = col["status"];
            var state = col["state"].ToUpper();
            var city = col["city"].ToUpper();
            var homeAddress = col["homeAdd"].ToUpper();
            var postal = col["postal"];

            using(var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO PROFILE (FIRSTNAME, LASTNAME, SEX, DATEOFBIRTH, STATUS, STATE, CITY, HOMEADDRESS,POSTALCODE,USER_ID) " +
                        "VALUES (@firstname, @lastname, @sex, @dateofbirth, @status, @state, @city, @homeaddress, @postalcode, @userid)";
                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@lastname", lastname);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@dateofbirth", dateofbirth);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@homeaddress", homeAddress);
                    cmd.Parameters.AddWithValue("@postalcode", postal);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.ExecuteNonQuery();
                }
                
            }

            return Redirect("https://localhost:44352/Home/CustomerView");
        }

        [HttpPost]
        public ActionResult UpdateProfile(FormCollection col)
        {

            var username = col["username"].ToLower();
            int userid = getUserId(username);

            var firstname = col["fname"].ToUpper();
            var lastname = col["lname"].ToUpper();
            var dateofbirth = col["dateofbirth"];
            var sex = col["sex"];
            var status = col["status"];
            var email = col["email"];
            var number = col["phone"];
            var state = col["state"].ToUpper();
            var city = col["city"].ToUpper();
            var homeAddress = col["homeAdd"].ToUpper();
            var postal = col["postal"];

            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE USER_ACCOUNTS SET EMAIL = '" + email + "', NUMBER = '" + number + "' WHERE USER_ID = " + userid;
                    cmd.ExecuteNonQuery();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE PROFILE SET FIRSTNAME = '" + firstname + "', LASTNAME = '" + lastname + "', SEX = '" + sex + "', DATEOFBIRTH = '" + dateofbirth
                        + "', STATUS = '" + status + "', STATE = '" + state + "', CITY = '" + city + "', HOMEADDRESS = '" + homeAddress + "', POSTALCODE = '" + postal + "' WHERE USER_ID = " + userid;
                    cmd.ExecuteNonQuery();
                }

            }

            return Redirect("https://localhost:44352/Home/UserProfile");
        }

        public ActionResult AddAccount()
        {
            var data = new List<object>();
            string username = Request["user"];
            string email = Request["email"];
            string number = Request["number"];
            string password = Request["pass"];


            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO USER_ACCOUNTS (USERNAME, EMAIL, NUMBER, PASSWORD) VALUES (@username, @email, @number, @password)";
                    cmd.Parameters.AddWithValue("@username", username.ToLower());
                    cmd.Parameters.AddWithValue("@email", email.ToLower());
                    cmd.Parameters.AddWithValue("@number", number.ToLower());
                    cmd.Parameters.AddWithValue("@password", password);
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        data.Add(new { mess = 1 });
                    }
                }
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidateUser()
        {
            var data = new List<object>();
            string username = Request["user"];


            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())    
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT COUNT(*) FROM USER_ACCOUNTS WHERE username = '" + username.ToLower() + "'";
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        data.Add(new { mess = 1 });
                    }
                    else data.Add(new { mess = 0 });
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidateEmail()
        {
            var data = new List<object>();
            string email = Request["email"];


            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT COUNT(*) FROM USER_ACCOUNTS WHERE email = '" + email.ToLower() + "'";
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        data.Add(new { mess = 1 });
                    }
                    else data.Add(new { mess = 0 });
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidateNumber()
        {
            var data = new List<object>();
            string number = Request["number"];


            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT COUNT(*) FROM USER_ACCOUNTS WHERE number = '" + number + "'";
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        data.Add(new { mess = 1 });
                    }
                    else data.Add(new { mess = 0 });
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SignInDBConnection()
        {
            var data = new List<object>();
            string username = Request["user"];
            string password = Request["pass"];
            int userid = getUserId(username);


            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd1 = db.CreateCommand())
                {
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "SELECT USERNAME, EMAIL, NUMBER FROM USER_ACCOUNTS WHERE USERNAME = @username OR EMAIL = @username OR NUMBER = @username";
                    cmd1.Parameters.AddWithValue("@username", username);

                    string retrivedData = (string)cmd1.ExecuteScalar();
                    if (retrivedData != null)
                    {
                        using (var cmd2 = db.CreateCommand())
                        {
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "SELECT PASSWORD FROM USER_ACCOUNTS WHERE USERNAME = '" + retrivedData + "'";
                            string retrievedPass = (string)cmd2.ExecuteScalar();
                            if (retrievedPass == password)
                            {
                                using (var cmd = db.CreateCommand())
                                {
                                    cmd.CommandType = CommandType.Text;
                                    cmd.CommandText = "SELECT COUNT(*) FROM PROFILE WHERE USER_ID = " + userid;
                                    int ctr = (int)cmd.ExecuteScalar();
                                    if (ctr > 0)
                                    {
                                        data.Add(new { mess = 1 });
                                        Session["username"] = username;
                                        Session["profile"] = username;
                                    }
                                    else data.Add(new { mess = 2 });

                                }
                            }
                            else data.Add(new { mess = 0 });
                        }
                    }
                    else data.Add(new { mess = 0 });
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public FileResult Image(string filename)
        {
            var folder = "";
            var filepath = "";

            try
            {
                folder = "C:\\ASPIMAGES";
                filepath = Path.Combine(folder, filename);
                if (!System.IO.File.Exists(filepath))
                {
                    Response.Write("<script>alert('Image not found')</script>");
                }
            }
            catch (Exception)
            {

            }
            var mime = System.Web.MimeMapping.GetMimeMapping(Path.GetFileName(filepath));
            Response.Headers.Add("content-disposition", "inline");
            return new FilePathResult(filepath, mime);
        }

        public int getUserId(string username)
        {
            int userid = 0;

            using (var db = new SqlConnection(connStr))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM USER_ACCOUNTS WHERE USERNAME = '" + username + "' OR NUMBER = '" + username + "' OR EMAIL = '" + username + "'";
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.Read())
                    {
                        userid = Int32.Parse(result["user_id"].ToString());

                    }

                    result.Close();
                }
            }

            return userid;
        }

        public ActionResult AddToCart()
        {
            var data = new List<object>();
            string username = Request["user"];
            int prod_id = Int32.Parse(Request["prodID"]);
            string quantity = Request["quantity"];
            int userid = getUserId(username);

            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT COUNT(*) FROM CART WHERE PROD_ID = " + prod_id + " AND USER_ID = " + userid;
                    int result = (int)cmd.ExecuteScalar();
                    if (result > 0)
                    {
                        using (var cmd1 = db.CreateCommand())
                        {
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "UPDATE CART SET QUANTITY += " + quantity + " WHERE PROD_ID = " + prod_id + " AND USER_ID = " + userid;
                            var ctr = cmd1.ExecuteNonQuery();
                            if (ctr > 0)
                            {
                                data.Add(new
                                {
                                    mess = 1
                                });
                            }
                        }
                    }
                    else
                    {
                        using (var cmd2 = db.CreateCommand())
                        {
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "INSERT INTO CART (PROD_ID, USER_ID, QUANTITY) VALUES (@prodid, @userid, @quantity)";
                            cmd2.Parameters.AddWithValue("@prodid", prod_id);
                            cmd2.Parameters.AddWithValue("@userid", userid);
                            cmd2.Parameters.AddWithValue("@quantity", quantity); 

                            var affectedRows = cmd2.ExecuteNonQuery();
                            if (affectedRows > 0)
                            {
                                data.Add(new { mess = 1 });
                                Session["username"] = username;

                            }

                        }
                    }
                }
                    
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserCart()
        {
            var data = new List<object>();
            string username = Request["user"];
            Session["username"] = username;
            Session["profile"] = username;
            data.Add(new { mess = 1 });

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FPEmailChecker()
        {
            var data = new List<object>();
            var username = Request["user"];
            var email = Request["email"];

            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT COUNT(*) FROM USER_ACCOUNTS WHERE USERNAME = '" + username.ToLower() + "' AND EMAIL = '" + email.ToLower() + "'";
                    int count = (int)cmd.ExecuteScalar();
                    if(count > 0)
                    {
                        data.Add(new { mess = 1 });
                    }
                    else data.Add(new { mess = 0 });
                }
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FPDoBChecker()
        {
            var data = new List<object>();
            var username = Request["user"];
            var email = Request["email"];
            var dob = Request["dob"];

            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT COUNT(*) FROM USER_ACCOUNTS AS UA, PROFILE AS P WHERE P.USER_ID = UA.USER_ID AND USERNAME = '" + username.ToLower() + "' AND UA.EMAIL = '" + email.ToLower() + "' AND DATEOFBIRTH = '" + dob + "'";
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        data.Add(new { mess = 1 });
                    }
                    else data.Add(new { mess = 0 });
                }
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FPChangePass()
        {
            var data = new List<object>();
            var username = Request["user"];
            var newpass = Request["newpass"];

            using(var db = new SqlConnection(connStr))
            {
                db.Open();
                using(var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE USER_ACCOUNTS SET PASSWORD = '" + newpass + "' WHERE USERNAME = '" + username + "'";
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        data.Add(new
                        {
                            mess = 1
                        });
                    }
                }
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteCartProduct()
        {
            var data = new List<object>();
            var username = Request["user"];
            var prod_id = Request["prodid"];
            var user_id = getUserId(username);

            using(var db = new SqlConnection(connStr))
            {
                db.Open();

                using(var cmd = db.CreateCommand()) { 
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM CART WHERE PROD_ID = " + prod_id + " AND USER_ID = " + user_id;
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        data.Add(new { mess = 1 });
                    }
                }
            }


            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditProductSession()
        {
            var data = new List<object>();
            var prodid = Request["prodid"];
            Session["productId"] = prodid;
            data.Add(new
            {
                mess = 1
            });

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteProduct()
        {
            var data = new List<object>();
            var prod_id = Request["prodid"];

            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM PRODUCT_ENTRY WHERE PROD_ID = " + prod_id ;
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        data.Add(new { mess = 1 });
                    }
                }
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SignalSearchBar()
        {
            var data = new List<object>();
            var searchKey = Request["key"];
            Session["searchKey"] = searchKey;
            data.Add(new { mess = 1 });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}


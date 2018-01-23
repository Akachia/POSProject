using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSproject
{
    class Prcd
    {
        public static DateTime checkin;
        static public bool LogIn(string id, string pwd)
        {
            if(CheckID(id))
            {
                if(CheckPwd(id,pwd))
                {
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("비밀번호가 맞지 않습니다!");
                    return false;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("ID를 확인해주세요!");
                return false;
            }
            
        }


        static private bool CheckID(string id)
        {
            
           
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                //con.Open();
                using (var cmd = new SqlCommand("CheckID", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", id);

                    var sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {


                        sdr.Close();
                        return true;
                    }
                    else
                    {
                        sdr.Close();
                        return false;
                    }
                }
            }
        }

        static public string CheckAdmin(string id)
        {


            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                //con.Open();
                string admin=null;
                using (var cmd = new SqlCommand("CheckAdmin", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userID", id);

                    var sdr = cmd.ExecuteReader();
                    while(sdr.Read())
                    {
                        if (!(sdr["Authority"].ToString() == null))
                        {
                            admin= sdr["Authority"].ToString();
                            //System.Windows.Forms.MessageBox.Show("Test");
                        }
                        
                    }
                    
                }
                return admin;
            }
        }


        static private bool CheckPwd(string id, string pwd)
        {
            
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                //con.Open();
                using (var cmd = new SqlCommand("CheckPwd", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", id);
                    cmd.Parameters.AddWithValue("@userPwd", pwd);


                    var sdr = cmd.ExecuteScalar();

                    if (sdr.ToString()=="1")
                    {


                       
                        return true;
                    }
                    else
                    {
                       
                        return false;
                    }
                }
            }
        }

        static public Hashtable CheckInfo(string id)
        {
            Hashtable infoTable = new Hashtable();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                //con.Open();
                using (var cmd = new SqlCommand("SelectUserInfo", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", id);
                    var sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        infoTable.Add("UserName", sdr["UserName"].ToString());
                        infoTable.Add("UserPhone", sdr["UserPhone"].ToString());
                        infoTable.Add("UserPic", sdr["UserPic"].ToString());
                    }


                    con.Close();

                }

            }

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                //con.Open();
                using (var cmd = new SqlCommand("SelectPerferences", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    var sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                         infoTable.Add("StoreName",sdr["StoreName"].ToString());
                        infoTable.Add("StoreAddr", sdr["Addr"].ToString());
                        infoTable.Add("CallNumber", sdr["CallNumber"].ToString());
                    }


                    con.Close();
                    
                }

            }

            return infoTable;
        }


        static public void EndWork(string id, DateTime checkOut)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                int workingtime = int.Parse(checkOut.Subtract(checkin).TotalHours.ToString().Split('.')[0]);
                System.Windows.Forms.MessageBox.Show(workingtime+"  ");
                //con.Open();
                using (var cmd = new SqlCommand("EndWork", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@worker", id);
                    cmd.Parameters.AddWithValue("@startTime", checkin);
                    cmd.Parameters.AddWithValue("@endTime", checkOut);
                    cmd.Parameters.AddWithValue("@workingtime", workingtime);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }

    

}

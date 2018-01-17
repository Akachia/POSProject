using System;
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
        public DateTime checkin;
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
    }
}

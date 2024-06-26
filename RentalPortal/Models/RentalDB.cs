using System.Data;
using System.Data.SqlClient;
using RentalPortal.Models;
namespace RentalPortal.Models
{
    public class RentalDB
    {
        SqlConnection con = new SqlConnection(@"server=SALMA\SQLEXPRESS;database=MyCoreProjectDB;Integrated security=true");
        public string OwnerInsertDB(OwnerInsert objcls)
        {
            try

            {
                SqlCommand cmd1 = new SqlCommand("sp_MaxRegId", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                con.Open();
                var i = cmd1.ExecuteScalar().ToString();
                con.Close();

                int mid = Convert.ToInt32(i);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                SqlCommand cmd = new SqlCommand("sp_ownerInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@oid", regid);
                cmd.Parameters.AddWithValue("@ona", objcls.oname);
                cmd.Parameters.AddWithValue("@oaddr", objcls.oaddr);
                cmd.Parameters.AddWithValue("@oc1", objcls.ophn1);
                cmd.Parameters.AddWithValue("@oc2", objcls.ophn2);
                cmd.Parameters.AddWithValue("@oemail", objcls.oemail);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                SqlCommand cmd2 = new SqlCommand("sp_loginInsert", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@rid", regid);
                cmd2.Parameters.AddWithValue("@uname", objcls.ousername);
                cmd2.Parameters.AddWithValue("@pwd", objcls.opassword);
                cmd2.Parameters.AddWithValue("@type", "Owner");
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                return ("Inserted successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
        public string BuyerInsertDB(BuyerInsert objcls)
        {
            try

            {
                SqlCommand cmd1 = new SqlCommand("sp_MaxRegId", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                con.Open();
                var i = cmd1.ExecuteScalar().ToString();
                con.Close();

                int mid = Convert.ToInt32(i);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                SqlCommand cmd = new SqlCommand("sp_buyerInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bid", regid);
                cmd.Parameters.AddWithValue("@bna", objcls.bname);
                cmd.Parameters.AddWithValue("@baddr", objcls.baddr);
                cmd.Parameters.AddWithValue("@bc1", objcls.bphn1);
                cmd.Parameters.AddWithValue("@bc2", objcls.bphn2);
                cmd.Parameters.AddWithValue("@email", objcls.bemail);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                SqlCommand cmd2 = new SqlCommand("sp_loginInsert", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@rid", regid);
                cmd2.Parameters.AddWithValue("@uname", objcls.busername);
                cmd2.Parameters.AddWithValue("@pwd", objcls.bpassword);
                cmd2.Parameters.AddWithValue("@type", "Buyer");
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                return ("Inserted successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
        public string LoginDB(Login objcls)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CountLogId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uname", objcls.username);
                cmd.Parameters.AddWithValue("@pwd", objcls.password);

                con.Open();
                string i = cmd.ExecuteScalar().ToString();
                con.Close();
                if (i == "1")
                {
                    SqlCommand cmd1 = new SqlCommand("sp_logType", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@una", objcls.username);
                    cmd1.Parameters.AddWithValue("@pwd", objcls.password);

                    con.Open();
                    string t = cmd1.ExecuteScalar().ToString();
                    con.Close();
                    return t;
                }
                else
                {
                    return ("Login unsuccessfull");
                }

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
        public string LoginIdDB(Login objcls)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_logRegId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@una", objcls.username);
                cmd.Parameters.AddWithValue("@pwd", objcls.password);

                con.Open();
                string id = cmd.ExecuteScalar().ToString();
                
                con.Close();
                return id;

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
    }
}

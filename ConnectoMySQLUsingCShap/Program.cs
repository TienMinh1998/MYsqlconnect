using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ConnectoMySQLUsingCShap
{
    class Program
    {
        public static MySqlConnection conn;
        public static MySqlCommand cmd;

        public static void OpenConnectToMySQL()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {

            }
            else
            {
                conn.Open();
            }
        }

        public static void Menu()
        {
            Console.WriteLine("***************MAIN MENU CHƯƠNG TRÌNH NGUYỄN VIẾT MINH TIẾN**********");
            Console.WriteLine();
            Console.WriteLine("*******TINH CHU VI VA DIEN TICH HINH********");
            Console.WriteLine("___________________________________________.");
            Console.WriteLine("1. |   XEM DANH SÁCH                       |");
            Console.WriteLine("2. |   THÊM MỚI SINH VIÊN                  |");
            Console.WriteLine("3. |   SỬA SINH VIÊN                       |");
            Console.WriteLine("4. |   XÓA SINH VIÊN                       |");
            Console.WriteLine("5. |   THOÁT CHƯƠNG TRÌNH                  |");
            Console.WriteLine("6. |   XEM CODE KẾT NỐI MySQL              |");
            Console.WriteLine("___|_______________________________________|");
            Console.Write(" =>   NHAP LUA  CHON CUA BAN VAO:");

        }   
        public static void LuaChon()
        {
            int chon;
            chon = int.Parse(Console.ReadLine());
            switch (chon)
            {
                case 1:
                    Console.WriteLine("Đang Chạy Hàm  [xem danh sách] Wait me!!");
                
                    List<SinhVien> students;
                    students = HienThiThongTinSinhVien();
                    foreach (var student in students)
                    {
                        Console.WriteLine("ID = {0}, Name of Student : {1}, Code of Student : {2} ", String.Format("{0,-12}", student.Id),                                                                                                   String.Format("{0,-30}", student.Ten),                                                                                            String.Format("{0,-12}", student.Ma));
                    }
                    Console.WriteLine("1.   Sửa Thong Tin Sinh Viên.");
                    Console.WriteLine("0.   Quay lại menu chính.");

                    Luachon2();
                
                  
                    break;
                case 2:
                    // add New student : 
                    String ten, ma;
                    int id;
                    OpenConnectToMySQL();

                    Console.WriteLine("<1.> Nhập vào tên của sinh viên");
                    ten = Console.ReadLine();
                    Console.WriteLine("<2.> Nhập vào mã của Sinh Viên : ");
                    ma = Console.ReadLine();
                    Console.WriteLine("<3.> Nhập vào ID của Sinh Viên : ");
                    id = int.Parse(Console.ReadLine());

                    Themmoisinhvien(id,ma,ten);
                    Console.WriteLine("1.   Them Tiep Sinh Vien.");
                    Console.WriteLine("0.   Quay lại menu chính.");

                    Luachon2();
                    break;
                case 3:


                case 4:
                    break;
                default:
                    Console.WriteLine("vui long nhap lai");
                    break;

            }
            while (chon != 5)
            {
                Console.ReadLine();
            }
        }
        public static bool Themmoisinhvien()
        {
            try
            {
                String sql = "insert into tblSinhVien values (20,'TestCShap2','20')";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Successfully added new Student");

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public static bool Themmoisinhvien(int id, string ma, string ten)
        {
            try
            {
                String sql = "insert into tblSinhVien values ("+id+",'"+ten+"','"+ma+"')";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Successfully added new Student " + ten + "To Mydatabase");
                
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public static List<SinhVien> HienThiThongTinSinhVien() 
        {
            List<SinhVien> dsSV = new List<SinhVien>();
            try
            {
                // Nhap thong tin
                String sql = "select * from tblSinhVien";
                cmd = new MySqlCommand(sql, conn);
               
                MySqlDataReader rd;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    int idSV = rd.GetInt32(0);

                    string tenSV = rd.GetString(1);
                    string maSV = rd.GetString(2);
                    SinhVien sV = new SinhVien(idSV,tenSV,maSV);
                    dsSV.Add(sV);
                }
                conn.Close(); // 
                return dsSV;
            }
            catch (Exception)
            {
             
                throw;
            }
            
        }
        public static void Luachon2()
        {
            string chon2;
            chon2 = Console.ReadLine();
            chon2 = chon2.Trim();
            if (chon2 == "1")
            {
                Console.WriteLine("Thực hiện Sửa thông tin");
                
            }
            else if (chon2 == "0")
            {
                Menu();
                LuaChon();
            }
            else
            {
                Luachon2();
            }
        }
     
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("My Sql Connection");
            conn = DBUtils.GetDBConnection("minhtien");
            try
            {
                Console.WriteLine("Đang mở kết nối ...");

                conn.Open();

                Console.WriteLine("Kết nối Thành Công, This is Menu:");
                Menu();
                LuaChon();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();

        }


    }
}

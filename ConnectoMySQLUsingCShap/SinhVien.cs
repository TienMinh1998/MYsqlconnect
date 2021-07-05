using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectoMySQLUsingCShap
{
    class SinhVien
    {
        private int id;
        private string ten;
        private string ma;

        public int Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Ma { get => ma; set => ma = value; }

        public SinhVien(int Id, string Ten, string Ma)
        {
            // ham khoi tao co tham so;
            this.id = Id;

            this.ma = Ma;
            this.ten = Ten;
        }

        public SinhVien()
        {
            // ham khoi tao mac dinh
        }
    }
}

//RentalForm
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShop20
{
    public partial class RentalForm : MetroForm
    {
        string mode = "";

        //완료
        public RentalForm()
        {
            InitializeComponent();
        }

        //완료
        private void UpdateData()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open(); // DB 열기
                //string strQuery = "SELECT Idx, Author, Division, Names, ReleaseDate, ISBN, Price "
                //                 + " FROM bookstbl ";
                string strQuery = "SELECT r.idx AS '대여번호', m.Names AS '대여회원', "
		                              + " t.Names AS '장르', "
	                                  + " b.Names AS '대여책제목'  ,b.ISBN, "
                                      + " r.rentalDate AS '대여일' , r.returnDate AS '반납일'"
                                 + " FROM rentaltbl AS r "
                                + " INNER JOIN membertbl AS m  ON r.memberIdx = m.Idx "  
                                + " INNER JOIN bookstbl AS b  ON r.bookIdx = b.Idx "
                                + " INNER JOIN divtbl AS t  ON b.division = t.division";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "rentaltbl");

                GrdRentalTbl.DataSource = ds;
                GrdRentalTbl.DataMember = "rentaltbl";
            }
        }

        //완료
        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                DataGridViewRow data = GrdRentalTbl.Rows[e.RowIndex];
                TxtIdx.Text = data.Cells[0].Value.ToString();
                TxtIdx.ReadOnly = true;
                CboMemberIdx.SelectedIndex = CboMemberIdx.FindString(data.Cells[1].Value.ToString());
                CboBookIdx.SelectedIndex = CboBookIdx.FindString(data.Cells[3].Value.ToString());

                DtpRentalDate.CustomFormat = "yyyy-MM-dd";
                DtpRentalDate.Format = DateTimePickerFormat.Custom;
                DtpRentalDate.Value = DateTime.Parse(data.Cells[5].Value.ToString());

                if(string.IsNullOrEmpty(data.Cells[6].Value.ToString()))
                {
                    DtpReturnDate.CustomFormat = " ";
                    DtpReturnDate.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    DtpReturnDate.CustomFormat = "yyyy-MM-dd";
                    DtpReturnDate.Format = DateTimePickerFormat.Custom;
                    DtpReturnDate.Value = DateTime.Parse(data.Cells[6].Value.ToString());
                }
                mode = "UPDATE"; // 수정은 UPDATE
            }
        }

        // 새로운 데이터 저장
        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearTextControls();

            mode = "INSERT"; // 신규는 INSERT
        }

        //데이터 수정
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(CboMemberIdx.SelectedIndex == -1 || CboBookIdx.SelectedIndex == -1)
            {
                MetroMessageBox.Show(this, "빈값은 저장할 수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveProcess();
            UpdateData();
            ClearTextControls();
        }

        
       // 입력창 초기화
        private void ClearTextControls()
        {
            TxtIdx.Text = "";
            CboMemberIdx.SelectedIndex = -1;
            CboBookIdx.SelectedIndex = -1;
            DtpRentalDate.CustomFormat = " ";
            DtpRentalDate.Format = DateTimePickerFormat.Custom;
            DtpReturnDate.CustomFormat = " ";
            DtpReturnDate.Format = DateTimePickerFormat.Custom;
            CboMemberIdx.Focus();
        }

         //DB 저장
        private void SaveProcess()
        {
            if(string.IsNullOrEmpty(mode))
            {
                MetroMessageBox.Show(this, "신규버튼을 누르고 데이터를 저장하십시오.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string strQuery = "";

                if (mode == "UPDATE")
                {
                    strQuery = "UPDATE rentaltbl "
                               + " SET memberIdx = @memberIdx, bookIdx = @bookIdx, rentalDate = @rentalDate, returnDate = @returnDate"
                             + " WHERE Idx = @Idx";
                }
                else if (mode == "INSERT")
                {
                    strQuery = "INSERT INTO rentaltbl(memberIdx, bookIdx, rentalDate, returnDate) "
                            + " VALUES(@memberIdx, @bookIdx, @rentalDate, @returnDate)";
                }
                cmd.CommandText = strQuery;

                SqlParameter parmMemberIdx = new SqlParameter("@memberIdx", SqlDbType.Int);
                parmMemberIdx.Value = CboMemberIdx.SelectedValue;
                cmd.Parameters.Add(parmMemberIdx);

                SqlParameter parmBookIdx = new SqlParameter("@bookIdx", SqlDbType.Int);
                parmBookIdx.Value = CboBookIdx.SelectedValue;
                cmd.Parameters.Add(parmBookIdx);

                SqlParameter parmRentalDate = new SqlParameter("@rentalDate", SqlDbType.Date);
                parmRentalDate.Value = DtpRentalDate.Value;
                cmd.Parameters.Add(parmRentalDate);

                SqlParameter parmReturnDate = new SqlParameter("@returnDate", SqlDbType.Date);
                parmReturnDate.Value = DtpReturnDate.Value;
                cmd.Parameters.Add(parmReturnDate);

                if (mode == "UPDATE")
                {
                    SqlParameter parmIdx = new SqlParameter("@Idx", SqlDbType.Int);
                    parmIdx.Value = TxtIdx.Text;
                    cmd.Parameters.Add(parmIdx);
                }    

                cmd.ExecuteNonQuery();
            }
        }

        private void TxtNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                BtnSave_Click(sender,new EventArgs());
            }
        }
        
        
        private void MemberForm_Load(object sender, EventArgs e)
        {
            DtpRentalDate.CustomFormat = " ";
            DtpRentalDate.Format = DateTimePickerFormat.Custom;
            DtpReturnDate.CustomFormat = " ";
            DtpReturnDate.Format = DateTimePickerFormat.Custom;
            //DtpRentalDate.CustomFormat = "yyyy-MM-dd";//
            //DtpRentalDate.Format = DateTimePickerFormat.Custom;
            //DtpReturnDate.CustomFormat = "yyyy-MM-dd";//
            //DtpReturnDate.Format = DateTimePickerFormat.Custom;
            UpdateData(); // 데이터그리드 DB 데이터 로딩하기
            UpdateCboDivision();
        }

        //완료
        private void UpdateCboDivision()
        {
            using(SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Idx, Names, Levels, Addr, Mobile, Email "
                                 + " FROM membertbl";  

                SqlDataReader reader = cmd.ExecuteReader();
                Dictionary<string, string> temps = new Dictionary<string, string>();
                Dictionary<string, string> temps2 = new Dictionary<string, string>();
                while(reader.Read())
                {
                    temps.Add(reader[0].ToString(), reader[1].ToString());
                }

                cmd.CommandText = "SELECT Idx, Author, Division, Names, ReleaseDate, ISBN, Price "
                                 + " FROM dbo.bookstbl";
                reader.Close();
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    temps2.Add(reader[0].ToString(), reader[3].ToString());

                }

                CboMemberIdx.DataSource = new BindingSource(temps, null);
                CboMemberIdx.DisplayMember = "Value";
                CboMemberIdx.ValueMember = "Key";
                CboMemberIdx.SelectedIndex = -1;

                CboBookIdx.DataSource = new BindingSource(temps2, null);
                CboBookIdx.DisplayMember = "Value";
                CboBookIdx.ValueMember = "Key";
                CboBookIdx.SelectedIndex = -1;

            }
        }


         private void DtpReleaseDate_ValueChanged(object sender, EventArgs e)
        {
            DtpRentalDate.CustomFormat = "yyyy-MM-dd";
            DtpRentalDate.Format = DateTimePickerFormat.Custom;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ClearTextControls();
        }

        private void DtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            DtpReturnDate.CustomFormat = "yyyy-MM-dd";
            DtpReturnDate.Format = DateTimePickerFormat.Custom;
        }
    }
}

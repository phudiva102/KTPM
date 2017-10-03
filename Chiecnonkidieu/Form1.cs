using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Chiecnonkidieu
{
    public partial class Form1 : Form
    {
        String[] arrQuestion = new String[100];
        String[] arrAnswer = new String[100];
        List<Label> labels = new List<Label>();
        int cauhoi = 0; //câu hỏi : 0 = câu 1
        int cautraloi = 0; //kiểm tra người dùng trả lời xong câu hỏi chưa
        double diem = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String part = Application.StartupPath + @"\chiecnon.png";
            picvongquay.Image = Image.FromFile(part);
            picvongquay.SizeMode = PictureBoxSizeMode.StretchImage;
            EnableFalse();
        }
        //đọc câu hỏi + câu trả lời từ file
        private void ImportQA(string str)
        {
            int icount = 0;
            int jcount = 0;
            bool flag = true;
            string[] lines = File.ReadAllLines(str);
            foreach (string s in lines)
            {
                if (flag == true)
                {
                    arrQuestion[icount++] = s;
                    flag = false;
                }
                else
                {
                    arrAnswer[jcount++] = s;
                    flag = true;
                }
               
            }
            
        }
        //Thêm kí tự chữ trong đáp án vào groupbox
        private void Addlabels()
        {
            gbdapan.Controls.Clear();
            labels.Clear();
            char[] wordChars = arrAnswer[cauhoi].ToCharArray(); //chuyển đáp án thành từng kí  tự
            int len = wordChars.Length;
            int refer = gbdapan.Width / len/2; // chia khoảng cách từng kí tự trong gourpbox
            for (int i = 0; i < len; i++)
            {
                Label l = new Label();
                if (wordChars[i] != ' ')
                    l.Text = "_";
                else
                l.Text = " "; 
                l.Location = new Point(10*15 + i * refer, gbdapan.Height - 80);
                l.Parent = gbdapan;
                l.BringToFront(); //Thêm labels vào đằng sau
                labels.Add(l);
            }
        }
        //Chọn câu trả lời
        private void button1_Click(object sender, EventArgs e)
        {  
            if(diem <= 0)
            {
                MessageBox.Show("Bạn đã thua!");
                this.Close();
            }
            if (cauhoi == 2)
            {
                MessageBox.Show("You Win");
                this.Close();
            }

            Button b = (Button)sender;
            //char charClicked = b.Text.ToCharArray()[0];
            SelectQuestion(cauhoi, b.Text.ToCharArray()[0]);
           
            b.Enabled = false;
            if (cautraloi == arrAnswer[cauhoi].Length)
            {
                cauhoi++;
                Addlabels();
                lbchoi.Text = "Câu " + (cauhoi + 1) + " :" + arrQuestion[cauhoi].ToString();
                EnableTrue();
            }
         
        }
        private void btchoi_Click(object sender, EventArgs e)
        {
            EnableTrue();
            ImportQA(@"D:\cautraloi.txt");
            lbchoi.Text = "Câu " + (cauhoi + 1) + " :" + arrQuestion[cauhoi].ToString();
            Addlabels();
            DialogResult dlg = MessageBox.Show("Yes/No", "Chào mừng bạn đến với Chiếc nón kí diệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                MessageBox.Show("Bạn được tặng 500 điểm");
                diem = 500;
                txtdiem.Text = diem.ToString();
            }
            else
            {
                MessageBox.Show("GoodBye!");
                this.Close();
            }
        }
        //Chọn câu hỏi
        private void SelectQuestion(int question, char charClicked)
        {
            arrAnswer[question] = arrAnswer[question].ToUpper();
            //Người chơi chọn đúng kí tự trong câu trả lời
            if (arrAnswer[question].Contains(charClicked))
            {
                lbstatus.Parent = gbdapan;
                char[] wordchar = arrAnswer[question].ToCharArray(); // chuyển chuỗi kết quả thành mảng kí tự
                for (int i = 0; i < wordchar.Length; i++)
                {
                    if (charClicked == wordchar[i])
                    {
                        cautraloi++;
                        lbstatus.Text = "Bạn đã trả lời đúng!";
                        labels[i].Text = charClicked.ToString();
                        diem += 500;
                        txtdiem.Text = diem.ToString();
                    }
                }

            }
            else
            {
                lbstatus.Text = "Bạn đã trả lời sai!";
                diem -= 500;
                txtdiem.Text = diem.ToString();
            }

        }
        //Ẩn hiển bảng kí tự từ A->Z
        private void EnableTrue()
        {
            bta.Enabled = true;
            btb.Enabled = true;
            btc.Enabled = true;
            btd.Enabled = true;
            bte.Enabled = true;
            btf.Enabled = true;
            btg.Enabled = true;
            bth.Enabled = true;
            bti.Enabled = true;
            btj.Enabled = true;
            btk.Enabled = true;
            btl.Enabled = true;
            btm.Enabled = true;
            btn.Enabled = true;
            bto.Enabled = true;
            btp.Enabled = true;
            btq.Enabled = true;
            btr.Enabled = true;
            bts.Enabled = true;
            btt.Enabled = true;
            btu.Enabled = true;
            btv.Enabled = true;
            btx.Enabled = true;
            bty.Enabled = true;
        }
        private void EnableFalse()
        {
            bta.Enabled = false;
            btb.Enabled = false;
            btc.Enabled = false;
            btd.Enabled = false;
            bte.Enabled = false;
            btf.Enabled = false;
            btg.Enabled = false;
            bth.Enabled = false;
            bti.Enabled = false;
            btj.Enabled = false;
            btk.Enabled = false;
            btl.Enabled = false;
            btm.Enabled = false;
            btn.Enabled = false;
            bto.Enabled = false;
            btp.Enabled = false;
            btq.Enabled = false;
            btr.Enabled = false;
            bts.Enabled = false;
            btt.Enabled = false;
            btu.Enabled = false;
            btv.Enabled = false;
            btx.Enabled = false;
            bty.Enabled = false;
        }



    }
}

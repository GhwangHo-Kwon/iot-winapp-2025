namespace SyntaxWinApp03
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnMsg_Click(object sender, EventArgs e)
        {
            // 분기문
            // if else 문
            if (TxtPain.Text == "아니오")
            {
                MessageBox.Show("병원을 왜 왔어요. 집에가!");
            }
            else if (TxtPain.Text == "네")
            {
                string PainPoint = CboPainPoint.SelectedItem.ToString();

                // switch 문
                switch (PainPoint)
                {
                    /*머리 눈 코 목 가슴 배*/
                    case "머리":
                        MessageBox.Show("신경과로 갑니다", "진료과선택");
                        break;
                    case "눈":
                        MessageBox.Show("안과로 갑니다", "진료과선택");
                        break;
                    case "목":
                    case "코":
                        MessageBox.Show("이비인후과로 갑니다", "진료과선택");
                        break;
                    case "가슴":
                        MessageBox.Show("내과로 갑니다", "진료과선택");
                        break;
                    case "배":
                        MessageBox.Show("소아과로 갑니다", "진료과선택");
                        break;
                }
            }

        }

        private void TxtPain_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 키프레스에서 엔터를 입력하면 C, C++ if문과 동일
            if (e.KeyChar == (char)Keys.Enter)
            {
                MessageBox.Show(TxtPain.Text, "입력값");
            }
        }

        private void CboPainPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPoint = CboPainPoint.SelectedItem.ToString();
            MessageBox.Show(selectedPoint, "통증부위");
        }

        private void BtnDisplay_Click(object sender, EventArgs e)
        {
            // for문
            TxtResult.Text = string.Empty;  // 초기화
            for (int x = 2; x < 10; x++)
            {
                for (int y = 1; y < 10; y++)
                {
                    var result = x + "x" + y + "=" + (x * y);
                    TxtResult.Text += result + " ";
                }
                TxtResult.Text += "\r\n";  // 원래 윈도우는 \r\n을 같이 써야 함
            }
        }

        int clickNum = 0;

        private void BtnWhile_Click(object sender, EventArgs e)
        {
            // 무한 반복
            while (true)
            {
                MessageBox.Show("계속 > " + clickNum);
                clickNum++;

                if (clickNum >= 10)
                {
                    break; // 반복문 탈출 for, foreach, while문에 사용가능
                    // continue; 도 파악할 것
                    // goto; 는 웬만하면 쓰지 말것
                }
            }
        }
    }
}

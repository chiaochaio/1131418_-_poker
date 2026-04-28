using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1131418_杜語喬_poker
{
    public partial class frmPoker : Form
    {
        PictureBox[] pic = new PictureBox[5];
        int[] allPoker = new int[52];
        int[] playerPoker = new int[5];

        private decimal totalCapital = 1000000m; // 總資金
        private decimal currentBet = 0m;         // 目前押注

        public frmPoker()
        {
            InitializeComponent();
            InitializePoker();

            this.AcceptButton = null;

            // 只屏蔽會翻牌的按鍵 (q, w, e, r, t, y)，允許正常編輯 NumericUpDown
            if (nudBet != null)
            {
                nudBet.KeyPress += (s, ke) => 
                { 
                    // 阻止會翻牌的字元輸入
                    if (char.ToLower(ke.KeyChar) == 'q' || char.ToLower(ke.KeyChar) == 'w' || 
                        char.ToLower(ke.KeyChar) == 'e' || char.ToLower(ke.KeyChar) == 'r' || 
                        char.ToLower(ke.KeyChar) == 't' || char.ToLower(ke.KeyChar) == 'y')
                    {
                        ke.Handled = true;
                    }
                };
            }

            btnDealCard.Enabled = false;
            btnChangeCard.Enabled = false;
            btnCheck.Enabled = false;

            UpdateCapitalDisplay();
            UpdateCurrentBetDisplay();
        }


        #region 自定義方法
        private void InitializePoker()
        {

            for (int i = 0; i < pic.Length; i++)
            {
                pic[i] = new PictureBox();
                pic[i].Image = GetImage("back");
                pic[i].Name = "pic" + i; //把數字轉字串,字串合併
                pic[i].SizeMode = PictureBoxSizeMode.AutoSize;
                pic[i].Top = 30; //固定在同一水平線上
                pic[i].Left = 10 + ((pic[i].Width + 10) * i);                   
                pic[i].Visible = true;
                pic[i].Enabled = false;
                pic[i].Tag = "back";
                this.grpPoker.Controls.Add(pic[i]);
                pic[i].MouseClick += new MouseEventHandler(picTest_Click);

            }
        }
        #endregion

        private Image GetImage(string name)
        {
            return Properties.Resources.ResourceManager.GetObject(name) as Image;
        }
        private Image GetImage(int num)
        {
            return GetImage($"pic{num}");
        }
        private void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < 1000; i++) //52 次可能不太夠
            {
                int r = rand.Next(allPoker.Length);
                int temp = allPoker[r];
                allPoker[r] = allPoker[0];
                allPoker[0] = temp;
            }
        }

        private void UpdateCapitalDisplay()
        {
            lblCapital.Text = totalCapital.ToString("N0");
            // 調整 NumericUpDown 最大為目前資金
            if (nudBet != null)
            {
                nudBet.Maximum = (decimal)Int32.MaxValue;
                if (totalCapital > 0)
                {
                    nudBet.Maximum = Math.Max(1, (int)totalCapital);
                }
            }
        }

        private void UpdateCurrentBetDisplay()
        {
            lblCurrentBet.Text = currentBet.ToString("N0");
        }

        private void grpPoker_Enter(object sender, EventArgs e)
        {

        }

        private void frmPoker_Load(object sender, EventArgs e)
        {

        }

        // 按下「下押注」
        private void btnPlaceBet_Click(object sender, EventArgs e)
        {
            decimal bet = nudBet.Value;
            if (bet <= 0)
            {
                MessageBox.Show("押注必須大於 0");
                return;
            }
            if (bet > totalCapital)
            {
                MessageBox.Show("押注不能超過總資金");
                return;
            }

            // 扣款並紀錄押注
            currentBet = bet;
            totalCapital -= currentBet;
            UpdateCapitalDisplay();
            UpdateCurrentBetDisplay();

            // 在下押注後允許發牌，並鎖定押注控件直到本局結束
            btnDealCard.Enabled = true;
            btnPlaceBet.Enabled = false;
            nudBet.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // button3 為判斷牌型 (btnCheck)
            string[] colorList = { "梅花", "方塊", "愛心", "黑桃" };
            string[] pointList = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            // 記錄目前五張撲克牌的花色和點數的陣列
            int[] pokerColor = new int[5];
            int[] pokerPoint = new int[5];
            // 將每張牌的顏色和點數分別存入 pokerColor 和 pokerPoint 陣列
            for (int i = 0; i < 5; i++)
            {
                pokerColor[i] = playerPoker[i] % 4;
                pokerPoint[i] = playerPoker[i] / 4;
            }
            int[] colorCount = new int[4];
            int[] pointCount = new int[13];
            for (int i = 0; i < 5; i++)
            {
                int color = pokerColor[i];
                int point = pokerPoint[i];
                colorCount[color]++;
                pointCount[point]++;
            }
            // 排序 colorCount 和 pointCount 由大到小
            Array.Sort(colorCount, colorList);
            Array.Reverse(colorCount);
            Array.Reverse(colorList);
            Array.Sort(pointCount, pointList);
            Array.Reverse(pointCount);
            Array.Reverse(pointList);
            // 判斷是否為同花
            bool isFlush = (colorCount[0] == 5);
            // 判斷是否為五張單張
            bool isSingle = (pointCount[0] == 1 && pointCount[1] == 1 && pointCount[2] == 1 &&
            pointCount[3] == 1 && pointCount[4] == 1);
            // 判斷是否為差四
            bool isDiffFout = (pokerPoint.Max() - pokerPoint.Min() == 4);
            // 判斷是否為大順
            bool isRoyal = pokerPoint.Contains(0) && pokerPoint.Contains(9) &&
            pokerPoint.Contains(10) && pokerPoint.Contains(11) && pokerPoint.Contains(12);
            // 判斷是否為同花大順
            bool isRoyalisFlush = isFlush && isRoyal;
            // 判斷是否為同花順
            bool isStraightFlush = isFlush && isSingle && isDiffFout;
            // 判斷是否為順子
            bool isStraight = isSingle && (isDiffFout || isRoyal);
            // 判斷是否為鐵支
            bool isFourOfAKind = (pointCount[0] == 4);
            // 判斷是否為葫蘆
            bool isFullHouse = (pointCount[0] == 3 && pointCount[1] == 2);
            // 判斷是否為三條
            bool isThreeOfAKind = (pointCount[0] == 3 && pointCount[1] == 1);
            // 判斷是否為兩對
            bool isTwoPair = (pointCount[0] == 2 && pointCount[1] == 2);
            // 判斷是否為一對
            bool isOnePair = (pointCount[0] == 2 && pointCount[1] == 1);
            string result = "";
            if (isRoyalisFlush)
            {
                result = $"{colorList[0]} 同花大順";
            }
            else if (isStraightFlush)
            {
                result = $"{colorList[0]} 同花順";
            }
            else if (isStraight)
            {
                result = "順子";
            }
            else if (isFourOfAKind)
            {
                result = $"{pointList[0]} 鐵支";
            }
            else if (isFullHouse)
            {
                result = $"{pointList[0]}三張{pointList[1]}兩張 葫蘆";
            }
            else if (isFlush)
            {
                result = $"{colorList[0]} 同花";
            }
            else if (isThreeOfAKind)
            {
                result = $"{pointList[0]} 三條";
            }
            else if (isTwoPair)
            {
                result = $"{pointList[0]},{pointList[1]} 兩對";
            }
            else if (isOnePair)
            {
                result = $"{pointList[0]} 一對";
            }
            else
            {
                result = "雜牌";
            }
            lblResult.Text = result;

            // 依牌型決定賠率 multiplier（葫蘆=9、同花=6、順子=4、一對=1）
            double multiplier = 0.0;
            if (result.Contains("同花大順")) multiplier = 100;
            else if (result.Contains("同花順")) multiplier = 50;
            else if (result.Contains("鐵支")) multiplier = 25;
            else if (result.Contains("葫蘆")) multiplier = 9;    // 葫蘆 = 9
            else if (result.Contains("同花")) multiplier = 6;    // 同花 = 6
            else if (result.Contains("順子")) multiplier = 4;    // 順子 = 4 (已更新)
            else if (result.Contains("三條")) multiplier = 3;
            else if (result.Contains("兩對")) multiplier = 2;
            else if (result.Contains("一對")) multiplier = 1;    // 一對 = 1 (已更新)
            else multiplier = 0;

            // 計算並更新總資金：押注在下押注時已扣除，這裡回收押注 * multiplier（若 multiplier=0 則不回收）
            decimal payout = 0m;
            if (currentBet > 0m && multiplier > 0)
            {
                payout = currentBet * (decimal)multiplier;
                totalCapital += payout;
            }

            // 顯示結果 summary
            if (currentBet <= 0m)
            {
                MessageBox.Show($"未下押注，本局結果：{result}");
            }
            else
            {
                if (multiplier > 0)
                {
                    MessageBox.Show($"你拿到 {result}\n賠率：{multiplier}x\n本局回收：{payout:N0}");
                }
                else
                {
                    MessageBox.Show($"你拿到 {result}\n未中，損失押注：{currentBet:N0}");
                }
            }

            // 重置本局狀態
            currentBet = 0m;
            UpdateCapitalDisplay();
            UpdateCurrentBetDisplay();

            // 禁用換牌、檢查按鈕的相應狀態，恢復可押注與發牌
            btnChangeCard.Enabled = false;
            btnCheck.Enabled = false;
            btnDealCard.Enabled = true;
            btnPlaceBet.Enabled = true;
            nudBet.Enabled = true;
        }

        private void picTest_Click(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            // 取得 pic 的索引值
            int index = int.Parse(pic.Name.Replace("pic", ""));
            // 如果 pic 的 Tag 為 back，則將顯示撲克牌
            int cardNum = playerPoker[index] + 1; // 撲克牌的編號從 1 開始
            if (pic.Tag.ToString() == "back")
            {
                pic.Tag = "front";
                pic.Image = GetImage(cardNum);
            }
            else
            {
                pic.Tag = "back";
                pic.Image = GetImage("back");
            }

        }

        private void ShowCards()
        {
            for (int i = 0; i < 5; i++)
            {
                pic[i].Image = this.GetImage($"pic{playerPoker[i] + 1}");
            }
        }

        private async void btnDealCard_ClickAsync(object sender, EventArgs e)
        {
            // 發牌按下後立刻停用發牌，直到本局判斷完成
            btnDealCard.Enabled = false;
            this.lblResult.Text = "";
            for (int i = 0; i < 5; i++)
            {
                pic[i].Image = GetImage("back");
            }
            // 初始化52張牌
            for (int i = 0; i < 52; i++)
            {
                allPoker[i] = i;
            }
            // 洗牌
            Shuffle();

            await Task.Delay(500);
            // 發牌
            for (int i = 0; i < 5; i++)
            {
                pic[i].Image = GetImage("pic" + (allPoker[i] + 1));
                playerPoker[i] = allPoker[i];
            }

            for (int i = 0; i < pic.Length; i++)
            {
                //將牌桌上的牌設成可以點擊
                pic[i].Enabled = true;
                pic[i].Tag = "front";
            }
            btnChangeCard.Enabled = true;
            btnDealCard.Enabled = false; // 確保發牌按鈕停用，直到判斷完畢
            btnCheck.Enabled = true;
        }

        private void btnChangeCard_Click(object sender, EventArgs e)
        {

            int cardIndex = 5;
            for (int i = 0; i < pic.Length; i++)
            {
                if (pic[i].Tag.ToString() == "back")
                {
                    playerPoker[i] = allPoker[cardIndex];
                    pic[i].Image = GetImage("pic" + (playerPoker[i] + 1));
                    pic[i].Tag = "front";
                    cardIndex++;
                }
            }
            // 禁用所有牌的點擊事件
            for (int i = 0; i < pic.Length; i++)
            {
                pic[i].Enabled = false;
            }
            this.btnChangeCard.Enabled = false;
            this.btnCheck.Enabled = true;
            this.btnDealCard.Enabled = false;

        }

        private void frmPoker_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 若焦點在 nudBet 上，不執行翻牌邏輯
            if (nudBet.Focused)
            {
                return;
            }

            if (btnDealCard.Enabled == false)
            {
                switch (e.KeyChar)
                {
                    case 'q': // q鍵
                              // 同花大順
                        playerPoker[0] = 51;
                        playerPoker[1] = 47;
                        playerPoker[2] = 43;
                        playerPoker[3] = 39;
                        playerPoker[4] = 3;
                        break;
                    case 'w': // w鍵
                              // 同花順
                        playerPoker[0] = 37;
                        playerPoker[1] = 33;
                        playerPoker[2] = 29;
                        playerPoker[3] = 25;
                        playerPoker[4] = 21;
                        break;
                    case 'e': // e鍵
                              // 同花
                        playerPoker[0] = 50;
                        playerPoker[1] = 38;
                        playerPoker[2] = 34;
                        playerPoker[3] = 22;
                        playerPoker[4] = 18;
                        break;
                    case 'r': // r鍵
                              // 鐵支
                        playerPoker[0] = 48;
                        playerPoker[1] = 39;
                        playerPoker[2] = 38;
                        playerPoker[3] = 37;
                        playerPoker[4] = 36;
                        break;
                    case 't': // t鍵
                              // 葫蘆
                        playerPoker[0] = 30;
                        playerPoker[1] = 29;
                        playerPoker[2] = 6;
                        playerPoker[3] = 5;
                        playerPoker[4] = 4;
                        break;
                    case 'y': // y鍵
                              // 三條
                        playerPoker[0] = 48;
                        playerPoker[1] = 39;
                        playerPoker[2] = 15;
                        playerPoker[3] = 14;
                        playerPoker[4] = 13;
                        break;
                }
                // 顯示五張撲克牌到桌面上
                ShowCards();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grpmoney_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // 重置遊戲狀態到初始化
            totalCapital = 1000000m;
            currentBet = 0m;
            
            // 清空牌桌
            for (int i = 0; i < pic.Length; i++)
            {
                pic[i].Image = GetImage("back");
                pic[i].Enabled = false;
                pic[i].Tag = "back";
            }
            
            // 清空結果顯示
            lblResult.Text = "";
            
            // 重置押注欄
            nudBet.Value = 0;
            nudBet.Enabled = true;
            
            // 重置按鈕狀態
            btnPlaceBet.Enabled = true;
            btnDealCard.Enabled = false;
            btnChangeCard.Enabled = false;
            btnCheck.Enabled = false;
            
            // 更新 UI 顯示
            UpdateCapitalDisplay();
            UpdateCurrentBetDisplay();
        }
    }
}

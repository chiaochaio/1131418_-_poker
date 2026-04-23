namespace _1131418_杜語喬_poker
{
    partial class frmPoker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpPoker = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnChangeCard = new System.Windows.Forms.Button();
            this.btnDealCard = new System.Windows.Forms.Button();
            this.grpmoney = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMoney = new System.Windows.Forms.TextBox();
            this.btnPress = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grpmoney.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPoker
            // 
            this.grpPoker.BackColor = System.Drawing.Color.OliveDrab;
            this.grpPoker.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpPoker.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grpPoker.Location = new System.Drawing.Point(38, 54);
            this.grpPoker.Name = "grpPoker";
            this.grpPoker.Size = new System.Drawing.Size(485, 160);
            this.grpPoker.TabIndex = 0;
            this.grpPoker.TabStop = false;
            this.grpPoker.Text = "牌桌";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.lblResult);
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.btnChangeCard);
            this.groupBox1.Controls.Add(this.btnDealCard);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(38, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 107);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能";
            // 
            // lblResult
            // 
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult.Location = new System.Drawing.Point(311, 42);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(152, 41);
            this.lblResult.TabIndex = 3;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCheck
            // 
            this.btnCheck.Enabled = false;
            this.btnCheck.Location = new System.Drawing.Point(192, 42);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(102, 41);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "判斷牌型";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnChangeCard
            // 
            this.btnChangeCard.Enabled = false;
            this.btnChangeCard.Location = new System.Drawing.Point(100, 42);
            this.btnChangeCard.Name = "btnChangeCard";
            this.btnChangeCard.Size = new System.Drawing.Size(86, 41);
            this.btnChangeCard.TabIndex = 1;
            this.btnChangeCard.Text = "換牌";
            this.btnChangeCard.UseVisualStyleBackColor = true;
            this.btnChangeCard.Click += new System.EventHandler(this.btnChangeCard_Click);
            // 
            // btnDealCard
            // 
            this.btnDealCard.Location = new System.Drawing.Point(6, 42);
            this.btnDealCard.Name = "btnDealCard";
            this.btnDealCard.Size = new System.Drawing.Size(88, 41);
            this.btnDealCard.TabIndex = 0;
            this.btnDealCard.Text = "發牌";
            this.btnDealCard.UseVisualStyleBackColor = true;
            this.btnDealCard.Click += new System.EventHandler(this.btnDealCard_ClickAsync);
            // 
            // grpmoney
            // 
            this.grpmoney.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.grpmoney.Controls.Add(this.btnPress);
            this.grpmoney.Controls.Add(this.tbMoney);
            this.grpmoney.Controls.Add(this.label2);
            this.grpmoney.Controls.Add(this.lblTotal);
            this.grpmoney.Controls.Add(this.label1);
            this.grpmoney.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpmoney.Location = new System.Drawing.Point(529, 54);
            this.grpmoney.Name = "grpmoney";
            this.grpmoney.Size = new System.Drawing.Size(225, 273);
            this.grpmoney.TabIndex = 2;
            this.grpmoney.TabStop = false;
            this.grpmoney.Text = "下注";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "總資金:";
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Location = new System.Drawing.Point(11, 69);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(203, 39);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "押注金額:";
            // 
            // tbMoney
            // 
            this.tbMoney.Location = new System.Drawing.Point(11, 145);
            this.tbMoney.Name = "tbMoney";
            this.tbMoney.Size = new System.Drawing.Size(203, 34);
            this.tbMoney.TabIndex = 3;
            // 
            // btnPress
            // 
            this.btnPress.Location = new System.Drawing.Point(11, 208);
            this.btnPress.Name = "btnPress";
            this.btnPress.Size = new System.Drawing.Size(203, 41);
            this.btnPress.TabIndex = 4;
            this.btnPress.Text = "押注";
            this.btnPress.UseVisualStyleBackColor = true;
            // 
            // frmPoker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 354);
            this.Controls.Add(this.grpmoney);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpPoker);
            this.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "frmPoker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fivePoker";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmPoker_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.grpmoney.ResumeLayout(false);
            this.grpmoney.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPoker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnChangeCard;
        private System.Windows.Forms.Button btnDealCard;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.GroupBox grpmoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPress;
        private System.Windows.Forms.TextBox tbMoney;
        private System.Windows.Forms.Label label2;
    }
}
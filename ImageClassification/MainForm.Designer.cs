namespace ImageClassification
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonRun = new System.Windows.Forms.Button();
            this.imageBox = new Emgu.CV.UI.ImageBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.textProb = new System.Windows.Forms.TextBox();
            this.textTime = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelProb = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(418, 12);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "选择图片";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(12, 12);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(400, 300);
            this.imageBox.TabIndex = 2;
            this.imageBox.TabStop = false;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(418, 53);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(75, 21);
            this.textName.TabIndex = 3;
            // 
            // textProb
            // 
            this.textProb.Location = new System.Drawing.Point(418, 92);
            this.textProb.Name = "textProb";
            this.textProb.Size = new System.Drawing.Size(75, 21);
            this.textProb.TabIndex = 4;
            // 
            // textTime
            // 
            this.textTime.Location = new System.Drawing.Point(418, 131);
            this.textTime.Name = "textTime";
            this.textTime.Size = new System.Drawing.Size(75, 21);
            this.textTime.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(418, 38);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(65, 12);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "识别结果：";
            // 
            // labelProb
            // 
            this.labelProb.AutoSize = true;
            this.labelProb.Location = new System.Drawing.Point(418, 77);
            this.labelProb.Name = "labelProb";
            this.labelProb.Size = new System.Drawing.Size(65, 12);
            this.labelProb.TabIndex = 7;
            this.labelProb.Text = "结果概率：";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(418, 116);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(65, 12);
            this.labelTime.TabIndex = 8;
            this.labelTime.Text = "运行时间：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 324);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelProb);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textTime);
            this.Controls.Add(this.textProb);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.buttonRun);
            this.Name = "MainForm";
            this.Text = "图像识别";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonRun;
        private Emgu.CV.UI.ImageBox imageBox;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textProb;
        private System.Windows.Forms.TextBox textTime;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelProb;
        private System.Windows.Forms.Label labelTime;
    }
}


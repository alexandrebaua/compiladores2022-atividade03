namespace Compilador
{
    partial class FormMain
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
            this.rtxtCode = new System.Windows.Forms.RichTextBox();
            this.lstTokens = new System.Windows.Forms.ListBox();
            this.btnExec = new System.Windows.Forms.Button();
            this.lstSintatico = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // rtxtCode
            // 
            this.rtxtCode.DetectUrls = false;
            this.rtxtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtCode.Location = new System.Drawing.Point(12, 12);
            this.rtxtCode.Name = "rtxtCode";
            this.rtxtCode.Size = new System.Drawing.Size(273, 349);
            this.rtxtCode.TabIndex = 1;
            this.rtxtCode.Text = "(int)\nint\n(int";
            this.rtxtCode.WordWrap = false;
            // 
            // lstTokens
            // 
            this.lstTokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTokens.FormattingEnabled = true;
            this.lstTokens.ItemHeight = 15;
            this.lstTokens.Location = new System.Drawing.Point(291, 12);
            this.lstTokens.Name = "lstTokens";
            this.lstTokens.Size = new System.Drawing.Size(374, 349);
            this.lstTokens.TabIndex = 2;
            // 
            // btnExec
            // 
            this.btnExec.Location = new System.Drawing.Point(12, 367);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(75, 23);
            this.btnExec.TabIndex = 3;
            this.btnExec.Text = "Executar";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // lstSintatico
            // 
            this.lstSintatico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSintatico.FormattingEnabled = true;
            this.lstSintatico.ItemHeight = 15;
            this.lstSintatico.Location = new System.Drawing.Point(671, 12);
            this.lstSintatico.Name = "lstSintatico";
            this.lstSintatico.Size = new System.Drawing.Size(268, 349);
            this.lstSintatico.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 402);
            this.Controls.Add(this.lstSintatico);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.lstTokens);
            this.Controls.Add(this.rtxtCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Compilador - Atividades";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtCode;
        private System.Windows.Forms.ListBox lstTokens;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.ListBox lstSintatico;
    }
}


using System.Drawing;

namespace YSA_Odev
{
    partial class Form1
    {
        /// <summary>
        /// Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        /// <param name="disposing">Gerçekten yönetilen kaynakları serbest bırakıyorsa true; Aksi takdirde, false. </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Tasarımcısı tarafından oluşturulan kod

        /// <summary>
        /// Gerekli yöntem - tasarımcı desteği ile kullanılır - metodun içeriğini değiştirmeyin
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button_CizgiKaldir = new System.Windows.Forms.Button();
            this.button_Temizle = new System.Windows.Forms.Button();
            this.button_Egit = new System.Windows.Forms.Button();
            this.button_Tanimla = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEpsilon = new System.Windows.Forms.TextBox();
            this.eosln = new System.Windows.Forms.Label();
            this.buttonUpdateEpsilon = new System.Windows.Forms.Button();
            this.labelhata = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.Location = new System.Drawing.Point(16, 15);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(350, 450);
            this.Panel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox1.Location = new System.Drawing.Point(411, 75);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(794, 390);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button_CizgiKaldir
            // 
            this.button_CizgiKaldir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_CizgiKaldir.Location = new System.Drawing.Point(16, 483);
            this.button_CizgiKaldir.Name = "button_CizgiKaldir";
            this.button_CizgiKaldir.Size = new System.Drawing.Size(160, 56);
            this.button_CizgiKaldir.TabIndex = 2;
            this.button_CizgiKaldir.Text = "Çizgileri Kaldır";
            this.button_CizgiKaldir.UseVisualStyleBackColor = true;
            this.button_CizgiKaldir.Click += new System.EventHandler(this.button_CizgiKaldir_Click);
            // 
            // button_Temizle
            // 
            this.button_Temizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_Temizle.Location = new System.Drawing.Point(204, 483);
            this.button_Temizle.Name = "button_Temizle";
            this.button_Temizle.Size = new System.Drawing.Size(162, 56);
            this.button_Temizle.TabIndex = 2;
            this.button_Temizle.Text = "Temizle";
            this.button_Temizle.UseVisualStyleBackColor = true;
            this.button_Temizle.Click += new System.EventHandler(this.button_Temizle_Click);
            // 
            // button_Egit
            // 
            this.button_Egit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_Egit.Location = new System.Drawing.Point(877, 483);
            this.button_Egit.Name = "button_Egit";
            this.button_Egit.Size = new System.Drawing.Size(160, 56);
            this.button_Egit.TabIndex = 2;
            this.button_Egit.Text = "Eğit";
            this.button_Egit.UseVisualStyleBackColor = true;
            this.button_Egit.Click += new System.EventHandler(this.button_Egit_Click_1);
            // 
            // button_Tanimla
            // 
            this.button_Tanimla.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_Tanimla.Location = new System.Drawing.Point(1043, 484);
            this.button_Tanimla.Name = "button_Tanimla";
            this.button_Tanimla.Size = new System.Drawing.Size(162, 56);
            this.button_Tanimla.TabIndex = 2;
            this.button_Tanimla.Text = "Tanımla";
            this.button_Tanimla.UseVisualStyleBackColor = true;
            this.button_Tanimla.Click += new System.EventHandler(this.button_Tanimla_Click_1);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label1.Location = new System.Drawing.Point(411, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(759, 57);
            this.label1.TabIndex = 3;
            this.label1.Text = "Çıkış Değerleri";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(406, 480);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 56);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hata Oranı:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxEpsilon
            // 
            this.textBoxEpsilon.Location = new System.Drawing.Point(771, 483);
            this.textBoxEpsilon.Name = "textBoxEpsilon";
            this.textBoxEpsilon.Size = new System.Drawing.Size(100, 22);
            this.textBoxEpsilon.TabIndex = 5;
            // 
            // eosln
            // 
            this.eosln.Location = new System.Drawing.Point(644, 483);
            this.eosln.Name = "eosln";
            this.eosln.Size = new System.Drawing.Size(121, 56);
            this.eosln.TabIndex = 6;
            this.eosln.Text = "Epsilon Değeri:";
            this.eosln.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonUpdateEpsilon
            // 
            this.buttonUpdateEpsilon.Location = new System.Drawing.Point(771, 516);
            this.buttonUpdateEpsilon.Name = "buttonUpdateEpsilon";
            this.buttonUpdateEpsilon.Size = new System.Drawing.Size(100, 23);
            this.buttonUpdateEpsilon.TabIndex = 8;
            this.buttonUpdateEpsilon.Text = "Onayla";
            this.buttonUpdateEpsilon.UseVisualStyleBackColor = true;
            this.buttonUpdateEpsilon.Click += new System.EventHandler(this.buttonUpdateEpsilon_Click);
            // 
            // labelhata
            // 
            this.labelhata.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelhata.Location = new System.Drawing.Point(534, 500);
            this.labelhata.Name = "labelhata";
            this.labelhata.Size = new System.Drawing.Size(100, 23);
            this.labelhata.TabIndex = 9;
            this.labelhata.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(527, 500);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 10;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 551);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelhata);
            this.Controls.Add(this.buttonUpdateEpsilon);
            this.Controls.Add(this.eosln);
            this.Controls.Add(this.textBoxEpsilon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Tanimla);
            this.Controls.Add(this.button_Temizle);
            this.Controls.Add(this.button_Egit);
            this.Controls.Add(this.button_CizgiKaldir);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YSA Ödev";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_CizgiKaldir;
        private System.Windows.Forms.Button button_Temizle;
        private System.Windows.Forms.Button button_Egit;
        private System.Windows.Forms.Button button_Tanimla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEpsilon;
        private System.Windows.Forms.Label eosln;
        private System.Windows.Forms.Button buttonUpdateEpsilon;
        private System.Windows.Forms.Label labelhata;
        private System.Windows.Forms.Label label3;
    }
}
